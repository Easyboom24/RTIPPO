
namespace RTIPPO
{
    partial class Authorization
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
            this.label2 = new System.Windows.Forms.Label();
            this.authorizate = new System.Windows.Forms.Button();
            this.login = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.loginText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Пароль";
            // 
            // authorizate
            // 
            this.authorizate.Location = new System.Drawing.Point(182, 125);
            this.authorizate.Name = "authorizate";
            this.authorizate.Size = new System.Drawing.Size(112, 23);
            this.authorizate.TabIndex = 2;
            this.authorizate.Text = "Авторизоваться";
            this.authorizate.UseVisualStyleBackColor = true;
            // 
            // login
            // 
            this.login.Location = new System.Drawing.Point(96, 34);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(198, 20);
            this.login.TabIndex = 3;
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(96, 76);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(198, 20);
            this.password.TabIndex = 4;
            // 
            // loginText
            // 
            this.loginText.AutoSize = true;
            this.loginText.Location = new System.Drawing.Point(12, 37);
            this.loginText.Name = "loginText";
            this.loginText.Size = new System.Drawing.Size(38, 13);
            this.loginText.TabIndex = 5;
            this.loginText.Text = "Логин";
            // 
            // Authorization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 168);
            this.Controls.Add(this.loginText);
            this.Controls.Add(this.password);
            this.Controls.Add(this.login);
            this.Controls.Add(this.authorizate);
            this.Controls.Add(this.label2);
            this.Name = "Authorization";
            this.Text = "Authorization";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button authorizate;
        private System.Windows.Forms.TextBox login;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Label loginText;
    }
}