namespace home_library
{
    partial class AdminForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.Add = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.Change = new System.Windows.Forms.Button();
            this.historyBtn = new System.Windows.Forms.Button();
            this.TakeAppliesBtn = new System.Windows.Forms.Button();
            this.DeptBtn = new System.Windows.Forms.Button();
            this.AddTableGroupBox = new System.Windows.Forms.GroupBox();
            this.NumOfColumnsCombobox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.AddTableButton = new System.Windows.Forms.Button();
            this.TableNameTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DeleteTableGroupbox = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DeleteTableBtn = new System.Windows.Forms.Button();
            this.AllTablesCombobx = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.AddTableGroupBox.SuspendLayout();
            this.DeleteTableGroupbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.radioButton4);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(24, 19);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(300, 175);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioButton1.Location = new System.Drawing.Point(6, 140);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(163, 29);
            this.radioButton1.TabIndex = 4;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Админ коллегия";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioButton4.Location = new System.Drawing.Point(6, 107);
            this.radioButton4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(81, 29);
            this.radioButton4.TabIndex = 3;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Автор";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioButton3.Location = new System.Drawing.Point(6, 77);
            this.radioButton3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(144, 29);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Пользователь";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioButton2.Location = new System.Drawing.Point(6, 48);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(76, 29);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Книга";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.RadioButton2_CheckedChanged);
            // 
            // Add
            // 
            this.Add.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Add.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Add.Location = new System.Drawing.Point(24, 198);
            this.Add.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(96, 34);
            this.Add.TabIndex = 1;
            this.Add.Text = "Добавить";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // Delete
            // 
            this.Delete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Delete.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Delete.Location = new System.Drawing.Point(126, 198);
            this.Delete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(96, 34);
            this.Delete.TabIndex = 2;
            this.Delete.Text = "Удалить";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Change
            // 
            this.Change.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Change.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Change.Location = new System.Drawing.Point(228, 198);
            this.Change.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Change.Name = "Change";
            this.Change.Size = new System.Drawing.Size(96, 34);
            this.Change.TabIndex = 3;
            this.Change.Text = "Изменить";
            this.Change.UseVisualStyleBackColor = true;
            this.Change.Click += new System.EventHandler(this.Change_Click);
            // 
            // historyBtn
            // 
            this.historyBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.historyBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.historyBtn.Location = new System.Drawing.Point(24, 336);
            this.historyBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.historyBtn.Name = "historyBtn";
            this.historyBtn.Size = new System.Drawing.Size(300, 34);
            this.historyBtn.TabIndex = 4;
            this.historyBtn.Text = "История";
            this.historyBtn.UseVisualStyleBackColor = true;
            this.historyBtn.Click += new System.EventHandler(this.HistoryBtn_Click_1);
            // 
            // TakeAppliesBtn
            // 
            this.TakeAppliesBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.TakeAppliesBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TakeAppliesBtn.Location = new System.Drawing.Point(24, 298);
            this.TakeAppliesBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TakeAppliesBtn.Name = "TakeAppliesBtn";
            this.TakeAppliesBtn.Size = new System.Drawing.Size(300, 34);
            this.TakeAppliesBtn.TabIndex = 5;
            this.TakeAppliesBtn.Text = "Заявки читателей";
            this.TakeAppliesBtn.UseVisualStyleBackColor = true;
            this.TakeAppliesBtn.Click += new System.EventHandler(this.TakeAppliesBtn_Click);
            // 
            // DeptBtn
            // 
            this.DeptBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DeptBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DeptBtn.Location = new System.Drawing.Point(24, 260);
            this.DeptBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DeptBtn.Name = "DeptBtn";
            this.DeptBtn.Size = new System.Drawing.Size(300, 34);
            this.DeptBtn.TabIndex = 6;
            this.DeptBtn.Text = "Просрочка";
            this.DeptBtn.UseVisualStyleBackColor = true;
            this.DeptBtn.Click += new System.EventHandler(this.DeptBtn_Click);
            // 
            // AddTableGroupBox
            // 
            this.AddTableGroupBox.Controls.Add(this.NumOfColumnsCombobox);
            this.AddTableGroupBox.Controls.Add(this.label2);
            this.AddTableGroupBox.Controls.Add(this.AddTableButton);
            this.AddTableGroupBox.Controls.Add(this.TableNameTextbox);
            this.AddTableGroupBox.Controls.Add(this.label1);
            this.AddTableGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.AddTableGroupBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AddTableGroupBox.Location = new System.Drawing.Point(362, 22);
            this.AddTableGroupBox.Name = "AddTableGroupBox";
            this.AddTableGroupBox.Size = new System.Drawing.Size(384, 210);
            this.AddTableGroupBox.TabIndex = 7;
            this.AddTableGroupBox.TabStop = false;
            this.AddTableGroupBox.Text = "Добавить таблицу";
            // 
            // NumOfColumnsCombobox
            // 
            this.NumOfColumnsCombobox.FormattingEnabled = true;
            this.NumOfColumnsCombobox.Location = new System.Drawing.Point(201, 105);
            this.NumOfColumnsCombobox.Name = "NumOfColumnsCombobox";
            this.NumOfColumnsCombobox.Size = new System.Drawing.Size(177, 29);
            this.NumOfColumnsCombobox.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 21);
            this.label2.TabIndex = 9;
            this.label2.Text = "Кол-во столбцов";
            // 
            // AddTableButton
            // 
            this.AddTableButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AddTableButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AddTableButton.Location = new System.Drawing.Point(6, 171);
            this.AddTableButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AddTableButton.Name = "AddTableButton";
            this.AddTableButton.Size = new System.Drawing.Size(372, 34);
            this.AddTableButton.TabIndex = 8;
            this.AddTableButton.Text = "Добавить";
            this.AddTableButton.UseVisualStyleBackColor = true;
            this.AddTableButton.Click += new System.EventHandler(this.AddTableButton_Click);
            // 
            // TableNameTextbox
            // 
            this.TableNameTextbox.Location = new System.Drawing.Point(201, 53);
            this.TableNameTextbox.Name = "TableNameTextbox";
            this.TableNameTextbox.Size = new System.Drawing.Size(177, 29);
            this.TableNameTextbox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Имя таблицы";
            // 
            // DeleteTableGroupbox
            // 
            this.DeleteTableGroupbox.Controls.Add(this.label3);
            this.DeleteTableGroupbox.Controls.Add(this.DeleteTableBtn);
            this.DeleteTableGroupbox.Controls.Add(this.AllTablesCombobx);
            this.DeleteTableGroupbox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DeleteTableGroupbox.Location = new System.Drawing.Point(362, 260);
            this.DeleteTableGroupbox.Name = "DeleteTableGroupbox";
            this.DeleteTableGroupbox.Size = new System.Drawing.Size(384, 110);
            this.DeleteTableGroupbox.TabIndex = 8;
            this.DeleteTableGroupbox.TabStop = false;
            this.DeleteTableGroupbox.Text = "Удаление таблицы";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 21);
            this.label3.TabIndex = 11;
            this.label3.Text = "Имя таблицы";
            // 
            // DeleteTableBtn
            // 
            this.DeleteTableBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DeleteTableBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DeleteTableBtn.Location = new System.Drawing.Point(6, 71);
            this.DeleteTableBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DeleteTableBtn.Name = "DeleteTableBtn";
            this.DeleteTableBtn.Size = new System.Drawing.Size(130, 34);
            this.DeleteTableBtn.TabIndex = 9;
            this.DeleteTableBtn.Text = "Удалить";
            this.DeleteTableBtn.UseVisualStyleBackColor = true;
            this.DeleteTableBtn.Click += new System.EventHandler(this.DeleteTableBtn_Click);
            // 
            // AllTablesCombobx
            // 
            this.AllTablesCombobx.FormattingEnabled = true;
            this.AllTablesCombobx.Location = new System.Drawing.Point(201, 33);
            this.AllTablesCombobx.Name = "AllTablesCombobx";
            this.AllTablesCombobx.Size = new System.Drawing.Size(177, 29);
            this.AllTablesCombobx.TabIndex = 11;
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 419);
            this.Controls.Add(this.DeleteTableGroupbox);
            this.Controls.Add(this.AddTableGroupBox);
            this.Controls.Add(this.DeptBtn);
            this.Controls.Add(this.TakeAppliesBtn);
            this.Controls.Add(this.historyBtn);
            this.Controls.Add(this.Change);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.AddTableGroupBox.ResumeLayout(false);
            this.AddTableGroupBox.PerformLayout();
            this.DeleteTableGroupbox.ResumeLayout(false);
            this.DeleteTableGroupbox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private RadioButton radioButton3;
        private RadioButton radioButton2;
        private RadioButton radioButton4;
        private Button Add;
        private Button Delete;
        private Button Change;
        private RadioButton radioButton1;
        private Button historyBtn;
        private Button TakeAppliesBtn;
        private Button DeptBtn;
        private GroupBox AddTableGroupBox;
        private Label label2;
        private Button AddTableButton;
        private TextBox TableNameTextbox;
        private Label label1;
        private ComboBox NumOfColumnsCombobox;
        private GroupBox DeleteTableGroupbox;
        private Label label3;
        private Button DeleteTableBtn;
        private ComboBox AllTablesCombobx;
    }
}