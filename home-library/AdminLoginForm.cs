
using System.Data.Common;
using System.Data.OleDb;

namespace home_library
{
    public partial class AdminLoginForm : Form
    {
        public AdminLoginForm()
        {
            InitializeComponent();
        }

        private void EnterBtn_Click(object sender, EventArgs e)
        {
            string login = Login.Text;
            string password = Password.Text;

            if (!isLoginValid(login))
            {
                MessageBox.Show("Неверный логин или пароль!", "Ошибка!");
                return;
            }

            string dbHash = getDBHash(login);

            if (!AdminLogic.VerifyHashedPassword(dbHash, password))
            {
                MessageBox.Show("Неверный логин или пароль!", "Ошибка!");
                return;
            }

            //AdminForm adminForm = new();
            //adminForm.ShowDialog();
        }

        private bool isLoginValid(string login)
        {
            return true;
        }

        private string getDBHash(string login)
        {
            string query = Queries.GetAdminHash(login);

            List<List<string>> data = Logic.ExecuteQuery(query);

            return data[0][0];
        }
    }
}
