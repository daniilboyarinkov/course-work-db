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
    public partial class AdminChangeUser : Form
    {
        private readonly OleDbConnection _connection;
        public AdminChangeUser(OleDbConnection connect)
        {
            InitializeComponent();
            _connection= connect;

            updateStudents();
        }

        private void Save_Click(object sender, EventArgs e)
        {

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

        private void DataGridUser_SelectionChanged(object sender, EventArgs e)
        {
            if (CheckGenre())
            {
                textBox1.Text = DataGridUser.SelectedRows[0].Cells[0].Value.ToString() ?? "";
                textBox2.Text = DataGridUser.SelectedRows[0].Cells[1].Value.ToString() ?? "";
                textBox3.Text = DataGridUser.SelectedRows[0].Cells[2].Value.ToString() ?? "";

            }
            else
            {
                textBox1.Text = DataGridUser.SelectedRows[0].Cells[0].Value.ToString() ?? "";
                textBox2.Text = DataGridUser.SelectedRows[0].Cells[1].Value.ToString() ?? "";
                textBox3.Text = DataGridUser.SelectedRows[0].Cells[2].Value.ToString() ?? "";
            }
        }
    }
}
