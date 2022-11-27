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
    public partial class AdminFormUsers : Form
    {
        private readonly OleDbConnection _connection;
        public AdminFormUsers(OleDbConnection connect, string function)
        {
            InitializeComponent();
            _connection = connect;
            if(function == "Добавить")
            {
                this.Delete.Visible = false;
                this.Add.Visible = true;
            }
            else
            {
                this.Delete.Visible = true;
                this.Add.Visible = false;
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            string query = $"DELETE FROM readers WHERE reader_name = '{textBox1.Text}'";
            OleDbCommand command = new OleDbCommand(query, _connection);
            command.ExecuteNonQuery();
            this.Close();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            string query = $"INSERT INTO readers (reader_name, birth_date) VALUES ('{textBox1.Text}', '{textBox5.Text + "." + textBox6.Text + "." + textBox3.Text}')";
            OleDbCommand command = new OleDbCommand(query, _connection);
            command.ExecuteNonQuery();
            this.Close();
        }
    }
}
