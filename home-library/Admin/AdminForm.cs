
using home_library.Admin;
using home_library.Static;

namespace home_library
{
    public partial class AdminForm : Form
    {
        private string[]? tables;
        public AdminForm()
        {
            InitializeComponent();

            NumOfColumnsCombobox.Items.AddRange(new string[] { "1", "2", "3", "4", "5" });

            UpdateTableName();
        }

        private void UpdateTableName()
        {
            AllTablesCombobx.Items.Clear();
            tables = Logic.GetAllTables();
            AllTablesCombobx.Items.AddRange(tables);
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
            AdminHistoryForm adminHistory = new("take_applies");
            adminHistory.ShowDialog();
        }

        private void HistoryBtn_Click_1(object sender, EventArgs e)
        {
            AdminHistoryForm adminHistory = new("history");
            adminHistory.ShowDialog();
        }

        private void DeptBtn_Click(object sender, EventArgs e)
        {
            AdminHistoryForm adminHistory = new("dept");
            adminHistory.ShowDialog();
        }

        private void AddTableButton_Click(object sender, EventArgs e)
        {
            string table_name = TableNameTextbox.Text;
            string num_of_cols = NumOfColumnsCombobox.Text;

            if (string.IsNullOrEmpty(table_name))
            {
                MessageBox.Show("Вы забыли ввести имя таблицы...", "Error!");
                return;
            }
            if (string.IsNullOrEmpty(num_of_cols))
            {
                MessageBox.Show("Вы забыли количество столбцов...", "Error!");
                return;
            }

            AdminAddTableForm newForm = new(table_name, int.Parse(num_of_cols));
            newForm.ShowDialog();
            UpdateTableName();
        }

        private void DeleteTableBtn_Click(object sender, EventArgs e)
        {
            string table_name = AllTablesCombobx.Text;

            if (string.IsNullOrEmpty(table_name))
            {
                MessageBox.Show("Выберите таблицу!", "Error!");
                return;
            }

            DialogResult dialogResult = MessageBox.Show($"Вы уверены, что хотите удалить таблицу {table_name}?", "Подтверждение удаления", MessageBoxButtons.YesNo);
            if (dialogResult != DialogResult.Yes) return;
            ClearAllRelations(table_name);

            string query = Queries.DropTable(table_name);
            try
            {
                Logic.ExecuteNonQuery(query);
                MessageBox.Show($"Таблица {table_name} успешна удалена.", "Успех!");
                UpdateTableName();
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так", "Error!");
            }
            finally
            {
                AllTablesCombobx.Text = "";
            }
        }

        private void ClearAllRelations(string table_name)
        {
            if (tables is null) return;
            foreach (string table in tables)
            {
                if (table == table_name) continue;
                string query1 = Queries.RemoveRelatedField(table, table_name);
                string query2 = Queries.RemoveRelation(table, table_name);

                try
                {
                    Logic.ExecuteNonQuery(query2);
                }
                catch
                {
                }
                try
                {
                    Logic.ExecuteNonQuery(query1);
                }
                catch
                {
                }
            }
        }
    }
}
