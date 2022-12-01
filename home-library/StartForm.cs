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
            string inputName = UserName.Text.ToLower();

            string query = $"SELECT reader_name FROM readers WHERE reader_name=\"{inputName}\"";
            OleDbCommand command = new(query, Logic.Connection);
            OleDbDataReader reader = command.ExecuteReader();
            
            while (reader.Read())
            {
                if (inputName == reader[0].ToString()?.ToLower())
                {
                    UserForm userForm = new(inputName);
                    // переводим основное окно в состояние невидимости
                    Visible = false;
                    userForm.ShowDialog();
                    Visible = true;
                } 
                else
                {
                    MessageBox.Show($"Нет пользователя с именем {inputName}!");
                }
            }
            reader.Close();
        }

        private void AdminButton_Click(object sender, EventArgs e)
        {
            AdminForm adminForm = new();
            // переводим основное окно в состояние невидимости
            Visible = false;
            adminForm.ShowDialog();
            // по закрытию дочернего окна закрываем и основное
            Visible=true;
        }
        
    }
}