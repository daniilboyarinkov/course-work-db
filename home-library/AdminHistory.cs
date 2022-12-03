

namespace home_library
{
    public partial class AdminHistory : Form
    {
        private readonly string step = string.Empty;
        public AdminHistory(string step)
        {
            InitializeComponent();
            this.step = step;

            DataGridUser.Columns.Add("title", "Книга");
            DataGridUser.Columns.Add("reader_name", "Пользователь");

            if (step == "history")
            {
                Title.Text = "История";

                SubmitBtn.Visible = false;
                RejectBtn.Visible = false;

                DataGridUser.Columns.Add("take_date", "Дата взятия");
                DataGridUser.Columns.Add("return_date", "Дата возвращения");
            }
            else if (step == "take_applies")
            {
                Title.Text = "Заявки на взятие книги";

                DataGridUser.Columns.Add("apply_date", "Дата заявки");
            }

            AuthorFilter.Items.AddRange((new string[] { "Все авторы" }).Concat(GetAllAuthors()).ToArray());

            GenreFilter.Items.AddRange((new string[] { "Все жанры" }).Concat(GetAllGenres()).ToArray());

            UserFilter.Items.AddRange((new string[] { "Все читатели" }).Concat(GetAllReaders()).ToArray());

            UpdateBooks();
        }
        private void UpdateBooks()
        {
            string query = string.Empty;

            if (step == "history")
            {
                query = Queries.GetAllHistory();
            }
            else if (step == "take_applies")
            {
                query = Queries.GetAllApplies();
            }
            else
            {
                MessageBox.Show("Произошла непредвиденная ошибка");
                return;
            }

            DataGridUser.Rows.Clear();
            List<List<string>> rows = Logic.ExecuteQuery(query);
            rows.ForEach(row => DataGridUser.Rows.Add(row.ToArray()));
        }

        private string[] GetAllAuthors()
        {
            string query = Queries.GetAllAuthors();
            List<List<string>> data = Logic.ExecuteQuery(query);
            return data.Select(d => d[0]).ToArray();
        }private string[] GetAllGenres()
        {
            string query = Queries.GetAllGenres();
            List<List<string>> data = Logic.ExecuteQuery(query);
            return data.Select(d => d[0]).ToArray();
        }private string[] GetAllReaders()
        {
            string query = Queries.GetAllReaders();
            List<List<string>> data = Logic.ExecuteQuery(query);
            return data.Select(d => d[0]).ToArray();
        }

        private void AuthorFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            UserFilter.Text = "";
            GenreFilter.Text = "";

            string query = string.Empty;

            if (step == "history")
            {
                if (AuthorFilter.Text == "Все авторы") query = Queries.GetAllHistory();
                else query = Queries.GetAllHistoryByAuthor(AuthorFilter.Text.Trim());
            }
            else if (step == "take_applies")
            {
                if (AuthorFilter.Text == "Все авторы") query = Queries.GetAllApplies();
                else query = Queries.GetAllAppliesByAuthor(AuthorFilter.Text.Trim());
            }
            else
            {
                MessageBox.Show("Произошла непредвиденная ошибка");
                return;
            }

            DataGridUser.Rows.Clear();
            List<List<string>> rows = Logic.ExecuteQuery(query);
            rows.ForEach(row => DataGridUser.Rows.Add(row.ToArray()));
        }

        private void GenreFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            UserFilter.Text = "";
            AuthorFilter.Text = "";

            string query = string.Empty;

            if (step == "history")
            {
                if (GenreFilter.Text == "Все жанры") query = Queries.GetAllHistory();
                else query = Queries.GetAllHistoryByGenre(GenreFilter.Text.Trim());
            }
            else if (step == "take_applies")
            {
                if (GenreFilter.Text == "Все жанры") query = Queries.GetAllHistory();
                else query = Queries.GetAllAppliesByGenre(GenreFilter.Text.Trim());
            }
            else
            {
                MessageBox.Show("Произошла непредвиденная ошибка");
                return;
            }

            DataGridUser.Rows.Clear();
            List<List<string>> rows = Logic.ExecuteQuery(query);
            rows.ForEach(row => DataGridUser.Rows.Add(row.ToArray()));
        }

        private void UserFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            GenreFilter.Text = "";
            AuthorFilter.Text = "";

            string query = string.Empty;

            if (step == "history")
            {
                if (UserFilter.Text == "Все читатели") query = Queries.GetAllHistory();
                else query = Queries.GetAllHistoryByReader(UserFilter.Text.Trim());
            }
            else if (step == "take_applies")
            {
                if (UserFilter.Text == "Все читатели") query = Queries.GetAllHistory();
                else query = Queries.GetAlAppliesByReader(UserFilter.Text.Trim());
            }
            else
            {
                MessageBox.Show("Произошла непредвиденная ошибка");
                return;
            }

            DataGridUser.Rows.Clear();
            List<List<string>> rows = Logic.ExecuteQuery(query);
            rows.ForEach(row => DataGridUser.Rows.Add(row.ToArray()));
        }
    }
}
