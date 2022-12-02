
using home_library.Extensions;
using System.Text.RegularExpressions;

namespace home_library
{
    public partial class AdminFormStep2 : Form
    {
        private readonly string state;
        private readonly string action;
        public AdminFormStep2(string state, string action)
        {
            InitializeComponent();

            this.state = state; 
            this.action = action;

            Title.Text = $"{action.Capitalize()} {state}.";

            //MessageBox.Show(state, action);
            UpdateInterface();
        }

        private void UpdateInterface()
        {
            switch (state)
            {
                case "жанр":
                    groupBox1.Controls?.Add(CreateLabel("genre_label", "Жанр: ", 1));
                    groupBox1.Controls?.Add(CreateTextBox("genre_textbox", "", 2));

                    break;
                case "книга":
                    groupBox1.Controls?.Add(CreateLabel("title_label", "Название: ", 1));
                    groupBox1.Controls?.Add(CreateTextBox("title_textbox", "", 2));

                    groupBox1.Controls?.Add(CreateLabel("author_label", "Автор: ", 3));
                    groupBox1.Controls?.Add(CreateTextBox("author_textbox", "", 4));

                    groupBox1.Controls?.Add(CreateLabel("publicationYear_label", "Год публикации: ", 5));
                    groupBox1.Controls?.Add(CreateTextBox("publicationYear_textbox", "", 6));

                    if (AdminLogic.IsGenre)
                    {
                        groupBox1.Controls?.Add(CreateLabel("genre_label", "Жанр: ", 7));
                        groupBox1.Controls?.Add(CreateTextBox("genre_textbox", "", 8));
                    }

                    break;
                case "пользователь":
                    groupBox1.Controls?.Add(CreateLabel("name_label", "Имя: ", 1));
                    groupBox1.Controls?.Add(CreateTextBox("name_textbox", "", 2));

                    groupBox1.Controls?.Add(CreateLabel("birthday_label", "Дата рождения: ", 3));
                    groupBox1.Controls?.Add(CreateDatePicker("birthday_datepicker", "", 4));

                    break;
                case "автор":
                    groupBox1.Controls?.Add(CreateLabel("name_label", "Имя: ", 1));
                    groupBox1.Controls?.Add(CreateTextBox("name_textbox", "", 2));

                    groupBox1.Controls?.Add(CreateLabel("birthday_label", "Дата рождения: ", 3));
                    groupBox1.Controls?.Add(CreateDatePicker("birthday_datepicker", "", 4));

                    groupBox1.Controls?.Add(CreateLabel("deathday_label", "Дата Смерти (может быть пустым): ", 5));
                    groupBox1.Controls?.Add(CreateDatePicker("deathhday_datepicker", "", 6));

                    break;
                default:
                    break;
            }
        }

        private Label CreateLabel(string name, string text, int i)
        {
            Label label = new()
            {
                Name = name,
                Text = text,
                Location = new Point(20, i*30)
            };
            return label;
        }

        private TextBox CreateTextBox(string name, string text, int i)
        {
            TextBox textbox = new()
            {
                Name = name,
                Text = text,
                Location = new Point(20, i * 30),
                Width = 210
            };
            return textbox;
        }

        private DateTimePicker CreateDatePicker(string name, string text, int i)
        {
            return new DateTimePicker()
            {
                Name = name,
                Text = text,
                Location = new Point(20, i * 30),
                Width = 210
            };
        }

        private bool ValidateYear(string year)
        {
            return Regex.IsMatch(year, @"^[12]\d{3}$") && int.Parse(year) <= 2023;
        }


        private void SaveBtn_Click(object sender, EventArgs e)
        {
            // validation
            foreach (Control control in groupBox1.Controls)
            {
                if (control is TextBox && control.Text.Length == 0)
                {
                    MessageBox.Show("Заполните все поля!");
                    return;
                } 
                if (control is TextBox && control.Name.ToLower().Contains("year") && !ValidateYear(control.Text))
                {
                    MessageBox.Show(control.Text);
                    return;
                }
            }

            // db quering
            
        }
    }
}
