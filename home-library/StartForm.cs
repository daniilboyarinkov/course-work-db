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

            // ��������� ���������� � ��
            _connection = new OleDbConnection(_connectString);
            _connection.Open();
        }

        private void StartForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // ��������� ���������� � ��
            _connection.Close();
        }
        private void UserFormRedirect_Click(object sender, EventArgs e)
        {
            UserForm userForm = new();
            // ��������� �������� ���� � ��������� �����������
            this.Visible = false;
            userForm.ShowDialog();
            // �� �������� ��������� ���� ��������� � ��������
            Close();
        }

        private void AdminFormRedirect_Click(object sender, EventArgs e)
        {
            AdminForm adminForm = new();
            // ��������� �������� ���� � ��������� �����������
            this.Visible = false;
            adminForm.ShowDialog();
            // �� �������� ��������� ���� ��������� � ��������
            Close();
        }
    }
}