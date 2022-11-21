using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace home_library
{
    public partial class UserForm : Form
    {
        // private static readonly string _connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=DB.mdb;";
        private static readonly string _connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=DB.mdb;";
        private readonly OleDbConnection _connection;
        public string name;
        public UserForm(string name)
        {
            InitializeComponent();

            this.name = name;

            // открываем соединение с бд
            _connection = new OleDbConnection(_connectString);
            _connection.Open();

            if (CheckGenre())
            {
                DataGridUser.Columns.Add("column4", "Жанр");
            }
            else
            {
                label2.Visible = false;
                radioButton1.Visible = false;
            }


            updateStudents();
        }

        private void updateStudents(string q = "SELECT DISTINCT books.genre, books.title, authors.fio, books.publication_year " +
                                                "FROM books, authors, library " +
                                                "WHERE books.author = authors.author_id AND library.book = books.book_id AND library.taken = false")
        {
            string query = q;
            OleDbCommand command = new OleDbCommand(query, _connection);
            OleDbDataReader reader = command.ExecuteReader();

            DataGridUser.Rows.Clear();

            while (reader.Read())
            {
                var genre = reader[0] ?? "";
                var name = reader[1];
                var author = reader[2];
                var year = reader[3];
                if (CheckGenre()) DataGridUser.Rows.Add(genre, name, author, year);
                else DataGridUser.Rows.Add(name, author, year);
            }

            reader.Close();
        }

        private void UserBooks_Click(object sender, EventArgs e)
        {
            UserForm2 usform2 = new(name);
            usform2.ShowDialog();
        }

        private void UserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _connection.Close();
            DataGridUser.Columns.Remove("column4");
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

        private void ShowHistory_Click(object sender, EventArgs e)
        {
            UserForm3 usform3 = new(name);
            usform3.ShowDialog();
        }

        private void GetBook_Click(object sender, EventArgs e)
        {
            string title = "";
            string fio = "";
            string publication = "";
            if (CheckGenre())
            {
                title = DataGridUser.SelectedRows[0].Cells[1].Value.ToString() ?? "";
                fio = DataGridUser.SelectedRows[0].Cells[2].Value.ToString() ?? "";
                publication = DataGridUser.SelectedRows[0].Cells[3].Value.ToString() ?? "";
            }
            else
            {
                title = DataGridUser.SelectedRows[0].Cells[0].Value.ToString() ?? "";
                fio = DataGridUser.SelectedRows[0].Cells[1].Value.ToString() ?? "";
                publication = DataGridUser.SelectedRows[0].Cells[2].Value.ToString() ?? "";
            }
            string query = "INSERT INTO library (book, reader, return_date, taken) SELECT DISTINCT books.book_id, readers.reader_id, DateAdd('d', 14, DATE()), true " +
                $"FROM books, readers WHERE books.title = '{title}' AND books.publication_year = {Convert.ToInt32(publication)} AND readers.reader_name = '{name}'";
            
            OleDbCommand command = new OleDbCommand(query, _connection);
            command.ExecuteNonQuery();

            DataGridUser.Rows.RemoveAt(DataGridUser.SelectedRows[0].Index);
        }
    }
}
