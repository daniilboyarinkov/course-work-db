
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
            string login = Login.Text.Trim();
            string password = Password.Text.Trim();

            if (!isLoginValid(login))
            {
                MessageBox.Show("Неверный логин или пароль!", "Ошибка!");
                return;
            }

            AdminLogic.Login = login;
            string dbHash = getDBHash(login);

            if (!AdminLogic.VerifyHashedPassword(dbHash, password))
            {
                MessageBox.Show("Неверный логин или пароль!", "Ошибка!");
                return;
            }

            AdminForm adminForm = new();
            Visible = false;
            adminForm.ShowDialog();
        }

        private bool isLoginValid(string login)
        {
            string query = Queries.GetAdmin(login);
            List<List<string>> data = Logic.ExecuteQuery(query);
            return data.Count > 0;
        }

        private string getDBHash(string login)
        {
            string query = Queries.GetAdminHash(login);
            List<List<string>> data = Logic.ExecuteQuery(query);
            return data[0][0];
        }

        private void RestorePassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string message = 
                "Добрый день. \n\nУ одного из администраторов системы был утерян доступ к приложению. \n" +
                "Восстановите безопасность приложения как можно раньше. \n\n<b>Спасибо!</b>";
            try
            {
                Logic.SendMail(message, "Восстановление доступа пользователей");
                MessageBox.Show("Ваша ситуация отправлена на почту главного администратора. \n\nОбратитесь к нему для восстановления доступа.", "Ну с кем не бывает...");
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так. попробуйте снова позже...", "Ошибка!");
            }
        }
    }
}
