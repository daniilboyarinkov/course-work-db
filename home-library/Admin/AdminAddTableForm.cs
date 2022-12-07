
using home_library.Static;

namespace home_library.Admin
{
    public partial class AdminAddTableForm : Form
    {
        private readonly string TableName;
        private readonly int NumOfColumns;
        private string[] tables;
        public AdminAddTableForm(string table_name, int num_of_columns)
        {
            InitializeComponent();

            TableName = table_name;
            NumOfColumns = num_of_columns;

            // add ID field
            groupBox1.Controls.Add(CreateControl<TextBox>($"ID", $"ID", 1));
            groupBox1.Controls[0].Enabled = false;
            groupBox1.Controls.Add(new ComboBox()
            {
                Name = "ID",
                Text = "counter(1, 1) NOT NULL Primary key",
                Location = new Point(250, 30),
                Width = 210,
                Enabled = false
            }
            );

            AddFieldsToGroupBox();
            tables = Logic.GetAllTables();
            SelectTable.Items.AddRange(tables);
        }

        private void AddFieldsToGroupBox()
        {
            for (int i = 0; i < NumOfColumns; i++)
            {
                groupBox1.Controls.Add(CreateControl<TextBox>($"field_{i + 1}", $"Поле {i + 1}", i + 2));
                groupBox1.Controls.Add(CreateComboBox($"type_{i + 1}", $"VARCHAR", i + 2));
            }
        }


        private static T CreateControl<T>(string name, string text, int i) where T : Control, new()
            => new()
            {
                Name = name,
                Text = text,
                Location = new Point(20, i * 30),
                Width = 210
            };

        private static ComboBox CreateComboBox(string name, string text, int i)
        {
            ComboBox cmbbx = new()
            {
                Name = name,
                Text = text,
                Location = new Point(250, i * 30),
                Width = 210
            };
            cmbbx.Items.AddRange(new string[] { "INT", "VARCHAR" });
            return cmbbx;
        }

        private void Add_Click(object sender, EventArgs e)
        {
            CreateTable();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string table_name = SelectTable.Text;

            if (!tables.Contains(TableName))
            {
                CreateTable();
                tables = tables.Append(TableName).ToArray();
            }

            if (string.IsNullOrEmpty(table_name))
            {
                MessageBox.Show("Выберите таблицу!", "Error!");
                return;
            }

            string query = Queries.AddRelatedField(table_name, TableName);
            try
            {
                Logic.ExecuteNonQuery(query);

                query = Queries.AddRelation(table_name, TableName);
                Logic.ExecuteNonQuery(query);

                MessageBox.Show($"Связь успешна установлена!", "Успех!");
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так", "Error!");
            }
            SelectTable.Text = "";
        }

        private void CreateTable()
        {
            if (tables.Contains(TableName))
            {
                MessageBox.Show($"Таблица {TableName} уже существует", "Error!");
                return;
            }
            List<string> field_names = new();
            List<string> field_values = new();

            foreach (Control control in groupBox1.Controls)
            {
                if (control is TextBox textBox)
                    field_names.Add(textBox.Text);
                else if (control is ComboBox cbx)
                    field_values.Add(cbx.Text);
            }

            List<TableColumn> columns = new();
            for (int i = 0; i <= NumOfColumns; i++)
                columns.Add(new TableColumn()
                {
                    Name = field_names[i].Replace(" ", "_"),
                    Value = field_values[i]
                });

            string query = Queries.CreateTable(TableName, columns);
            try
            {
                Logic.ExecuteNonQuery(query);
                MessageBox.Show("Таблица успешно создана!", "Успех!");
                tables = tables.Append(TableName).ToArray();
            }
            catch
            {
                MessageBox.Show("Произошла ошибка. попробуйте позже...", "Error!");
            }
        }
    }
}
