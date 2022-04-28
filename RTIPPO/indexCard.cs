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
    public partial class indexCard : Form
    {
        public indexCard()
        {
            InitializeComponent();
        }

        private void edit_Click(object sender, EventArgs e)
        {
            dateApplication.Enabled = true;
            applicantCategory.Enabled = true;
            place.Enabled = true;
            habitat.Enabled = true;
            urgency.Enabled = true;
            trappingOrg.Enabled = true;
            status.Enabled = true;
            dateStatus.Enabled = true;
            /*exportWord.Enabled = false;
            delete.Enabled = false;
            edit.Enabled = false;*/
        }

        private void save_Click(object sender, EventArgs e)
        {
            /*dateApplication.Enabled = false;
            applicantCategory.Enabled = false;
            place.Enabled = false;
            habitat.Enabled = false;
            urgency.Enabled = false;
            trappingOrg.Enabled = false;
            status.Enabled = false;
            dateStatus.Enabled = false;
            exportWord.Enabled = true;*/
            delete.Enabled = true;
            edit.Enabled = true;
        }

        private void trappingOrg_TextChanged(object sender, EventArgs e)
        {

        }

        private void back_Click(object sender, EventArgs e) => Close();
    }
}
