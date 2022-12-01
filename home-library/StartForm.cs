using System.Data.OleDb;

namespace home_library
{  

    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();

            // ��������� ���������� � ��
            Logic.Connection.Open();
        }

        private void StartForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // ��������� ���������� � ��
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
                    // ��������� �������� ���� � ��������� �����������
                    Visible = false;
                    userForm.ShowDialog();
                    Visible = true;
                } 
                else
                {
                    MessageBox.Show($"��� ������������ � ������ {inputName}!");
                }
            }
            reader.Close();
        }

        private void AdminButton_Click(object sender, EventArgs e)
        {
            AdminForm adminForm = new();
            // ��������� �������� ���� � ��������� �����������
            Visible = false;
            adminForm.ShowDialog();
            // �� �������� ��������� ���� ��������� � ��������
            Visible=true;
        }
        
    }
}