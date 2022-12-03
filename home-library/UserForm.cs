
using System.Data.OleDb;

namespace home_library
{
    public partial class UserForm : Form
    {
        private readonly string[] authors;
        public UserForm(string name)
        {
            InitializeComponent();

            UserLogic.Username = name;

            UpdateBooks();
            authors = GetAllAuthors();
            AddRadioButtonsFilters(authors);

            CheckDate();
        }

        private void CheckDate()
        {
            CheckUserBirthDay();
            CheckAuthorAnniversary();
            CheckDeptBooks();
        }

        // проверка если у пользоваителя сегодня др
        private void CheckUserBirthDay() 
        {
            string query = Queries.CheckUsersBirthDay(UserLogic.Username);
            List<List<string>> rows = Logic.ExecuteQuery(query);
            if (rows.Count == 0 || rows[0].Count == 0) return;

            MessageBox.Show("С днем рождения!");
        }
        // авторы у которых сегодня день рождения
        private void CheckAuthorAnniversary() 
        {
            string query = Queries.GetBirthdayAuthors();
            List<List<string>> rows = Logic.ExecuteQuery(query);
            if (rows.Count == 0 || rows[0].Count == 0) return;

            foreach (var row in rows) MessageBox.Show(row[0]);
        }
        // проверка просрочки
        private void CheckDeptBooks()
        {
            string query = Queries.GetUserDeptedBooks(UserLogic.Username);
            List<List<string>> rows = Logic.ExecuteQuery(query);
            if (rows.Count == 0 || rows[0].Count == 0) return;

            foreach (var row in rows) MessageBox.Show(row[0]);
        }

        private string[] GetAllAuthors()
        {
            string query = Queries.GetAllAuthors();
            List<List<string>> data = Logic.ExecuteQuery(query);
            return data.Select(d => d[0]).ToArray();
        }
        private void AddRadioButtonsFilters(string[] authors)
        {
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
                    Location = new Point(7, 25 * i++ + 45)
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
            if (Logic.IsGenre) DataGridUser.Columns.Remove("column4");
        }

        private void UpdateBooks(string authorFilter = "Все авторы")
        {
            if (Logic.IsGenre) DataGridUser.Columns.Add("column4", "Жанр");

            string query = Queries.GetAllAvailableBooks(Logic.IsGenre);
            if (authorFilter != "Все авторы")
            {
                query = Queries.GetAllAvailableBooksByAuthor(Logic.IsGenre, authorFilter);
            }

            DataGridUser.Rows.Clear();
            List<List<string>> rows = Logic.ExecuteQuery(query);
            rows.ForEach(row => DataGridUser.Rows.Add(row.ToArray()));
        }

        private void UserBooks_Click(object sender, EventArgs e)
        {
            UserFormStep2 userFormStep2 = new("user_books");
            userFormStep2.ShowDialog();
        }
        private void ShowHistory_Click(object sender, EventArgs e)
        {
            UserFormStep2 userFormStep2 = new("user_history");
            userFormStep2.ShowDialog();
        }


        private void GetBook_Click(object sender, EventArgs e)
        {
            string title = DataGridUser.SelectedRows[0].Cells[0].Value.ToString() ?? "";
            string author = DataGridUser.SelectedRows[0].Cells[1].Value.ToString() ?? "";
            string publication_year = DataGridUser.SelectedRows[0].Cells[2].Value.ToString() ?? "";

            string message = $"Добрый день. Пользователь {UserLogic.Username} отправил завку на взятие книги " +
                $"{title} {author} {publication_year}г. Рассимотрите заявку в ближайше возможное время. Спасибо.";

            //try
            //{
                Logic.SendMail(message, "Заявка на взятие книги");

                string query = Queries.AddUserTakeApply(UserLogic.Username, title);
                OleDbCommand command = new(query, Logic.Connection);
                command.ExecuteNonQuery();

                MessageBox.Show("Ваша заявка на взятие книги успешно отправлена! Ждите одобрения администратором.", "Успех!");
            //}
            //catch
            //{
            //    MessageBox.Show("Что-то пошло не так. Попробуйте снова позже.", "Error!");
            //}
        }
    }
}
