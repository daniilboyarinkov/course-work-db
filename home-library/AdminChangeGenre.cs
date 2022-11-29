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
    public partial class AdminChangeGenre : Form
    {
        private readonly OleDbConnection _connection;
        public AdminChangeGenre(OleDbConnection connect)
        {
            InitializeComponent();
            _connection = connect;

            updateStudents();
        }

        private void Save_Click(object sender, EventArgs e)
        {

        }
        private void updateStudents(string q = "SELECT genres.genre_name " +
            "FROM genres")
        {
            string query = q;
            OleDbCommand command = new OleDbCommand(query, _connection);
            OleDbDataReader reader = command.ExecuteReader();

            DataGridUser.Rows.Clear();

            while (reader.Read())
            {                
                var genre = reader[0];                
                DataGridUser.Rows.Add(genre);
            }
            reader.Close();
        }

        private void DataGridUser_SelectionChanged(object sender, EventArgs e)
        {
            textBox1.Text = DataGridUser.SelectedRows[0].Cells[0].Value.ToString() ?? "";
        }
    }
}
