
using System.Runtime.CompilerServices;

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
                RadioButton button = new() { 
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
            MessageBox.Show("Отправка сообщения на почту админа!");

            //string title = "";
            //string fio = "";
            //string publication = "";
            //if (_isGenre)
            //{
            //    title = DataGridUser.SelectedRows[0].Cells[1].Value.ToString() ?? "";
            //    fio = DataGridUser.SelectedRows[0].Cells[2].Value.ToString() ?? "";
            //    publication = DataGridUser.SelectedRows[0].Cells[3].Value.ToString() ?? "";
            //}
            //else
            //{
            //    title = DataGridUser.SelectedRows[0].Cells[0].Value.ToString() ?? "";
            //    fio = DataGridUser.SelectedRows[0].Cells[1].Value.ToString() ?? "";
            //    publication = DataGridUser.SelectedRows[0].Cells[2].Value.ToString() ?? "";
            //}
            //string query = "INSERT INTO library (book, reader, take_date, return_date, taken) " +
            //    "SELECT DISTINCT books.book_id, readers.reader_id, DATE(), DateAdd('d', 14, DATE()), true " +
            //    $"FROM books, readers WHERE books.title = '{title}' " +
            //    $"AND books.publication_year = {Convert.ToInt32(publication)} AND readers.reader_name = '{name}'";

            //OleDbCommand command = new OleDbCommand(query, _connection);
            //command.ExecuteNonQuery();

            //DataGridUser.Rows.RemoveAt(DataGridUser.SelectedRows[0].Index);

        }
    }
}
