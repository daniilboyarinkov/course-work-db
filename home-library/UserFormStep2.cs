namespace home_library
{
    public partial class UserFormStep2 : Form
    {
        private readonly string step = string.Empty;
        public UserFormStep2(string step)
        {
            InitializeComponent();

            this.step = step;

            UpdateBooks();
        }
        private void UpdateBooks()
        {
            DataGridUser.Columns.Add("title", "Название");
            DataGridUser.Columns.Add("author", "Автор");
            DataGridUser.Columns.Add("publication_year", "Год публикации");
            DataGridUser.Columns.Add("take_date", "Взята");
            if (UserLogic.IsGenre) DataGridUser.Columns.Add("genre", "Жанр");

            string query = string.Empty;

            if (step == "user_books")
            {
                DataGridUser.Columns.Add("return_date", "Вернуть до");

                ActionBtn.Text = "Вернуть";

                query = UserLogic.GetUsersBooks(UserLogic.IsGenre, UserLogic.Username);
            }
            else if (step == "user_history")
            {
                DataGridUser.Columns.Add("return_date", "Возвращена");

                ActionBtn.Text = "Информация";

                query = UserLogic.GetUsersHistory(UserLogic.IsGenre, UserLogic.Username);
            }
            else
            {
                MessageBox.Show("Произошла непредвиденная ошибка");
            }

            DataGridUser.Rows.Clear();
            List<List<string>> rows = UserLogic.UpdateBooks(query);
            rows.ForEach(row => DataGridUser.Rows.Add(row.ToArray()));
        }

        private void ActionBtn_Click(object sender, EventArgs e)
        {
            if (step == "user_books")
            {
                ReturnBook();
            }
            else if (step == "user_history")
            {
                ShowBookInformation();
            }
            else
            {
                MessageBox.Show("Произошла непредвиденная ошибка");
            }
        }

        private void ReturnBook()
        {
            MessageBox.Show("Книга возвращена! Спасибо!");
        }

        private void ShowBookInformation()
        {
            MessageBox.Show("Очень интересная книга. правда...");
        }
    }
}
