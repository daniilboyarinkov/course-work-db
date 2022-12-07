
using home_library.Static;

namespace home_library
{
    public partial class UserForm : Form
    {
        private readonly string[] authors;
        private readonly string[] genres;
        public UserForm(string name)
        {
            InitializeComponent();

            User.User.Username = name;

            UpdateBooks();
            authors = Logic.GetAllAuthors();
            AddRadioButtonsFilters(authors);

            genres = Logic.GetAllGenres();
            filterByGenre.Items.AddRange((new string[] { "Все жанры" }).Concat(genres.ToArray()).ToArray());
            filterByGenre.SelectedValueChanged += (o, args) =>
            {
                UpdateBooks("Все авторы", filterByGenre.Text);
            };

            CheckDate();
        }

        private static void CheckDate()
        {
            CheckUserBirthDay();
            CheckAuthorAnniversary();
            CheckDeptBooks();
        }

        // проверка если у пользоваителя сегодня др
        private static void CheckUserBirthDay()
        {
            string query = Queries.CheckUsersBirthDay(User.User.Username);
            List<List<string>> rows = Logic.ExecuteQuery(query);
            if (rows.Count == 0 || rows[0].Count == 0) return;

            MessageBox.Show($"Сегодня {DateTime.Now:dd/MM/yyyy}. \n\n С днём рождения, {User.User.Username}!", "С днем рождения!");
        }
        // авторы у которых сегодня день рождения
        private static void CheckAuthorAnniversary()
        {
            string query = Queries.GetBirthdayAuthors();
            List<List<string>> rows = Logic.ExecuteQuery(query);
            if (rows.Count == 0 || rows[0].Count == 0) return;

            foreach (var row in rows) MessageBox.Show($"Сегодня день рождения у {row[0]}. ", $"День рождения {row[0]}!!!");
        }
        // проверка просрочки
        private static void CheckDeptBooks()
        {
            string query = Queries.GetUserDeptedBooks(User.User.Username);
            List<List<string>> rows = Logic.ExecuteQuery(query);
            if (rows.Count == 0 || rows[0].Count == 0) return;

            foreach (var row in rows) MessageBox.Show($"Пожалуйста, верните книгу {row[0]} как можно раньше.\nСрок возврата книги истек...", "Просроченные книги!");
        }
        private void AddRadioButtonsFilters(string[] authors)
        {
            // add change handlers on every btn
            AllAuthorsRadioBtn.CheckedChanged += (o, args) =>
            {
                if (AllAuthorsRadioBtn.Checked)
                    UpdateBooks(AllAuthorsRadioBtn.Text);
            };

            int i = 0;
            foreach (string author in authors)
            {
                RadioButton button = new()
                {
                    Text = author,
                    Name = author,
                    Location = new Point(7, 25 * i++ + 45),
                    Width = 200
                };
                button.CheckedChanged += (o, args) =>
                {
                    if (button.Checked)
                        UpdateBooks(button.Text);
                };

                AuthorFilterBox.Controls.Add(button);
            }
        }

        private void UserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void UpdateBooks(string authorFilter = "Все авторы", string genreFilter = "Все жанры")
        {
            string query = Queries.GetAllAvailableBooks();

            if (authorFilter != "Все авторы")
                query = Queries.GetAllAvailableBooksByAuthor(authorFilter);
            if (genreFilter != "Все жанры")
                query = Queries.GetAllAvailableBooksByGenre(genreFilter);

            DataGridUser.Rows.Clear();

            Logic.ExecuteQuery(query)
               .ForEach(row => DataGridUser.Rows.Add(row.ToArray()));
        }

        private void UserBooks_Click(object sender, EventArgs e)
        {
            UserFormStep2 userFormStep2 = new("user_books");
            userFormStep2.ShowDialog();
            // возвращаемся - получаем актуальные данные
            UpdateBooks();
        }
        private void ShowHistory_Click(object sender, EventArgs e)
        {
            UserFormStep2 userFormStep2 = new("user_history");
            userFormStep2.ShowDialog();
            // возвращаемся - получаем актуальные данные
            UpdateBooks();
        }


        private void GetBook_Click(object sender, EventArgs e)
        {
            var row = DataGridUser.SelectedRows[0];

            string title = row.Cells[0].Value?.ToString() ?? "";
            string author = row.Cells[1].Value?.ToString() ?? "";
            string publication_year = row.Cells[2].Value?.ToString() ?? "";

            if (title.Length == 0 && author.Length == 0 && publication_year.Length == 0)
            {
                MessageBox.Show("Выберите книгу...", "Error!");
                return;
            }

            string message = $"Добрый день. \n\nПользователь <b>{User.User.Username}</b> отправил завку на взятие книги " +
                $"{title} {author} {publication_year}г. \n\nРассимотрите заявку в ближайше возможное время. \nСпасибо.";

            try
            {
                //Logic.SendMail(message, "Заявка на взятие книги");

                string query = Queries.AddUserTakeApply(User.User.Username, title);
                Logic.ExecuteNonQuery(query);

                MessageBox.Show("Ваша заявка на взятие книги успешно отправлена! Ждите одобрения администратором.", "Успех!");
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так. Попробуйте снова позже.", "Error!");
            }
        }
    }
}
