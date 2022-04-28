using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTIPPO
{
    public partial class Form1 : Form
    {
        public bool skrito = false;
        public Form1()
        {
            InitializeComponent();
            var dateApplication = new DataGridViewTextBoxColumn();
            dateApplication.HeaderText = "Дата подачи заявки";
            dateApplication.Name = "dateApplication";

            var applicationNumber = new DataGridViewTextBoxColumn();
            applicationNumber.HeaderText = "Номер заявки";
            applicationNumber.Name = "applicationNumber";

            var applicantCatigory = new DataGridViewTextBoxColumn();
            applicantCatigory.HeaderText = "Категория заявителя";
            applicantCatigory.Name = "applicantCatigory";

            var locality = new DataGridViewTextBoxColumn();
            locality.HeaderText = "Населенный пункт";
            locality.Name = "locality";

            var animalHabitat = new DataGridViewTextBoxColumn();
            animalHabitat.HeaderText = "Место обитания животного";
            animalHabitat.Name = "animalHabitat";

            var animalCategory = new DataGridViewTextBoxColumn();
            animalCategory.HeaderText = "Категория животного";
            animalCategory.Name = "animalCategory";

            var urgency = new DataGridViewTextBoxColumn();
            urgency.HeaderText = "Cрочность исполнения";
            urgency.Name = "urgency";

            var captureOrganization = new DataGridViewTextBoxColumn();
            captureOrganization.HeaderText = "Организация по отлову";
            captureOrganization.Name = "captureOrganization";

            var currentAplicationStatus = new DataGridViewTextBoxColumn();
            currentAplicationStatus.HeaderText = "Текущий статус заявки";
            currentAplicationStatus.Name = "currentAplicationStatus";

            var dateStatusSet = new DataGridViewTextBoxColumn();
            dateStatusSet.HeaderText = "Дата установки статуса";
            dateStatusSet.Name = "dateStatusSet";

            /*var attribute = new DataGridViewTextBoxColumn();
            attribute.HeaderText = "Признак";
            attribute.Name = "attribute";*/

            dataGridView1.Columns.AddRange(new DataGridViewColumn[] {
                dateApplication,
                applicationNumber,
                applicantCatigory,
                locality,
                animalHabitat,
                animalCategory,
                urgency,
                captureOrganization,
                currentAplicationStatus,
                dateStatusSet,
                //attribute
            });

            //ApplyApplicationsApi Api = new ApplyApplicationsApi();
            //var apps = Api.GetAllApplications();
            //dataGridView1.DataSource = apps;
        }

        private void button4_Click(object sender, EventArgs e)
        {

            
            if (skrito)
            {
                skrito = false;
                button4.Text = "Скрыть";
            }
            else
            {
                skrito = true;
                button4.Text = "Вернуть";
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        private void dataGridView1_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Form3 filtration = new Form3();
            string nameForm = dataGridView1.Columns[e.ColumnIndex].HeaderText;
            filtration.Text = nameForm;
            filtration.ShowDialog();
            filtration.tabControl1.SelectedIndex = e.ColumnIndex;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            indexCard f2 = new indexCard();
            f2.Show();
        }
    
    } 
}
