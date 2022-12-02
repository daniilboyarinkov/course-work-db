namespace home_library
{
    partial class UserForm
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
            this.UserBooks = new System.Windows.Forms.Button();
            this.DataGridUser = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GetBook = new System.Windows.Forms.Button();
            this.ShowHistory = new System.Windows.Forms.Button();
            this.AuthorFilterBox = new System.Windows.Forms.GroupBox();
            this.AllAuthorsRadioBtn = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridUser)).BeginInit();
            this.AuthorFilterBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // UserBooks
            // 
            this.UserBooks.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.UserBooks.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.UserBooks.Location = new System.Drawing.Point(508, 9);
            this.UserBooks.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UserBooks.Name = "UserBooks";
            this.UserBooks.Size = new System.Drawing.Size(177, 38);
            this.UserBooks.TabIndex = 0;
            this.UserBooks.Text = "Мои книги";
            this.UserBooks.UseVisualStyleBackColor = true;
            this.UserBooks.Click += new System.EventHandler(this.UserBooks_Click);
            // 
            // DataGridUser
            // 
            this.DataGridUser.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DataGridUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column3,
            this.Column4});
            this.DataGridUser.Location = new System.Drawing.Point(10, 9);
            this.DataGridUser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DataGridUser.MultiSelect = false;
            this.DataGridUser.Name = "DataGridUser";
            this.DataGridUser.RowHeadersVisible = false;
            this.DataGridUser.RowHeadersWidth = 51;
            this.DataGridUser.RowTemplate.Height = 29;
            this.DataGridUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridUser.Size = new System.Drawing.Size(438, 230);
            this.DataGridUser.TabIndex = 1;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Название";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 175;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Автор";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 125;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Публикация";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 125;
            // 
            // GetBook
            // 
            this.GetBook.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.GetBook.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.GetBook.Location = new System.Drawing.Point(87, 243);
            this.GetBook.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GetBook.Name = "GetBook";
            this.GetBook.Size = new System.Drawing.Size(180, 30);
            this.GetBook.TabIndex = 2;
            this.GetBook.Text = "Взять книгу";
            this.GetBook.UseVisualStyleBackColor = true;
            this.GetBook.Click += new System.EventHandler(this.GetBook_Click);
            // 
            // ShowHistory
            // 
            this.ShowHistory.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ShowHistory.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ShowHistory.Location = new System.Drawing.Point(508, 51);
            this.ShowHistory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ShowHistory.Name = "ShowHistory";
            this.ShowHistory.Size = new System.Drawing.Size(177, 40);
            this.ShowHistory.TabIndex = 3;
            this.ShowHistory.Text = "Моя история";
            this.ShowHistory.UseVisualStyleBackColor = true;
            this.ShowHistory.Click += new System.EventHandler(this.ShowHistory_Click);
            // 
            // AuthorFilterBox
            // 
            this.AuthorFilterBox.Controls.Add(this.AllAuthorsRadioBtn);
            this.AuthorFilterBox.Location = new System.Drawing.Point(485, 96);
            this.AuthorFilterBox.Name = "AuthorFilterBox";
            this.AuthorFilterBox.Size = new System.Drawing.Size(216, 143);
            this.AuthorFilterBox.TabIndex = 4;
            this.AuthorFilterBox.TabStop = false;
            this.AuthorFilterBox.Text = "Фильтр по авторам";
            // 
            // AllAuthorsRadioBtn
            // 
            this.AllAuthorsRadioBtn.AutoSize = true;
            this.AllAuthorsRadioBtn.Checked = true;
            this.AllAuthorsRadioBtn.Location = new System.Drawing.Point(7, 23);
            this.AllAuthorsRadioBtn.Name = "AllAuthorsRadioBtn";
            this.AllAuthorsRadioBtn.Size = new System.Drawing.Size(87, 19);
            this.AllAuthorsRadioBtn.TabIndex = 0;
            this.AllAuthorsRadioBtn.TabStop = true;
            this.AllAuthorsRadioBtn.Text = "Все авторы";
            this.AllAuthorsRadioBtn.UseVisualStyleBackColor = true;
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 285);
            this.Controls.Add(this.AuthorFilterBox);
            this.Controls.Add(this.DataGridUser);
            this.Controls.Add(this.ShowHistory);
            this.Controls.Add(this.GetBook);
            this.Controls.Add(this.UserBooks);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UserForm";
            this.Text = "UserForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UserForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridUser)).EndInit();
            this.AuthorFilterBox.ResumeLayout(false);
            this.AuthorFilterBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Button UserBooks;
        private DataGridView DataGridUser;
        private Button GetBook;
        private Button ShowHistory;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private GroupBox AuthorFilterBox;
        private RadioButton AllAuthorsRadioBtn;
    }
}