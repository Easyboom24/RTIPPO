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
    public partial class Form3 : Form
    {
        internal Dictionary<string, Tuple<string,string,int>> filters;
        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (filters.ContainsKey("Filling_Date"))
                filters.Remove("Filling_Date");

            switch (comboBox7.SelectedIndex)
            {
                case 0:
                    filters.Add("Filling_Date", Tuple.Create("=", dateTimePicker1.Value.ToString("yyyy-MM-dd"), comboBox7.SelectedIndex));
                    break;
                case 1:
                    filters.Add("Filling_Date", Tuple.Create(">=", dateTimePicker1.Value.ToString("yyyy-MM-dd"), comboBox7.SelectedIndex));
                    break;
                case 2:
                    filters.Add("Filling_Date", Tuple.Create("<=", dateTimePicker1.Value.ToString("yyyy-MM-dd"), comboBox7.SelectedIndex));
                    break;
                case 3:
                    filters.Add("Filling_Date", Tuple.Create("!=", dateTimePicker1.Value.ToString("yyyy-MM-dd"), comboBox7.SelectedIndex));
                    break;
            }
           
           
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (filters.ContainsKey("Application_Number"))
                filters.Remove("Application_Number");
            switch (comboBox8.SelectedIndex)
            {
                case 0:
                    filters.Add("Application_Number", Tuple.Create("=", numericUpDown1.Value.ToString(), comboBox8.SelectedIndex));
                    break;
                case 1:
                    filters.Add("Application_Number", Tuple.Create("!=", numericUpDown1.Value.ToString(), comboBox8.SelectedIndex));
                    break;
                case 2:
                    filters.Add("Application_Number", Tuple.Create(">", numericUpDown1.Value.ToString(), comboBox8.SelectedIndex));
                    break;
                case 3:
                    filters.Add("Application_Number", Tuple.Create("<", numericUpDown1.Value.ToString(), comboBox8.SelectedIndex));
                    break;
            }

            Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (filters.ContainsKey("Status_Name"))
                filters.Remove("Status_Name");

            switch (comboBox6.SelectedIndex)
            {
                case 0:
                    filters.Add("Status_Name", Tuple.Create("=",  textBox6.Text, comboBox6.SelectedIndex));
                    break;
                case 1:
                    filters.Add("Status_Name", Tuple.Create("!=", textBox6.Text, comboBox6.SelectedIndex));
                    break;
                case 2:
                    filters.Add("Status_Name", Tuple.Create("LIKE", textBox6.Text + "%", comboBox6.SelectedIndex));
                    break;
                case 3:
                    filters.Add("Status_Name", Tuple.Create("LIKE", "%" + textBox6.Text, comboBox6.SelectedIndex));
                    break;
                case 4:
                    filters.Add("Status_Name", Tuple.Create("LIKE", "%" + textBox6.Text + "%", comboBox6.SelectedIndex));
                    break;
            }
            Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (filters.ContainsKey("Habitat"))
                filters.Remove("Habitat");

            switch (comboBox2.SelectedIndex)
            {
                case 0:
                    filters.Add("Habitat", Tuple.Create("=", textBox2.Text, comboBox2.SelectedIndex));
                    break;
                case 1:
                    filters.Add("Habitat", Tuple.Create("!=", textBox2.Text, comboBox2.SelectedIndex));
                    break;
                case 2:
                    filters.Add("Habitat", Tuple.Create("LIKE", textBox2.Text + "%", comboBox2.SelectedIndex));
                    break;
                case 3:
                    filters.Add("Habitat", Tuple.Create("LIKE", "%"+textBox2.Text, comboBox2.SelectedIndex));
                    break;
                case 4:
                    filters.Add("Habitat", Tuple.Create("LIKE", "%" + textBox2.Text + "%", comboBox2.SelectedIndex));
                    break;
            }
            Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (filters.ContainsKey("Urgency_Name"))
                filters.Remove("Urgency_Name");

            switch (comboBox4.SelectedIndex)
            {
                case 0:
                    filters.Add("Urgency_Name", Tuple.Create("=", textBox4.Text, comboBox4.SelectedIndex));
                    break;
                case 1:
                    filters.Add("Urgency_Name", Tuple.Create("!=", textBox4.Text, comboBox4.SelectedIndex));
                    break;
                case 2:
                    filters.Add("Urgency_Name", Tuple.Create("LIKE", textBox4.Text + "%", comboBox4.SelectedIndex));
                    break;
                case 3:
                    filters.Add("Urgency_Name", Tuple.Create("LIKE", "%" + textBox4.Text, comboBox4.SelectedIndex));
                    break;
                case 4:
                    filters.Add("Urgency_Name", Tuple.Create("LIKE", "%" + textBox4.Text + "%", comboBox4.SelectedIndex));
                    break;
            }

            Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (filters.ContainsKey("Organization_Name"))
                filters.Remove("Organization_Name");

            switch (comboBox5.SelectedIndex)
            {
                case 0:
                    filters.Add("Organization_Name", Tuple.Create("=", textBox5.Text , comboBox5.SelectedIndex));
                    break;
                case 1:
                    filters.Add("Organization_Name", Tuple.Create("!=",  textBox5.Text, comboBox5.SelectedIndex));
                    break;
                case 2:
                    filters.Add("Organization_Name", Tuple.Create("LIKE", textBox5.Text + "%", comboBox5.SelectedIndex));
                    break;
                case 3:
                    filters.Add("Organization_Name", Tuple.Create("LIKE", "%" + textBox5.Text, comboBox5.SelectedIndex));
                    break;
                case 4:
                    filters.Add("Organization_Name", Tuple.Create("LIKE", "%" + textBox5.Text + "%", comboBox5.SelectedIndex));
                    break;
            }

            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (filters.ContainsKey("Locality_Name"))
                filters.Remove("Locality_Name");

            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    filters.Add("Locality_Name", Tuple.Create("=",  textBox1.Text, comboBox1.SelectedIndex));
                    break;
                case 1:
                    filters.Add("Locality_Name", Tuple.Create("!=", textBox1.Text, comboBox1.SelectedIndex));
                    break;
                case 2:
                    filters.Add("Locality_Name", Tuple.Create("LIKE", textBox1.Text + "%", comboBox1.SelectedIndex));
                    break;
                case 3:
                    filters.Add("Locality_Name", Tuple.Create("LIKE", "%" + textBox1.Text, comboBox1.SelectedIndex));
                    break;
                case 4:
                    filters.Add("Locality_Name", Tuple.Create("LIKE", "%" + textBox1.Text + "%", comboBox1.SelectedIndex));
                    break;
            }
            Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (filters.ContainsKey("Category_Name"))
                filters.Remove("Category_Name");

            switch (comboBox3.SelectedIndex)
            {
                case 0:
                    filters.Add("Category_Name", Tuple.Create("=", textBox3.Text, comboBox3.SelectedIndex));
                    break;
                case 1:
                    filters.Add("Category_Name", Tuple.Create("!=", textBox3.Text, comboBox3.SelectedIndex));
                    break;
                case 2:
                    filters.Add("Category_Name", Tuple.Create("LIKE", textBox3.Text + "%", comboBox3.SelectedIndex));
                    break;
                case 3:
                    filters.Add("Category_Name", Tuple.Create("LIKE", "%" + textBox3.Text, comboBox3.SelectedIndex));
                    break;
                case 4:
                    filters.Add("Category_Name", Tuple.Create("LIKE", "%" + textBox3.Text + "%", comboBox3.SelectedIndex));
                    break;
            }
            Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (filters.ContainsKey("Status_Date"))
                filters.Remove("Status_Date");

            switch (comboBox9.SelectedIndex)
            {
                case 0:
                    filters.Add("Status_Date", Tuple.Create("=", dateTimePicker3.Value.ToString("yyyy-MM-dd"), comboBox9.SelectedIndex));
                    break;
                case 1:
                    filters.Add("Status_Date", Tuple.Create(">=", dateTimePicker3.Value.ToString("yyyy-MM-dd"), comboBox9.SelectedIndex));
                    break;
                case 2:
                    filters.Add("Status_Date", Tuple.Create("<=", dateTimePicker3.Value.ToString("yyyy-MM-dd"), comboBox9.SelectedIndex));
                    break;
                case 3:
                    filters.Add("Status_Date", Tuple.Create("!=", dateTimePicker3.Value.ToString("yyyy-MM-dd"), comboBox9.SelectedIndex));
                    break;
            }

            Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (filters.ContainsKey("Filling_Date"))
                filters.Remove("Filling_Date");
            Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (filters.ContainsKey("Application_Number"))
                filters.Remove("Application_Number");
            Close();
            
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (filters.ContainsKey("Locality_Name"))
                filters.Remove("Locality_Name");
            Close();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (filters.ContainsKey("Habitat"))
                filters.Remove("Habitat");
            Close();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (filters.ContainsKey("Category_Name"))
                filters.Remove("Category_Name");
            Close();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (filters.ContainsKey("Urgency_Name"))
                filters.Remove("Urgency_Name");
            Close();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (filters.ContainsKey("Organization_Name"))
                filters.Remove("Organization_Name");
            Close();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (filters.ContainsKey("Status_Name"))
                filters.Remove("Status_Name");
            Close();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (filters.ContainsKey("Status_Date"))
                filters.Remove("Status_Date");
            Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndexChanged += TextBox_ComboBox_Chanched;
            comboBox2.SelectedIndexChanged += TextBox_ComboBox_Chanched;
            comboBox3.SelectedIndexChanged += TextBox_ComboBox_Chanched;
            comboBox4.SelectedIndexChanged += TextBox_ComboBox_Chanched;
            comboBox5.SelectedIndexChanged += TextBox_ComboBox_Chanched;
            comboBox6.SelectedIndexChanged += TextBox_ComboBox_Chanched;
            comboBox7.SelectedIndexChanged += TextBox_ComboBox_Chanched;
            comboBox8.SelectedIndexChanged += TextBox_ComboBox_Chanched;
            comboBox9.SelectedIndexChanged += TextBox_ComboBox_Chanched;
            textBox1.TextChanged += TextBox_ComboBox_Chanched;
            textBox2.TextChanged += TextBox_ComboBox_Chanched;
            textBox3.TextChanged += TextBox_ComboBox_Chanched;
            textBox4.TextChanged += TextBox_ComboBox_Chanched;
            textBox5.TextChanged += TextBox_ComboBox_Chanched;
            textBox6.TextChanged += TextBox_ComboBox_Chanched;
            numericUpDown1.ValueChanged += TextBox_ComboBox_Chanched;

            if (tabControl1.SelectedIndex==0)
            { 
                comboBox7.SelectedIndex = filters.ContainsKey("Filling_Date") ? filters["Filling_Date"].Item3 : -1;
                dateTimePicker1.Value = filters.ContainsKey("Filling_Date") ? Convert.ToDateTime(filters["Filling_Date"].Item2) : DateTime.Now;
            }
            if (tabControl1.SelectedIndex == 1)
            {
                comboBox8.SelectedIndex = filters.ContainsKey("Application_Number") ? filters["Application_Number"].Item3 : -1;
                numericUpDown1.Value = filters.ContainsKey("Application_Number") ? Convert.ToInt32(filters["Application_Number"].Item2) : 1;
            }
            if (tabControl1.SelectedIndex == 3)
            {
                comboBox1.SelectedIndex = filters.ContainsKey("Locality_Name") ? filters["Locality_Name"].Item3 : -1;
                textBox1.Text = filters.ContainsKey("Locality_Name") ? filters["Locality_Name"].Item2.Trim('%') : "";
            }
            if (tabControl1.SelectedIndex == 4)
            {
                comboBox2.SelectedIndex = filters.ContainsKey("Habitat") ? filters["Habitat"].Item3 : -1;
                textBox2.Text = filters.ContainsKey("Habitat") ? filters["Habitat"].Item2.Trim('%') : "";
            }
            if (tabControl1.SelectedIndex == 5)
            {
                comboBox3.SelectedIndex = filters.ContainsKey("Category_Name") ? filters["Category_Name"].Item3 : -1;
                textBox3.Text = filters.ContainsKey("Category_Name") ? filters["Category_Name"].Item2.Trim('%') : "";
            }
            if (tabControl1.SelectedIndex == 6)
            {
                comboBox4.SelectedIndex = filters.ContainsKey("Urgency_Name") ? filters["Urgency_Name"].Item3 : -1;
                textBox4.Text = filters.ContainsKey("Urgency_Name") ? filters["Urgency_Name"].Item2.Trim('%') : "";
            }
            if (tabControl1.SelectedIndex == 7)
            {
                comboBox5.SelectedIndex = filters.ContainsKey("Organization_Name") ? filters["Organization_Name"].Item3 : -1;
                textBox5.Text = filters.ContainsKey("Organization_Name") ? filters["Organization_Name"].Item2.Trim('%') : "";
            }
            if (tabControl1.SelectedIndex == 8)
            {
                comboBox6.SelectedIndex = filters.ContainsKey("Status_Name") ? filters["Status_Name"].Item3 : -1;
                textBox6.Text = filters.ContainsKey("Status_Name") ? filters["Status_Name"].Item2.Trim('%') : "";
            }
            if (tabControl1.SelectedIndex == 9)
            {
                comboBox9.SelectedIndex = filters.ContainsKey("Status_Date") ? filters["Status_Date"].Item3 : -1;
                dateTimePicker3.Value = filters.ContainsKey("Status_Date") ? Convert.ToDateTime(filters["Status_Date"].Item2) : DateTime.Now;
            }
        }

        private void TextBox_ComboBox_Chanched(object sender, EventArgs e) 
        {
            if (comboBox7.SelectedIndex == -1)
                button2.Enabled = false;
            else button2.Enabled = true;

            if (comboBox8.SelectedIndex == -1 || numericUpDown1.Value < 1)
                button3.Enabled = false;
            else button3.Enabled = true;

            if (comboBox1.SelectedIndex == -1 || textBox1.Text=="")
                button4.Enabled = false;
            else button4.Enabled = true;

            if (comboBox2.SelectedIndex == -1 || textBox2.Text == "")
                button5.Enabled = false;
            else button5.Enabled = true;

            if (comboBox3.SelectedIndex == -1 || textBox3.Text == "")
                button6.Enabled = false;
            else button6.Enabled = true;

            if (comboBox4.SelectedIndex == -1 || textBox4.Text == "")
                button7.Enabled = false;
            else button7.Enabled = true;

            if (comboBox5.SelectedIndex == -1 || textBox5.Text == "")
                button8.Enabled = false;
            else button8.Enabled = true;

            if (comboBox6.SelectedIndex == -1 || textBox6.Text == "")
                button9.Enabled = false;
            else button9.Enabled = true;

            if (comboBox9.SelectedIndex == -1 )
                button10.Enabled = false;
            else button10.Enabled = true;
        }
    }

    public class TablessControl : TabControl
    {
        protected override void WndProc(ref Message m)
        {
            // Hide tabs by trapping the TCM_ADJUSTRECT message
            if (m.Msg == 0x1328 && !DesignMode) m.Result = (IntPtr)1;
            else base.WndProc(ref m);
        }
    }
}
