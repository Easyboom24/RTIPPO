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
        public Form3()
        {
            InitializeComponent();
            
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;
            comboBox6.SelectedIndex = 0;

            comboBox7.SelectedIndex = 1;
            comboBox8.SelectedIndex = 1;
            comboBox9.SelectedIndex = 1;
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = comboBox7.SelectedIndex;

            if (selectedIndex == 1) {
                label2.Show();
                dateTimePicker2.Show();
            }
            else {
                label2.Hide();
                dateTimePicker2.Hide();
            }
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = comboBox8.SelectedIndex;
            if(selectedIndex == 2) {
                numericUpDown2.Show();
                label4.Show();
            }
            else {
                numericUpDown2.Hide();
                label4.Hide();
            }
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = comboBox9.SelectedIndex;

            if (selectedIndex == 1)
            {
                label7.Show();
                dateTimePicker4.Show();
            }
            else
            {
                label7.Hide();
                dateTimePicker4.Hide();
            }
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
