using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace home_library
{
    public partial class UserForm2 : Form
    {
        private readonly OleDbConnection _connection;
        public string name;
        public UserForm2(string name, OleDbConnection connect)
        {
            InitializeComponent();

            this.name = name;

            _connection = connect;

            if (CheckGenre())
            {
                DataGridUser.Columns.Add("column4", "Жанр");
                updateStudents("SELECT books.title, authors.fio, books.publication_year, library.take_date, library.return_date, books.genre " +
                               "FROM readers " +
                               "INNER JOIN ((authors " +
                               "INNER JOIN books ON authors.author_id = books.author) " +
                               "INNER JOIN library ON books.book_id = library.book) " +
                               "ON readers.reader_id = library.reader " +
                               "WHERE (((library.taken)=True)) AND (readers.reader_name) = ");
            }
            else
            {
                updateStudents();
            }            
        }
        private void updateStudents(string q = "SELECT books.title, authors.fio, books.publication_year, library.take_date, library.return_date " +
                                               "FROM readers " +
                                               "INNER JOIN ((authors " +
                                               "INNER JOIN books ON authors.author_id = books.author) " +
                                               "INNER JOIN library ON books.book_id = library.book) " +
                                               "ON readers.reader_id = library.reader " +
                                               "WHERE (((library.taken)=True)) AND (readers.reader_name) = ")
        {

            string query = q + $"'{name}';";
            OleDbCommand command = new OleDbCommand(query, _connection);
            OleDbDataReader reader = command.ExecuteReader();

            DataGridUser.Rows.Clear();

            while (reader.Read())
            {
                string genre = "";
                if (reader.FieldCount == 6)
                {
                    genre = reader[5].ToString() ?? "";
                }

                var name = reader[0];
                var author = reader[1];
                var year = reader[2];
                var take = Convert.ToDateTime(reader[3]).ToShortDateString();
                var returnn = Convert.ToDateTime(reader[4]).ToShortDateString();
                if (CheckGenre()) DataGridUser.Rows.Add(name, author, year, take, returnn, genre);
                else DataGridUser.Rows.Add(name, author, year, take, returnn);
            }
            reader.Close();
        }

        public bool CheckGenre()
        {
            try
            {
                string query = "SELECT * FROM genres";
                OleDbCommand command = new OleDbCommand(query, _connection);
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        private void GetBackBook_Click(object sender, EventArgs e)
        {
            string title = "";
            string fio = "";
            string publication = "";
            string[] take_date = new string[3];
            if (CheckGenre())
            {
                title = DataGridUser.SelectedRows[0].Cells[1].Value.ToString() ?? "";
                fio = DataGridUser.SelectedRows[0].Cells[2].Value.ToString() ?? "";
                publication = DataGridUser.SelectedRows[0].Cells[3].Value.ToString() ?? "";
                take_date = Convert.ToDateTime(DataGridUser.SelectedRows[0].Cells[4].Value.ToString()).ToShortDateString().Split('.');

            }
            else
            {
                title = DataGridUser.SelectedRows[0].Cells[0].Value.ToString() ?? "";
                fio = DataGridUser.SelectedRows[0].Cells[1].Value.ToString() ?? "";
                publication = DataGridUser.SelectedRows[0].Cells[2].Value.ToString() ?? "";
                take_date = Convert.ToDateTime(DataGridUser.SelectedRows[0].Cells[3].Value.ToString()).ToShortDateString().Split('.');
            }
            string query = $"UPDATE library, books, authors SET library.taken = false, library.return_date = DATE() " +
                $"WHERE books.title = '{title}' " +
                $"AND books.publication_year = {Convert.ToInt32(publication)} " +
                $"AND authors.fio = '{fio}' " +
                $"AND library.take_date = #" + take_date[2] + "/" + take_date[1] + "/" + take_date[0] + "# " +
                $"AND books.book_id = library.book " +
                $"AND books.author = authors.author_id";
            DataGridUser.Rows.RemoveAt(DataGridUser.SelectedRows[0].Index);
            OleDbCommand command = new OleDbCommand(query, _connection);
            command.ExecuteNonQuery();
        }
    }
}
