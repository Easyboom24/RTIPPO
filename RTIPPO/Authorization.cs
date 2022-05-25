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
    public partial class Authorization : Form
    {
        ApplyApplicationsApi Api = new ApplyApplicationsApi();
        private User? user;
        public Authorization()
        {
            InitializeComponent();
        }

        private void authorizate_Click(object sender, EventArgs e)
        {
            user = Api.Authrization(login.Text, password.Text);
            back_Click(sender, e);
        }

        private void back_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.user = user;
            this.Hide();
            f1.ShowDialog();
            this.Close();
        }
    }
}
