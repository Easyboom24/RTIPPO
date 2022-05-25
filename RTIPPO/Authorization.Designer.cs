
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
            this.back = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 91);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Пароль";
            // 
            // authorizate
            // 
            this.authorizate.Location = new System.Drawing.Point(212, 144);
            this.authorizate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.authorizate.Name = "authorizate";
            this.authorizate.Size = new System.Drawing.Size(131, 27);
            this.authorizate.TabIndex = 2;
            this.authorizate.Text = "Авторизоваться";
            this.authorizate.UseVisualStyleBackColor = true;
            this.authorizate.Click += new System.EventHandler(this.authorizate_Click);
            // 
            // login
            // 
            this.login.Location = new System.Drawing.Point(112, 39);
            this.login.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(230, 23);
            this.login.TabIndex = 3;
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(112, 88);
            this.password.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(230, 23);
            this.password.TabIndex = 4;
            // 
            // loginText
            // 
            this.loginText.AutoSize = true;
            this.loginText.Location = new System.Drawing.Point(14, 43);
            this.loginText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.loginText.Name = "loginText";
            this.loginText.Size = new System.Drawing.Size(41, 15);
            this.loginText.TabIndex = 5;
            this.loginText.Text = "Логин";
            // 
            // back
            // 
            this.back.Location = new System.Drawing.Point(12, 148);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(75, 23);
            this.back.TabIndex = 6;
            this.back.Text = "Вернуться";
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // Authorization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 194);
            this.Controls.Add(this.back);
            this.Controls.Add(this.loginText);
            this.Controls.Add(this.password);
            this.Controls.Add(this.login);
            this.Controls.Add(this.authorizate);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
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
        private Button back;
    }
}