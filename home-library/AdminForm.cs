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
    public partial class AdminForm : Form
    {
        private readonly OleDbConnection _connection;
        public AdminForm(OleDbConnection connect)
        {
            InitializeComponent(); 
            _connection = connect;
        }

        private void Add_Click(object sender, EventArgs e)
        {
            AdminFormGenre genre;
            var CheckedButton = groupBox1.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            switch (CheckedButton?.Text)
            {
                case "Жанр":
                    genre = new AdminFormGenre(_connection);
                    break;
                case "Пользователь":
                    break;
            }
        }
    }
}
