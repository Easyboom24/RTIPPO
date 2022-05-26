using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace RTIPPO
{
    public partial class indexCard : Form
    {
        ApplyApplicationsApi Api = new ApplyApplicationsApi();
        internal Pets_Application application;
        internal User? user;
        private Status_History? status_History = new Status_History();
        public bool enableBool;

        public indexCard()
        {
            InitializeComponent();
        }
        private void indexCard_Load(object sender, EventArgs e)
        {
            inverse_enable();
            fill_combobox();

            if (applicantCategory.Text == "Юр.лицо" && !INN.Visible) applicantCategory_Visible();

            if (application != null)
            {
                edit_Visible();

                regNum.Text = application.Application_Number.ToString();
                dateApplication.Value = application.Filling_Date.ToDateTime(new TimeOnly(0));
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

                if (application?.Status_History != null)
                    foreach (var status in application?.Status_History)
                        history_status_textbox.Text += status.Status.Status_Name + "-" + status.Current_Date_Status + Environment.NewLine;

                history_status_textbox.ReadOnly = true;

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
                addressUr.Text = application?.Applicant?.Organization?.Address ?? "";
                surDirector.Text = application?.Applicant?.Organization?.Surname_Director ?? "";
                firDirector.Text = application?.Applicant?.Organization?.Firstname_Director ?? "";
                patDirector.Text = application?.Applicant?.Organization?.Patronymic_Director ?? "";
            }

            if (user != null && user.Role_FK != 7)
            {
                edit_Visible();
                createAp.Visible = false;
                exportWord.Visible = true;
            }
        }

        private void inverse_enable()
        {
            applicantCategory.Enabled = enableBool;
            place.ReadOnly = !enableBool;
            trappingOrg.Enabled = enableBool;
            status.Enabled = enableBool;
            regNum.ReadOnly = !enableBool;
            surname.ReadOnly = !enableBool;
            firstname.ReadOnly = !enableBool;
            patronymic.ReadOnly = !enableBool;
            phone.ReadOnly = !enableBool;
            email.ReadOnly = !enableBool;
            address.ReadOnly = !enableBool;

            habitat.ReadOnly = !enableBool;
            category.Enabled = enableBool;
            wool.Enabled = enableBool;
            urgency.Enabled = enableBool;
            sex.Enabled = enableBool;
            ears.ReadOnly = !enableBool;
            signs.ReadOnly = !enableBool;
            reason.ReadOnly = !enableBool;
            tail.ReadOnly = !enableBool;
            color.ReadOnly = !enableBool;
            sizeAnimal.Enabled = enableBool;


            exportWord.Enabled = !enableBool;
            delete.Enabled = !enableBool;
            edit.Enabled = !enableBool;
            save.Enabled = enableBool;

            INN.ReadOnly = !enableBool;
            KPP.ReadOnly = !enableBool;
            name.ReadOnly = !enableBool;
            phoneUr.ReadOnly = !enableBool;
            addressUr.Enabled = enableBool;
            surDirector.ReadOnly = !enableBool;
            firDirector.ReadOnly = !enableBool;
            patDirector.ReadOnly = !enableBool;
        }

        private void fill_combobox()
        {
            var sourse = Api.GetAllStatus();

            Dictionary<int, string> comboBoxSource = new Dictionary<int, string>(sourse.Count);
            foreach (var i in sourse)
                comboBoxSource.Add(i.Status_Id, i.Status_Name);

            status.DataSource = new BindingSource(comboBoxSource, null);
            status.DisplayMember = "Value";
            status.ValueMember = "Key";

            var sourseCat = Api.GetAllAnimal_Category();

            comboBoxSource = new Dictionary<int, string>(sourseCat.Count);
            foreach (var i in sourseCat)
                comboBoxSource.Add(i.Category_Id, i.Category_Name);

            category.DataSource = new BindingSource(comboBoxSource, null);
            category.DisplayMember = "Value";
            category.ValueMember = "Key";

            var sourseAnSex = Api.GetAllAnimal_Sex();

            comboBoxSource = new Dictionary<int, string>(sourseAnSex.Count);
            foreach (var i in sourseAnSex)
                comboBoxSource.Add(i.Sex_Id, i.Sex_Name);

            sex.DataSource = new BindingSource(comboBoxSource, null);
            sex.DisplayMember = "Value";
            sex.ValueMember = "Key";

            var sourseAnSize = Api.GetAllAnimal_Size();

            comboBoxSource = new Dictionary<int, string>(sourseAnSize.Count);
            foreach (var i in sourseAnSize)
                comboBoxSource.Add(i.Size_Id, i.Size_Name);

            sizeAnimal.DataSource = new BindingSource(comboBoxSource, null);
            sizeAnimal.DisplayMember = "Value";
            sizeAnimal.ValueMember = "Key";

            var sourseAnWool = Api.GetAllAnimal_Wool();

            comboBoxSource = new Dictionary<int, string>(sourseAnWool.Count);
            foreach (var i in sourseAnWool)
                comboBoxSource.Add(i.Wool_Id, i.Wool_Name);

            wool.DataSource = new BindingSource(comboBoxSource, null);
            wool.DisplayMember = "Value";
            wool.ValueMember = "Key";

            var sourseLoc = Api.GetAllLocality();

            comboBoxSource = new Dictionary<int, string>(sourseLoc.Count);
            foreach (var i in sourseLoc)
                comboBoxSource.Add(i.Locality_Id, i.Locality_Name);

            addressUr.DataSource = new BindingSource(comboBoxSource, null);
            addressUr.DisplayMember = "Value";
            addressUr.ValueMember = "Key";

            var sourseUrgency = Api.GetAllUrgency();

            comboBoxSource = new Dictionary<int, string>(sourseUrgency.Count);
            foreach (var i in sourseUrgency)
                comboBoxSource.Add(i.Urgency_Id, i.Urgency_Name);

            urgency.DataSource = new BindingSource(comboBoxSource, null);
            urgency.DisplayMember = "Value";
            urgency.ValueMember = "Key";

            var sourseTrap = Api.GetAllTrapOrg();

            comboBoxSource = new Dictionary<int, string>(sourseTrap.Count);
            foreach (var i in sourseTrap)
                comboBoxSource.Add(i.Organization_Id, i.Organization_Name);

            trappingOrg.DataSource = new BindingSource(comboBoxSource, null);
            trappingOrg.DisplayMember = "Value";
            trappingOrg.ValueMember = "Key";
        }


        private void save_Click(object sender, EventArgs e)
        {
            try
            {
                enableBool = false;
                inverse_enable();

                Applicant? applicant = Api.GetApplicant(phone.Text, email.Text, application.Applicant_FK);
                if (applicant != null)
                {
                    applicant.Applicant_Phone = phone.Text;
                    applicant.Applicant_Email = email.Text;
                    applicant.Applicant_Surname = surname.Text;
                    applicant.Applicant_Firstname = firstname.Text;
                    applicant.Applicant_Patronymic = patronymic.Text ?? null;
                    applicant.Applicant_Address = address.Text ?? null;
                };

                Animal animal = Api.GetAnimal(application.Animal_FK);

                if (animal != null)
                {
                    animal.Sex_FK = ((KeyValuePair<int, string>)sex.SelectedItem).Key;
                    animal.Size_FK = ((KeyValuePair<int, string>)sizeAnimal.SelectedItem).Key;
                    animal.Wool_FK = ((KeyValuePair<int, string>)wool.SelectedItem).Key;
                    animal.Color = color.Text;
                    animal.Ears = ears.Text;
                    animal.Tail = tail.Text;
                    animal.Habitat = habitat.Text;
                    animal.Signs = signs.Text;
                    animal.Category_FK = ((KeyValuePair<int, string>)category.SelectedItem).Key;
                };

                Organization? organization = (INN.Text != null) ? Api.GetOrganization(INN.Text, applicant.Applicant_Organization_FK) : null;
                if (organization != null)
                {
                    organization.INN = INN.Text;
                    organization.KPP = KPP.Text;
                    organization.Organization_Name = name.Text;
                    organization.Address = ((KeyValuePair<int, string>)addressUr.SelectedItem).Value ?? null;
                    organization.Phone = phoneUr.Text ?? null;
                    organization.Surname_Director = surDirector.Text ?? null;
                    organization.Firstname_Director = firDirector.Text ?? null;
                    organization.Patronymic_Director = patDirector.Text ?? null;
                    organization.Organization_Locality_FK = ((KeyValuePair<int, string>)addressUr.SelectedItem).Key;
                }

                if (application != null)
                {
                    application.Application_Number = int.Parse(regNum.Text);
                    application.Organization_FK = ((KeyValuePair<int, string>)trappingOrg.SelectedItem).Key;
                    application.Status_FK = ((KeyValuePair<int, string>)status.SelectedItem).Key;
                    application.Status_Date = DateOnly.FromDateTime(dateStatus.Value);
                    application.Urgency_FK = ((KeyValuePair<int, string>)urgency.SelectedItem).Key;
                    application.Reason = reason.Text;
                };

                if (application != null)
                {
                    Api.UpdateApplication(organization, applicant, animal, application, status_History);
                    MessageBox.Show($"Данные обновлены");
                    this.Close();
                }

            }
            catch { MessageBox.Show("Проверьте данные"); }
        }

        private void edit_Click(object sender, EventArgs e)
        {
            enableBool = true;
            inverse_enable();
        }
        private void createAp_Click(object sender, EventArgs e)
        {
            try
            {
                int? idOrg = (Api.GetOrganization(INN.Text) != null) ? Api.GetOrganization(INN.Text).Organization_Id : null;
                int idAnimal = Api.GetLastAnimal() + 1;

                var idApp = Api.GetApplicant(phone.Text, email.Text);
                int idApplicant = (idApp != null) ? idApp.Applicant_Id : Api.GetLastApplicant() + 1;

                Organization? organization = (idOrg != null) ? null :
                    new Organization
                    {
                        INN = INN.Text,
                        KPP = KPP.Text,
                        Organization_Name = name.Text,
                        Address = ((KeyValuePair<int, string>)addressUr.SelectedItem).Value ?? null,
                        Phone = phoneUr.Text ?? null,
                        Surname_Director = surDirector.Text ?? null,
                        Firstname_Director = firDirector.Text ?? null,
                        Patronymic_Director = patDirector.Text ?? null,
                        Type_FK = 12,
                        Organization_Locality_FK = ((KeyValuePair<int, string>)addressUr.SelectedItem).Key,
                        Type_Enterprise_FK = 1,

                    };

                Applicant? applicant = (idApp != null) ? null :
                    new Applicant
                    {
                        Applicant_Id = idApplicant,
                        Applicant_Phone = phone.Text,
                        Applicant_Email = email.Text,
                        Applicant_Surname = surname.Text,
                        Applicant_Firstname = firstname.Text,
                        Applicant_Patronymic = patronymic.Text ?? null,
                        Applicant_Address = address.Text ?? null,
                        Applicant_Organization_FK = idOrg
                    };

                Animal animal = new Animal
                {
                    Animal_Id = idAnimal,
                    Sex_FK = ((KeyValuePair<int, string>)sex.SelectedItem).Key,
                    Size_FK = ((KeyValuePair<int, string>)sizeAnimal.SelectedItem).Key,
                    Wool_FK = ((KeyValuePair<int, string>)wool.SelectedItem).Key,
                    Color = color.Text,
                    Ears = ears.Text,
                    Tail = tail.Text,
                    Habitat = habitat.Text,
                    Signs = signs.Text,
                    Category_FK = ((KeyValuePair<int, string>)category.SelectedItem).Key
                };

                Pets_Application? newApplication = new Pets_Application
                {
                    Application_Number = int.Parse(regNum.Text),
                    Filling_Date = DateOnly.FromDateTime(dateApplication.Value),
                    Animal_FK = idAnimal,
                    Locality_FK = ((KeyValuePair<int, string>)addressUr.SelectedItem).Key,
                    Organization_FK = ((KeyValuePair<int, string>)trappingOrg.SelectedItem).Key,
                    Status_FK = ((KeyValuePair<int, string>)status.SelectedItem).Key,
                    Status_Date = DateOnly.FromDateTime(dateStatus.Value),
                    Urgency_FK = ((KeyValuePair<int, string>)urgency.SelectedItem).Key,
                    Applicant_FK = idApplicant,
                    Reason = reason.Text
                };

                MessageBox.Show($"Заявка добавлена");
                Api.CreateApplication(organization, applicant, animal, newApplication);
                this.Close();

            }
            catch { MessageBox.Show("Проверьте данные"); }
        }

        private void delete_Click(object sender, EventArgs e)
        {

            List<int> idApps = new List<int>();
            idApps.Add(application.Pets_Application_Id);

            Form2 f2 = new Form2();
            f2.idDeleted = idApps;
            f2.ShowDialog();
            this.Close();
        }

        private void back_Click(object sender, EventArgs e) => Close();


        private void applicantCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (applicantCategory.Text == "Юр.лицо" && !INN.Visible) applicantCategory_Visible();
            if (applicantCategory.Text == "Физ.лицо" && INN.Visible) applicantCategory_Visible();
        }

        private void applicantCategory_Visible()
        {
            INN.Visible = !INN.Visible;
            KPP.Visible = !KPP.Visible;
            name.Visible = !name.Visible;
            phoneUr.Visible = !phoneUr.Visible;
            addressUr.Visible = !addressUr.Visible;
            surDirector.Visible = !surDirector.Visible;
            firDirector.Visible = !firDirector.Visible;
            patDirector.Visible = !patDirector.Visible;

            label25.Visible = !label25.Visible;
            label26.Visible = !label26.Visible;
            label27.Visible = !label27.Visible;
            label28.Visible = !label28.Visible;
            label33.Visible = !label33.Visible;
            label34.Visible = !label34.Visible;
            label35.Visible = !label35.Visible;
            label36.Visible = !label36.Visible;
        }

        private void edit_Visible()
        {
            exportWord.Visible = !exportWord.Visible;
            edit.Visible = !edit.Visible;
            save.Visible = !save.Visible;
            delete.Visible = !delete.Visible;
            createAp.Visible = !createAp.Visible;
        }


        private void exportWord_Click(object sender, EventArgs e)
        {
            if (applicant != null)
            {
                var helper = new WordHelper("zayavka.docx");

                var items = new Dictionary<string, string>
                {
                    { "<RegNum>", regNum.Text },
                    { "<DateApplication>", dateApplication.Text },
                    { "<TrappingOrg>", trappingOrg.Text },
                    { "<Urgency>", urgency.Text },
                    { "<Place>", place.Text },
                    { "<Habitat>", habitat.Text },
                    { "<Reason>", reason.Text },
                    { "<Category>", category.Text },
                    { "<Sex>", sex.Text },
                    { "<SizeAnimal>", sizeAnimal.Text },
                    { "<Wool>", wool.Text },
                    { "<Color>", color.Text },
                    { "<Ears>", ears.Text },
                    { "<Tail>", tail.Text },
                    { "<Signs>", signs.Text },
                };

                helper.Process(items);
            }
        }

        private void status_SelectedIndexChanged(object sender, EventArgs e)
        {
            dateStatus.Value = DateTime.Now;
            if (status.Text != null && application != null)
            {
                status_History.Status_Id = ((KeyValuePair<int, string>)status.SelectedItem).Key;
                status_History.Pets_Application_Id = application.Pets_Application_Id;
                status_History.Current_Date_Status = DateOnly.FromDateTime(dateStatus.Value);
            };
        }
    }
}
