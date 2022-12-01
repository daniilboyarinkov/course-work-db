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
            string query = "SELECT reader_name FROM readers";
            OleDbCommand command = new(query, Logic.Connection);
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                if (UserName.Text == reader[0].ToString())
                {
                    UserForm userForm = new(UserName.Text);
                    // ��������� �������� ���� � ��������� �����������
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
            // ��������� �������� ���� � ��������� �����������
            Visible = false;
            adminForm.ShowDialog();
            // �� �������� ��������� ���� ��������� � ��������
            Visible=true;
        }
        
    }
}