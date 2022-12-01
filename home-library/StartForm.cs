using System.Data.OleDb;

namespace home_library
{  

    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();

            // открываем соединение с бд
            Logic.Connection.Open();
        }

        private void StartForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // закрываем соединение с бд
            Logic.Connection.Close();
        }

        private void UserButton_Click(object sender, EventArgs e)
        {
            string query = "SELECT reader_name FROM readers";
            OleDbCommand command = new(query, Logic.Connection);
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                if (UserName.Text == reader[0].ToString())
                {
                    UserForm userForm = new(UserName.Text);
                    // переводим основное окно в состояние невидимости
                    Visible = false;
                    userForm.ShowDialog();
                    Visible = true;
                }
            }
            reader.Close();
        }

        private void AdminButton_Click(object sender, EventArgs e)
        {
            AdminForm adminForm = new(Logic.Connection);
            // переводим основное окно в состояние невидимости
            Visible = false;
            adminForm.ShowDialog();
            // по закрытию дочернего окна закрываем и основное
            Visible=true;
        }
        
    }
}