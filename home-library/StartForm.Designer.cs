﻿namespace home_library
{
    partial class StartForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.UserButton = new System.Windows.Forms.Button();
            this.AdminButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.UserName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // UserButton
            // 
            this.UserButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.UserButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.UserButton.Location = new System.Drawing.Point(12, 229);
            this.UserButton.Name = "UserButton";
            this.UserButton.Size = new System.Drawing.Size(100, 40);
            this.UserButton.TabIndex = 0;
            this.UserButton.Text = "Войти";
            this.UserButton.UseVisualStyleBackColor = true;
            this.UserButton.Click += new System.EventHandler(this.UserButton_Click);
            // 
            // AdminButton
            // 
            this.AdminButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AdminButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AdminButton.Location = new System.Drawing.Point(280, 229);
            this.AdminButton.Name = "AdminButton";
            this.AdminButton.Size = new System.Drawing.Size(200, 40);
            this.AdminButton.TabIndex = 1;
            this.AdminButton.Text = "Войти как админ";
            this.AdminButton.UseVisualStyleBackColor = true;
            this.AdminButton.Click += new System.EventHandler(this.AdminButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(109, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "Имя";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(109, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(279, 35);
            this.label2.TabIndex = 3;
            this.label2.Text = "Домашняя библиотека";
            // 
            // UserName
            // 
            this.UserName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.UserName.Location = new System.Drawing.Point(171, 113);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(151, 34);
            this.UserName.TabIndex = 4;
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 281);
            this.Controls.Add(this.UserName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AdminButton);
            this.Controls.Add(this.UserButton);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "StartForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button UserButton;
        private Button AdminButton;
        private Label label1;
        private Label label2;
        private TextBox UserName;
    }
}