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
using System.Xml.Linq;

namespace home_library
{
    public partial class AdminFormGenre : Form
    {
        private readonly OleDbConnection _connection;
        public AdminFormGenre(OleDbConnection connect)
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
