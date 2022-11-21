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
    public partial class UserForm3: Form
    {
        // private static readonly string _connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=DB.mdb;";
        private static readonly string _connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=DB.mdb;";
        private readonly OleDbConnection _connection;
        public string name;
        public UserForm3(string name)
        {
            InitializeComponent();

            this.name = name;

            // открываем соединение с бд
            _connection = new OleDbConnection(_connectString);
            _connection.Open();

            if (CheckGenre())
            {
                DataGridUser.Columns.Add("column4", "Жанр");
            };


            updateStudents();
        }
        private void updateStudents(string q = "SELECT books.genre, books.title, authors.fio, books.publication_year, library.take_date, library.return_date " +
                                                "FROM books, authors, library, readers " +
                                                "WHERE library.book = books.book_id AND books.author = authors.author_id AND library.reader = readers.reader_id AND library.taken = false AND readers.reader_name = ")
        {

            string query = q + $"'{name}'";
            OleDbCommand command = new OleDbCommand(query, _connection);
            OleDbDataReader reader = command.ExecuteReader();

            DataGridUser.Rows.Clear();

            while (reader.Read())
            {
                var genre = reader[0] ?? "";
                var name = reader[1];
                var author = reader[2];
                var year = reader[3];
                var take = Convert.ToDateTime(reader[4]).ToShortDateString();
                var returnn = Convert.ToDateTime(reader[5]).ToShortDateString();
                if (CheckGenre()) DataGridUser.Rows.Add(genre, name, author, year, take, returnn);
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

        private void UserForm3_FormClosing(object sender, FormClosingEventArgs e)
        {
            _connection.Close();
        }
    }
}
