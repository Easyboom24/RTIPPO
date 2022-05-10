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
        ApplyApplicationsApi Api = new ApplyApplicationsApi();
        internal Pets_Application application;
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

        private void indexCard_Load(object sender, EventArgs e)
        {
            if(application != null) 
            { 
                regNum.Text =  application.Application_Number.ToString();
                dateApplication.Value =  application.Filling_Date.ToDateTime(new TimeOnly(0));
                trappingOrg.Text = application?.Organization?.Organization_Name ?? "";
                status.Text = application?.Status?.Status_Name ?? "";
                dateStatus.Value = application.Status_Date.ToDateTime(new TimeOnly(0));
                place.Text = application?.Locality?.Locality_Name ?? "";
            
                habitat.Text = application?.Animal?.Habitat ?? "";
                category.Text = application?.Animal?.Animal_Category?.Category_Name ?? "";
                wool.Text = application?.Animal?.Animal_Wool?.Wool_Name ?? "";
                ears.Text = application?.Animal?.Ears ?? "";
                sizeAnimal.Text = application?.Animal?.Animal_Size?.Size_Name ?? "";
                color.Text = application?.Animal?.Color ?? "";
                tail.Text = application?.Animal?.Tail ?? "";
                signs.Text = application?.Animal?.Signs ?? "";
                urgency.Text = application?.Urgency?.Urgency_Name ?? "";
                reason.Text = application?.Reason ?? "";
                sex.Text = application?.Animal?.Animal_Sex?.Sex_Name ?? "";

                foreach (var status in application?.Status_History)
                    history_status_textbox.Text += status.Status.Status_Name+ "-" + status.Current_Date_Status + Environment.NewLine;

                surname.Text = application?.Applicant?.Applicant_Surname ?? "";
                firstname.Text = application?.Applicant?.Applicant_Firstname ?? "";
                patronymic.Text = application?.Applicant?.Applicant_Patronymic ?? "";
                phone.Text = application?.Applicant?.Applicant_Phone ?? "";
                email.Text = application?.Applicant?.Applicant_Email ?? "";
                address.Text = application?.Applicant?.Applicant_Address ?? "";

                applicantCategory.Text = application?.Applicant?.Organization?.Type_Enterprise.Type_Enterprise_Name ?? "Физ. лицо";
           
                INN.Text = application?.Applicant?.Organization?.INN ?? "";
                KPP.Text = application?.Applicant?.Organization?.KPP ?? "";
                name.Text = application?.Applicant?.Organization?.Organization_Name ?? "";
                phoneUr.Text = application?.Applicant?.Organization?.Phone ?? "";
                //emailUr.Text = application?.Organization?.
                addressUr.Text = application?.Applicant?.Organization?.Address ?? "";
                surDirector.Text = application?.Applicant?.Organization?.Surname_Director ?? "";
                firDirector.Text = application?.Applicant?.Organization?.Firstname_Director ?? "";
                patDirector.Text = application?.Applicant?.Organization?.Patronymic_Director ?? "";
            }

        }
    }
}
