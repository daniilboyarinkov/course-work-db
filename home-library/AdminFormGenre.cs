using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Reflection.Metadata.BlobBuilder;

namespace home_library
{
    public partial class AdminFormGenre : Form
    {
        private readonly OleDbConnection _connection;
        public AdminFormGenre(OleDbConnection connect, string function)
        {
            InitializeComponent();
            _connection = connect;

            if (!CheckGenre())
            {
                string query = "ALTER TABLE books ADD COLUMN genre int";

                OleDbCommand command = new OleDbCommand(query, _connection);
                command.ExecuteNonQuery();

                query = "CREATE TABLE genres " +
                    "(genre_id COUNTER PRIMARY KEY, " +
                    "genre_name text NOT NULL)";

                command = new OleDbCommand(query, _connection);
                command.ExecuteNonQuery();

                query = "ALTER TABLE books " +
                    "ADD CONSTRAINT PriKey FOREIGN KEY (genre) " +
                    "REFERENCES genres (genre_id)";

                command = new OleDbCommand(query, _connection);
                command.ExecuteNonQuery();
            }

            if(function == "Добавить")
            {
                this.Add.Visible = true;
                this.Delete.Visible = false;
                this.DeleteAll.Visible = false;
            }
            else
            {
                this.Add.Visible = false;
                this.Delete.Visible = true;
                this.DeleteAll.Visible = true;
            }
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

        private void Delete_Click(object sender, EventArgs e)
        {
            string query = $"DELETE FROM genres WHERE genre_name = '{textBox1.Text}'";
            OleDbCommand command = new OleDbCommand(query, _connection);
            command.ExecuteNonQuery();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            string query = $"INSERT INTO genres (genre_name) VALUES ('{textBox1.Text}')";
            OleDbCommand command = new OleDbCommand(query, _connection);
            command.ExecuteNonQuery();
        }

        private void DeleteAll_Click(object sender, EventArgs e)
        {
            string query = "ALTER TABLE books DROP CONSTRAINT PriKey";

            OleDbCommand command = new OleDbCommand(query, _connection);
            command.ExecuteNonQuery();

            query = "DROP TABLE genres";

            command = new OleDbCommand(query, _connection);
            command.ExecuteNonQuery();

            query = "ALTER TABLE books DROP COLUMN genre";

            command = new OleDbCommand(query, _connection);
            command.ExecuteNonQuery();

            this.Close();
        }
    }
}
