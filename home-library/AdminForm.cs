using System.Data.OleDb;

namespace home_library
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private string GetRadioBtnText()
        {
            var CheckedButton = groupBox1.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            return CheckedButton?.Text?.ToLower() ?? "";
        }

        private void Add_Click(object sender, EventArgs e)
        {
            string state = GetRadioBtnText();
            string action = Add.Text.ToLower();

            AdminFormStep2 adminFormStep2 = new(state, action);
            adminFormStep2.ShowDialog();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            string state = GetRadioBtnText();
            string action = Delete.Text.ToLower();

            AdminFormStep2 adminFormStep2 = new(state, action);
            adminFormStep2.ShowDialog();
        }

        private void Change_Click(object sender, EventArgs e)
        {
            string state = GetRadioBtnText();
            string action = Delete.Text.ToLower();

            AdminFormStep2 adminFormStep2 = new(state, action);
            adminFormStep2.ShowDialog();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            string state = GetRadioBtnText();
            if (state == "книга")
            {
                //this.UserGet.Visible = true;
                //this.UserGetBack.Visible = true;
            }
            else
            {
                //this.UserGet.Visible = false;
                //this.UserGetBack.Visible = false;
            }
        }
    }
}
