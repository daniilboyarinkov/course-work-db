namespace home_library
{
    partial class AdminHistoryForm
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
            this.DataGridUser = new System.Windows.Forms.DataGridView();
            this.SubmitBtn = new System.Windows.Forms.Button();
            this.RejectBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.AuthorFilter = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.UserFilter = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.GenreFilter = new System.Windows.Forms.ComboBox();
            this.Title = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridUser)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataGridUser
            // 
            this.DataGridUser.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DataGridUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridUser.Location = new System.Drawing.Point(12, 49);
            this.DataGridUser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DataGridUser.MultiSelect = false;
            this.DataGridUser.Name = "DataGridUser";
            this.DataGridUser.RowHeadersVisible = false;
            this.DataGridUser.RowHeadersWidth = 51;
            this.DataGridUser.RowTemplate.Height = 29;
            this.DataGridUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridUser.Size = new System.Drawing.Size(600, 331);
            this.DataGridUser.TabIndex = 5;
            // 
            // SubmitBtn
            // 
            this.SubmitBtn.BackColor = System.Drawing.Color.SpringGreen;
            this.SubmitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SubmitBtn.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SubmitBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.SubmitBtn.Location = new System.Drawing.Point(12, 408);
            this.SubmitBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SubmitBtn.Name = "SubmitBtn";
            this.SubmitBtn.Size = new System.Drawing.Size(277, 31);
            this.SubmitBtn.TabIndex = 6;
            this.SubmitBtn.Text = "Одобрить";
            this.SubmitBtn.UseVisualStyleBackColor = false;
            this.SubmitBtn.Click += new System.EventHandler(this.SubmitBtn_Click);
            // 
            // RejectBtn
            // 
            this.RejectBtn.BackColor = System.Drawing.Color.Red;
            this.RejectBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.RejectBtn.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RejectBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.RejectBtn.Location = new System.Drawing.Point(335, 408);
            this.RejectBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RejectBtn.Name = "RejectBtn";
            this.RejectBtn.Size = new System.Drawing.Size(277, 31);
            this.RejectBtn.TabIndex = 7;
            this.RejectBtn.Text = "Отказать";
            this.RejectBtn.UseVisualStyleBackColor = false;
            this.RejectBtn.Click += new System.EventHandler(this.RejectBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "По автору:";
            // 
            // AuthorFilter
            // 
            this.AuthorFilter.FormattingEnabled = true;
            this.AuthorFilter.Location = new System.Drawing.Point(19, 66);
            this.AuthorFilter.Name = "AuthorFilter";
            this.AuthorFilter.Size = new System.Drawing.Size(166, 23);
            this.AuthorFilter.TabIndex = 9;
            this.AuthorFilter.SelectedIndexChanged += new System.EventHandler(this.AuthorFilter_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.UserFilter);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.GenreFilter);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.AuthorFilter);
            this.groupBox1.Location = new System.Drawing.Point(618, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(191, 331);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Фильтры";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 235);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "По пользователю:";
            // 
            // UserFilter
            // 
            this.UserFilter.FormattingEnabled = true;
            this.UserFilter.Location = new System.Drawing.Point(19, 253);
            this.UserFilter.Name = "UserFilter";
            this.UserFilter.Size = new System.Drawing.Size(166, 23);
            this.UserFilter.TabIndex = 13;
            this.UserFilter.SelectedIndexChanged += new System.EventHandler(this.UserFilter_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "По жанру:";
            // 
            // GenreFilter
            // 
            this.GenreFilter.FormattingEnabled = true;
            this.GenreFilter.Location = new System.Drawing.Point(19, 163);
            this.GenreFilter.Name = "GenreFilter";
            this.GenreFilter.Size = new System.Drawing.Size(166, 23);
            this.GenreFilter.TabIndex = 11;
            this.GenreFilter.SelectedIndexChanged += new System.EventHandler(this.GenreFilter_SelectedIndexChanged);
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Location = new System.Drawing.Point(346, 15);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(0, 15);
            this.Title.TabIndex = 11;
            // 
            // AdminHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 450);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.RejectBtn);
            this.Controls.Add(this.SubmitBtn);
            this.Controls.Add(this.DataGridUser);
            this.Name = "AdminHistory";
            this.Text = "AdminHistory";
            ((System.ComponentModel.ISupportInitialize)(this.DataGridUser)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView DataGridUser;
        private Button SubmitBtn;
        private Button RejectBtn;
        private Label label1;
        private ComboBox AuthorFilter;
        private GroupBox groupBox1;
        private Label label3;
        private ComboBox UserFilter;
        private Label label2;
        private ComboBox GenreFilter;
        private Label Title;
    }
}