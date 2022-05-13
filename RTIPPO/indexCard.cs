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
                regNum.ReadOnly = true;
                dateApplication.Value =  application.Filling_Date.ToDateTime(new TimeOnly(0));
                dateApplication.Enabled = false;
                trappingOrg.Text = application?.Organization?.Organization_Name ?? "";
                trappingOrg.ReadOnly = true;
                status.Text = application?.Status?.Status_Name ?? "";
                status.Enabled = false;
                dateStatus.Value = application.Status_Date.ToDateTime(new TimeOnly(0));
                dateStatus.Enabled = false;
                place.Text = application?.Locality?.Locality_Name ?? "";
                place.ReadOnly = true;
            
                habitat.Text = application?.Animal?.Habitat ?? "";
                habitat.ReadOnly = true;
                category.Text = application?.Animal?.Animal_Category?.Category_Name ?? "";
                category.Enabled = false;
                wool.Text = application?.Animal?.Animal_Wool?.Wool_Name ?? "";
                wool.Enabled = false;
                ears.Text = application?.Animal?.Ears ?? "";
                ears.ReadOnly = true;
                sizeAnimal.Text = application?.Animal?.Animal_Size?.Size_Name ?? "";
                sizeAnimal.ReadOnly = true;
                color.Text = application?.Animal?.Color ?? "";
                color.ReadOnly = true;
                tail.Text = application?.Animal?.Tail ?? "";
                tail.ReadOnly = true;
                signs.Text = application?.Animal?.Signs ?? "";
                signs.ReadOnly = true;
                urgency.Text = application?.Urgency?.Urgency_Name ?? "";
                urgency.Enabled = false;
                reason.Text = application?.Reason ?? "";
                reason.ReadOnly = true;
                sex.Text = application?.Animal?.Animal_Sex?.Sex_Name ?? "";
                sex.Enabled = false;

                foreach (var status in application?.Status_History)
                    history_status_textbox.Text += status.Status.Status_Name+ "-" + status.Current_Date_Status + Environment.NewLine;

                history_status_textbox.ReadOnly = true;

                surname.Text = application?.Applicant?.Applicant_Surname ?? "";
                surname.ReadOnly = true;
                firstname.Text = application?.Applicant?.Applicant_Firstname ?? "";
                firstname.ReadOnly = true;
                patronymic.Text = application?.Applicant?.Applicant_Patronymic ?? "";
                patronymic.ReadOnly = true;
                phone.Text = application?.Applicant?.Applicant_Phone ?? "";
                phone.ReadOnly = true;
                email.Text = application?.Applicant?.Applicant_Email ?? "";
                email.ReadOnly = true;
                address.Text = application?.Applicant?.Applicant_Address ?? "";
                address.ReadOnly = true;

                applicantCategory.Text = application?.Applicant?.Organization?.Type_Enterprise.Type_Enterprise_Name ?? "Физ. лицо";
                applicantCategory.Enabled = false;

                INN.Text = application?.Applicant?.Organization?.INN ?? "";
                INN.ReadOnly = true;
                KPP.Text = application?.Applicant?.Organization?.KPP ?? "";
                KPP.ReadOnly = true;
                name.Text = application?.Applicant?.Organization?.Organization_Name ?? "";
                name.ReadOnly = true;
                phoneUr.Text = application?.Applicant?.Organization?.Phone ?? "";
                phoneUr.ReadOnly = true;
                //emailUr.Text = application?.Organization?.
                addressUr.Text = application?.Applicant?.Organization?.Address ?? "";
                addressUr.ReadOnly = true;
                surDirector.Text = application?.Applicant?.Organization?.Surname_Director ?? "";
                surDirector.ReadOnly = true;
                firDirector.Text = application?.Applicant?.Organization?.Firstname_Director ?? "";
                firDirector.ReadOnly = true;
                patDirector.Text = application?.Applicant?.Organization?.Patronymic_Director ?? "";
                patDirector.ReadOnly = true;
            }

        }
    }
}
