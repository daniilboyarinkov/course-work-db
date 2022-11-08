namespace home_library
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
            this.UserFormRedirect = new System.Windows.Forms.Button();
            this.AdminFormRedirect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UserFormRedirect
            // 
            this.UserFormRedirect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UserFormRedirect.Location = new System.Drawing.Point(164, 67);
            this.UserFormRedirect.Name = "UserFormRedirect";
            this.UserFormRedirect.Size = new System.Drawing.Size(470, 130);
            this.UserFormRedirect.TabIndex = 0;
            this.UserFormRedirect.Text = "Я читатель!";
            this.UserFormRedirect.UseVisualStyleBackColor = true;
            this.UserFormRedirect.Click += new System.EventHandler(this.UserFormRedirect_Click);
            // 
            // AdminFormRedirect
            // 
            this.AdminFormRedirect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AdminFormRedirect.Location = new System.Drawing.Point(164, 213);
            this.AdminFormRedirect.Name = "AdminFormRedirect";
            this.AdminFormRedirect.Size = new System.Drawing.Size(470, 125);
            this.AdminFormRedirect.TabIndex = 1;
            this.AdminFormRedirect.Text = "Я Админ!";
            this.AdminFormRedirect.UseVisualStyleBackColor = true;
            this.AdminFormRedirect.Click += new System.EventHandler(this.AdminFormRedirect_Click);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.AdminFormRedirect);
            this.Controls.Add(this.UserFormRedirect);
            this.Name = "StartForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Button UserFormRedirect;
        private Button AdminFormRedirect;
    }
}