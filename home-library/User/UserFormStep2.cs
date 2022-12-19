﻿using home_library.Static;
using home_library.User;
using MaterialSkin.Controls;

namespace home_library
{
    public partial class UserFormStep2 : MaterialForm
    {
        private readonly string step = string.Empty;
        public UserFormStep2(string step)
        {
            InitializeComponent();

            this.step = step;

            DataGridUser.Columns.Add("title", "Название");
            DataGridUser.Columns.Add("author", "Автор");
            DataGridUser.Columns.Add("publication_year", "Год публикации");
            DataGridUser.Columns.Add("take_date", "Взята");
            if (step == "user_books")
            {
                DataGridUser.Columns.Add("return_date", "Вернуть до");
                //Title.Text = "Книги на руках";
                Text = $"Книги на руках пользователя {User.User.Username}";
                ActionBtn.Text = "Вернуть";
            }
            else if (step == "user_history")
            {
                DataGridUser.Columns.Add("return_date", "Возвращена");
                //Title.Text = "Моя история";
                Text = $"История пользователя {User.User.Username}";

                ActionBtn.Text = "Информация";
            }
            if (Logic.IsGenre) DataGridUser.Columns.Add("genre", "Жанр");

            UpdateBooks();
        }
        private void UpdateBooks()
        {
            string query = string.Empty;

            if (step == "user_books")
                query = Queries.GetUserBooks(User.User.Username);
            else if (step == "user_history")
                query = Queries.GetUserHistory(User.User.Username);
            else
            {
                MessageBox.Show("Произошла непредвиденная ошибка");
                return;
            }
            if (Logic.IsGenre) DataGridUser.Columns.Add("genre", "Жанр");

            DataGridUser.Rows.Clear();
            List<List<string>> rows = Logic.ExecuteQuery(query);
            rows.ForEach(row => DataGridUser.Rows.Add(row.ToArray()));
        }

        private void ActionBtn_Click(object sender, EventArgs e)
        {
            if (step == "user_books")
                ReturnBook();
            else if (step == "user_history")
                ShowBookInformation();
            else
                MessageBox.Show("Произошла непредвиденная ошибка");
        }

        private void ReturnBook()
        {
            if (DataGridUser.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите книгу...", "Error!");
                return;
            }

            var row = DataGridUser.SelectedRows[0];

            string title = row.Cells[0].Value?.ToString() ?? "";
            //string author = row.Cells[1].Value?.ToString() ?? "";
            //string publication_year = row.Cells[2].Value?.ToString() ?? "";
            //string take_date = row.Cells[3].Value?.ToString() ?? "";
            //string return_date = row.Cells[4].Value?.ToString() ?? "";
            //string genre = "";
            //if (Logic.IsGenre) genre = row.Cells[5].Value?.ToString() ?? "";

            if (title.Length == 0)
            {
                MessageBox.Show("Выберите книгу...", "Error!");
                return;
            }

            try
            {
                string query = Queries.AddToHistory(title, User.User.Username);
                Logic.ExecuteNonQuery(query);

                query = Queries.RemoveLibraryMarker(title);
                Logic.ExecuteNonQuery(query);

                query = Queries.RemoveFromTakenBooks(title, User.User.Username);
                Logic.ExecuteNonQuery(query);
                

                MessageBox.Show("Книга возвращена! Спасибо!", "Успех!");
                UpdateBooks();
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так. попробуйте позже...", "Error!");
            }
        }

        private void ShowBookInformation()
        {
            var row = DataGridUser.SelectedRows[0];

            string title = row.Cells[0].Value?.ToString() ?? "";
            string author = row.Cells[1].Value?.ToString() ?? "";

            if (title.Length == 0 && author.Length == 0)
            {
                MessageBox.Show("Выберите книгу...", "Error!");
                return;
            }

            string query = Queries.GetBook(title);
            List<string> data = Logic.ExecuteQuery(query)[0];

            string book_title = data[1]; 
            string book_fio = data[2];
            string book_publication_year = data[3];

            MessageBox.Show($"Очень интересная книга. {book_title} написана {book_fio} в {book_publication_year} г.");
        }
    }
}
