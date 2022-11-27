using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace home_library
{
    public partial class AdminFormUserGetReturn : Form
    {
        private readonly OleDbConnection _connection;
        public AdminFormUserGetReturn(OleDbConnection connect, string button)
        {
            InitializeComponent();
            _connection = connect;

            if(button == "Бронь")
            {
                this.UserGet.Visible = true;
                this.UserBack.Visible = false;
            }
            else
            {
                this.UserGet.Visible = false;
                this.UserBack.Visible = true;
            }


            if (CheckGenre())
            {
                DataGridUser.Columns.Add("column4", "Жанр");
                updateStudents("");
            }
            else
            {
                updateStudents();
            }
        }

        private void updateStudents(string q = "SELECT books.title, authors.fio, books.publication_year " +
            "FROM authors " +
            "INNER JOIN books " +
            "ON authors.author_id = books.author")
        {
            string query = q;
            OleDbCommand command = new OleDbCommand(query, _connection);
            OleDbDataReader reader = command.ExecuteReader();

            DataGridUser.Rows.Clear();

            while (reader.Read())
            {
                string genre = "";
                if (reader.FieldCount == 4)
                {
                    genre = reader[3].ToString() ?? "";
                }

                var name = reader[0];
                var author = reader[1];
                var year = reader[2];
                if (CheckGenre()) DataGridUser.Rows.Add(name, author, year, genre);
                else DataGridUser.Rows.Add(name, author, year);
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

        private void UserBack_Click(object sender, EventArgs e)
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

            }
            else
            {
                title = DataGridUser.SelectedRows[0].Cells[0].Value.ToString() ?? "";
                fio = DataGridUser.SelectedRows[0].Cells[1].Value.ToString() ?? "";
                publication = DataGridUser.SelectedRows[0].Cells[2].Value.ToString() ?? "";
            }
            string query = $"UPDATE library, books, authors SET library.taken = false, library.return_date = DATE() " +
                $"WHERE books.title = '{title}' " +
                $"AND books.publication_year = {Convert.ToInt32(publication)} " +
                $"AND authors.fio = '{fio}' " +
                $"AND books.book_id = library.book " +
                $"AND library.taken = true " +
                $"AND books.author = authors.author_id";
            DataGridUser.Rows.RemoveAt(DataGridUser.SelectedRows[0].Index);
            OleDbCommand command = new OleDbCommand(query, _connection);
            command.ExecuteNonQuery();
        }

        private void UserGet_Click(object sender, EventArgs e)
        {
            string title = "";
            string publication = "";
            if (CheckGenre())
            {
                title = DataGridUser.SelectedRows[0].Cells[1].Value.ToString() ?? "";
                publication = DataGridUser.SelectedRows[0].Cells[3].Value.ToString() ?? "";
            }
            else
            {
                title = DataGridUser.SelectedRows[0].Cells[0].Value.ToString() ?? "";
                publication = DataGridUser.SelectedRows[0].Cells[2].Value.ToString() ?? "";
            }
            string query = "INSERT INTO library (book, reader, take_date, return_date, taken) " +
                "SELECT DISTINCT books.book_id, readers.reader_id, DATE(), DateAdd('d', 14, DATE()), true " +
                $"FROM books, readers WHERE books.title = '{title}' " +
                $"AND books.publication_year = {Convert.ToInt32(publication)} AND readers.reader_name = '{textBox1.Text}'";

            OleDbCommand command = new OleDbCommand(query, _connection);
            command.ExecuteNonQuery();

            DataGridUser.Rows.RemoveAt(DataGridUser.SelectedRows[0].Index);
        }
    }
}
