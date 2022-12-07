namespace home_library.Admin
{
    partial class AdminAddTableForm
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
            this.Add = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.SelectTable = new System.Windows.Forms.ComboBox();
            this.addRelation = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Add
            // 
            this.Add.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Add.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Add.Location = new System.Drawing.Point(12, 340);
            this.Add.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(481, 43);
            this.Add.TabIndex = 2;
            this.Add.Text = "Создать таблицу";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(12, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(481, 256);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Поля";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(331, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Добавление новой таблицы";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.SelectTable);
            this.groupBox3.Controls.Add(this.addRelation);
            this.groupBox3.Location = new System.Drawing.Point(521, 60);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(250, 148);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Добавить связное поле в таблице";
            // 
            // SelectTable
            // 
            this.SelectTable.FormattingEnabled = true;
            this.SelectTable.Location = new System.Drawing.Point(6, 31);
            this.SelectTable.Name = "SelectTable";
            this.SelectTable.Size = new System.Drawing.Size(244, 23);
            this.SelectTable.TabIndex = 9;
            // 
            // addRelation
            // 
            this.addRelation.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addRelation.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.addRelation.Location = new System.Drawing.Point(6, 97);
            this.addRelation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addRelation.Name = "addRelation";
            this.addRelation.Size = new System.Drawing.Size(238, 46);
            this.addRelation.TabIndex = 8;
            this.addRelation.Text = "Добавить связь";
            this.addRelation.UseVisualStyleBackColor = true;
            this.addRelation.Click += new System.EventHandler(this.Button1_Click);
            // 
            // AdminAddTableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Add);
            this.Name = "AdminAddTableForm";
            this.Text = "AdminAddTableForm";
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button Add;
        private GroupBox groupBox1;
        private Label label1;
        private GroupBox groupBox3;
        private Button addRelation;
        private ComboBox SelectTable;
    }
}