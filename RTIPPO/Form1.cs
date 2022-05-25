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
        internal User? user;

        public bool hide = false;
        public int id;
        protected int countApplications = 2;
        protected bool boolDelete;
        public Dictionary<string, string> sorting = new Dictionary<string, string>();
        public Dictionary<string, Tuple<string, string, int>> filters = new Dictionary<string, Tuple<string, string, int>>(); 
        ApplyApplicationsApi Api = new ApplyApplicationsApi();

        public Form1()
        {
            InitializeComponent();
        }

        private void FillDataGrid(List<Pets_Application> applications) 
        {
            dataGridView1.Rows.Clear();
            foreach (Pets_Application app in applications)
            {
                dataGridView1.Rows.Add(app.Pets_Application_Id, app.Filling_Date,
                    app.Application_Number, app?.Applicant?.Organization?.Type_Enterprise?.Type_Enterprise_Name ?? "Физ. лицо",
                    app?.Locality?.Locality_Name,app?.Animal?.Habitat,app?.Animal?.Animal_Category?.Category_Name,
                    app?.Urgency?.Urgency_Name, app?.Organization?.Organization_Name, app?.Status?.Status_Name ,app?.Status_Date);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (hide)
            {
                hide = false;
                button4.Text = "Скрыть";
                filters.Remove("Status_Id");
            }
            else
            {
                hide = true;
                button4.Text = "Вернуть";
                filters.Add("Status_Id", Tuple.Create("!=",6.ToString(),0));
            }
            List<Pets_Application>? applications = Api.GetAllApplications(countApplications, sorting, filters);
            FillDataGrid(applications);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<int> idApps = new List<int>();
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                idApps.Add(Convert.ToInt32(row.Cells[0].Value));

            Form2 f2 = new Form2();
            f2.FormClosing += new FormClosingEventHandler(f2_FormClosing);
            f2.idDeleted = idApps;
            f2.ShowDialog();
        }

        private void dataGridView1_ColumnHeaderMouseRightClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.ColumnIndex - 1 != 2)
                {
                    Form3 filtration = new Form3();
                    filtration.FormClosing += new FormClosingEventHandler(filtration_FormClosing);
                    filtration.filters = filters;
                    string nameForm = dataGridView1.Columns[e.ColumnIndex].HeaderText;
                    filtration.Text = nameForm;
                    filtration.tabControl1.SelectedIndex = e.ColumnIndex - 1;
                    filtration.ShowDialog();
                }
            }
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var headerText = dataGridView1.Columns[e.ColumnIndex].HeaderText;
                var key = dataGridView1.Columns[e.ColumnIndex].Name;
                if (sorting.ContainsKey(key))
                {
                    headerText = headerText.Substring(0, headerText.Length - 2);

                    if (sorting[key] == "ASC")
                    {
                        sorting[key] = "DESC";
                        dataGridView1.Columns[e.ColumnIndex].HeaderText = headerText + " ↓";
                    }
                    else if (sorting[key] == "DESC")
                    {
                        sorting.Remove(key);
                        dataGridView1.Columns[e.ColumnIndex].HeaderText = headerText;
                    }
                }
                else
                {
                    sorting.Add(key, "ASC");
                    dataGridView1.Columns[e.ColumnIndex].HeaderText = headerText + " ↑";
                }

                List<Pets_Application>? applications = Api.GetAllApplications(countApplications, sorting, filters);
                FillDataGrid(applications);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            indexCard f2 = new indexCard();
            f2.application = Api.GetApplication(id);
            f2.user = user;
            f2.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            countApplications = countApplications + 2;
            List<Pets_Application> applications = Api.GetAllApplications(countApplications,sorting,filters);
            FillDataGrid(applications);
            if(countApplications>applications.ToList().Count)
                button7.Enabled = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1 && user!=null)
                button2.Enabled = true;
            else button2.Enabled = false;

            boolDelete = true;
            foreach (DataGridViewRow row in dataGridView1.SelectedRows) 
                if (row.Cells[9].Value.ToString() != "Черновик")
                    boolDelete = false;
           
            if (boolDelete && dataGridView1.SelectedRows.Count!=0)
                button3.Enabled = true;
            else
                button3.Enabled = false;
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            if(user == null || user.Role_FK != 7)
            {
                button1.Enabled = false;
                button3.Enabled = false;
                if (user == null) button2.Enabled = false;
            }

            List<Pets_Application> apps = Api.GetAllApplications(countApplications, sorting, filters);
            FillDataGrid(apps);
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ClearSelection();

            foreach (DataGridViewColumn column in dataGridView1.Columns) 
                column.SortMode = DataGridViewColumnSortMode.Programmatic;
        }

        private void f2_FormClosing(object sender, FormClosingEventArgs e) 
        {
            if ((sender as Form2).GetBoolDeleted()) 
            {
                List<Pets_Application> applications = Api.GetAllApplications(countApplications,sorting, filters);
                FillDataGrid(applications);
                dataGridView1.ClearSelection();
            }
        }
        private void filtration_FormClosing(object sender, FormClosingEventArgs e)
        {
            filters = (sender as Form3).filters;
            List<Pets_Application> applications = Api.GetAllApplications(countApplications, sorting, filters);
            FillDataGrid(applications);
            dataGridView1.ClearSelection();

            dataGridView1.Columns[1].HeaderCell.Style.BackColor = filters.ContainsKey("Filling_Date") ? SystemColors.ActiveCaption : SystemColors.Control;
            dataGridView1.Columns[2].HeaderCell.Style.BackColor = filters.ContainsKey("Application_Number") ? SystemColors.ActiveCaption : SystemColors.Control;
            dataGridView1.Columns[4].HeaderCell.Style.BackColor = filters.ContainsKey("Locality_Name") ? SystemColors.ActiveCaption : SystemColors.Control;
            dataGridView1.Columns[5].HeaderCell.Style.BackColor = filters.ContainsKey("Habitat") ? SystemColors.ActiveCaption : SystemColors.Control;
            dataGridView1.Columns[6].HeaderCell.Style.BackColor = filters.ContainsKey("Category_Name") ? SystemColors.ActiveCaption : SystemColors.Control;
            dataGridView1.Columns[7].HeaderCell.Style.BackColor = filters.ContainsKey("Urgency_Name") ? SystemColors.ActiveCaption : SystemColors.Control;
            dataGridView1.Columns[8].HeaderCell.Style.BackColor = filters.ContainsKey("Organization_Name") ? SystemColors.ActiveCaption : SystemColors.Control;
            dataGridView1.Columns[9].HeaderCell.Style.BackColor = filters.ContainsKey("Status_Name") ? SystemColors.ActiveCaption : SystemColors.Control;
            dataGridView1.Columns[10].HeaderCell.Style.BackColor = filters.ContainsKey("Status_Date") ? SystemColors.ActiveCaption : SystemColors.Control;
        }
        
        private void button5_Click(object sender, EventArgs e) => Api.ExportToExcel(sorting,filters);

        private void button1_Click(object sender, EventArgs e)
        {
            indexCard f2 = new indexCard();
            f2.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    } 
}   
