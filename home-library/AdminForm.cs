
namespace home_library
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();

            if (Logic.IsGenre)
                groupBox1.Controls.Add(new RadioButton() { Name = "genre_radioBtn", Text = "Жанр" });
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
            string action = Change.Text.ToLower();

            AdminFormStep2 adminFormStep2 = new(state, action);
            adminFormStep2.ShowDialog();
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        { }

        private void TakeAppliesBtn_Click(object sender, EventArgs e)
        {
            AdminHistory adminHistory = new("take_applies");
            adminHistory.ShowDialog();
        }

        private void HistoryBtn_Click_1(object sender, EventArgs e)
        {
            AdminHistory adminHistory = new("history");
            adminHistory.ShowDialog();
        }

        private void DeptBtn_Click(object sender, EventArgs e)
        {
            AdminHistory adminHistory = new("dept");
            adminHistory.ShowDialog();
        }
    }
}
