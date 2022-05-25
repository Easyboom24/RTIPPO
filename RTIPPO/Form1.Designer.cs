namespace RTIPPO
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Application_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Filling_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Application_Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Applicant_FK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Locality_FK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Habitat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Animal_FK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Urgency_FK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Organization_FK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status_FK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(14, 14);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 37);
            this.button1.TabIndex = 0;
            this.button1.Text = "Добавить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(147, 14);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(126, 37);
            this.button2.TabIndex = 1;
            this.button2.Text = "Открыть";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(280, 14);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(126, 37);
            this.button3.TabIndex = 2;
            this.button3.Text = "Удалить";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(413, 14);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(126, 37);
            this.button4.TabIndex = 3;
            this.button4.Text = "Скрыть";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Application_Id,
            this.Filling_Date,
            this.Application_Number,
            this.Applicant_FK,
            this.Locality_FK,
            this.Habitat,
            this.Animal_FK,
            this.Urgency_FK,
            this.Organization_FK,
            this.Status_FK,
            this.Status_Date});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(14, 58);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(1);
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1035, 422);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseRightClick);
            // 
            // Application_Id
            // 
            this.Application_Id.HeaderText = "Id";
            this.Application_Id.Name = "Application_Id";
            this.Application_Id.ReadOnly = true;
            this.Application_Id.Visible = false;
            // 
            // Filling_Date
            // 
            this.Filling_Date.HeaderText = "Дата подачи заявки";
            this.Filling_Date.Name = "Filling_Date";
            this.Filling_Date.ReadOnly = true;
            // 
            // Application_Number
            // 
            this.Application_Number.HeaderText = "Номер заявки";
            this.Application_Number.Name = "Application_Number";
            this.Application_Number.ReadOnly = true;
            // 
            // Applicant_FK
            // 
            this.Applicant_FK.HeaderText = "Категория заявителя";
            this.Applicant_FK.Name = "Applicant_FK";
            this.Applicant_FK.ReadOnly = true;
            // 
            // Locality_FK
            // 
            this.Locality_FK.HeaderText = "Населенный пункт";
            this.Locality_FK.Name = "Locality_FK";
            this.Locality_FK.ReadOnly = true;
            // 
            // Habitat
            // 
            this.Habitat.HeaderText = "Место обитания животного";
            this.Habitat.Name = "Habitat";
            this.Habitat.ReadOnly = true;
            // 
            // Animal_FK
            // 
            this.Animal_FK.HeaderText = "Категория животного";
            this.Animal_FK.Name = "Animal_FK";
            this.Animal_FK.ReadOnly = true;
            // 
            // Urgency_FK
            // 
            this.Urgency_FK.HeaderText = "Срочность исполнения";
            this.Urgency_FK.Name = "Urgency_FK";
            this.Urgency_FK.ReadOnly = true;
            // 
            // Organization_FK
            // 
            this.Organization_FK.HeaderText = "Организация по отлову";
            this.Organization_FK.Name = "Organization_FK";
            this.Organization_FK.ReadOnly = true;
            // 
            // Status_FK
            // 
            this.Status_FK.HeaderText = "Текущий статус заявки";
            this.Status_FK.Name = "Status_FK";
            this.Status_FK.ReadOnly = true;
            // 
            // Status_Date
            // 
            this.Status_Date.HeaderText = "Дата установки статуса";
            this.Status_Date.Name = "Status_Date";
            this.Status_Date.ReadOnly = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(546, 14);
            this.button5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(155, 37);
            this.button5.TabIndex = 5;
            this.button5.Text = "Экспорт в Excel";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(984, 14);
            this.button6.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(65, 37);
            this.button6.TabIndex = 6;
            this.button6.Text = "Войти";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(14, 486);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(100, 21);
            this.button7.TabIndex = 7;
            this.button7.Text = "Показать ещё";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 519);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = " ";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private Button button7;
        private DataGridViewTextBoxColumn Application_Id;
        private DataGridViewTextBoxColumn Filling_Date;
        private DataGridViewTextBoxColumn Application_Number;
        private DataGridViewTextBoxColumn Applicant_FK;
        private DataGridViewTextBoxColumn Locality_FK;
        private DataGridViewTextBoxColumn Habitat;
        private DataGridViewTextBoxColumn Animal_FK;
        private DataGridViewTextBoxColumn Urgency_FK;
        private DataGridViewTextBoxColumn Organization_FK;
        private DataGridViewTextBoxColumn Status_FK;
        private DataGridViewTextBoxColumn Status_Date;
    }
}

