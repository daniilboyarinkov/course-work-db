using System.Data.OleDb;

namespace home_library
{  

    public partial class StartForm : Form
    {

        // private static readonly string _connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=DB.mdb;";
        private static readonly string _connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=DB.mdb;";
        private readonly OleDbConnection _connection;

        public StartForm()
        {
            InitializeComponent();

            // открываем соединение с бд
            _connection = new OleDbConnection(_connectString);
            _connection.Open();
        }

        private void StartForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // закрываем соединение с бд
            _connection.Close();
        }

        private void UserButton_Click(object sender, EventArgs e)
        {
            string query = "SELECT reader_name FROM readers";
            OleDbCommand command = new OleDbCommand(query, _connection);
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                if (UserName.Text == reader[0].ToString())
                {
                    UserForm userForm = new(UserName.Text);
                    // переводим основное окно в состояние невидимости
                    this.Visible = false;
                    userForm.ShowDialog();
                    // по закрытию дочернего окна закрываем и основное
                    Close();
                }
            }

            reader.Close();

            
        }

        private void AdminButton_Click(object sender, EventArgs e)
        {
            AdminForm adminForm = new();
            // переводим основное окно в состояние невидимости
            this.Visible = false;
            adminForm.ShowDialog();
            // по закрытию дочернего окна закрываем и основное
            Close();
        }
        
    }
}