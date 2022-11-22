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
        //private static readonly string _connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=DB.mdb;";
        private readonly OleDbConnection _connection;
        public string name;
        public UserForm3(string name, OleDbConnection connect)
        {
            InitializeComponent();

            this.name = name;

            // открываем соединение с бд
            _connection = connect;

            if (CheckGenre())
            {
                DataGridUser.Columns.Add("column4", "Жанр");
            };


            updateStudents();
        }
        //private void updateStudents(string q = "SELECT books.genre, books.title, authors.fio, books.publication_year, library.take_date, library.return_date " +
        //                                        "FROM books, authors, library, readers " +
        //                                        "WHERE library.book = books.book_id " +
        //                                        "AND books.author = authors.author_id " +
        //                                        "AND library.reader = readers.reader_id " +
        //                                        "AND library.taken = false " +
        //                                        "AND readers.reader_name = ")
        private void updateStudents(string q = "SELECT books.title, authors.fio, books.publication_year, library.take_date, library.taken " +
            "FROM readers INNER JOIN ((authors INNER JOIN books ON authors.author_id = books.author) " +
            "INNER JOIN library ON books.book_id = library.book) ON readers.reader_id = library.reader " +
            "WHERE (((readers.reader_name)= ")
        {

            string query = q + $"'{name}')) ORDER BY library.take_date;";
            OleDbCommand command = new OleDbCommand(query, _connection);
            OleDbDataReader reader = command.ExecuteReader();

            DataGridUser.Rows.Clear();

            while (reader.Read())
            {
                var name = reader[0];
                var author = reader[1];
                var year = reader[2];
                var take = Convert.ToDateTime(reader[3]).ToShortDateString();
                string returned = Convert.ToBoolean(reader[4]) == true ? ("Нет") : ("Да") ;
                if (CheckGenre()) DataGridUser.Rows.Add(name, author, year, take, returned);
                else DataGridUser.Rows.Add(name, author, year, take, returned);
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
    }
}
