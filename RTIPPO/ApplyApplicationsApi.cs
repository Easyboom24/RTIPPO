using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;

namespace RTIPPO
{
    internal class ApplyApplicationsApi
    {
        private readonly BaseRepository repository = new BaseRepository();

        public ApplyApplicationsApi() 
        {

        }
        public User? Authrization(string login, string password)
            => repository.Authrization(login, password);

        public Pets_Application? GetApplication(int idApplication) => repository.GetApplication(idApplication);
        
        public List<Pets_Application>? GetAllApplications(int countApplications, Dictionary<string,string> sorting, 
            Dictionary<string, Tuple<string, string, int>> filters)
            => repository.GetAllApplications(countApplications,sorting,filters);
        
        public void CreateApplication(Organization? organization, Applicant? applicant, Animal animal, Pets_Application application) => 
            repository.CreateApplication(organization, applicant, animal, application);

        public void UpdateApplication(Organization? organization, Applicant? applicant, Animal animal, Pets_Application application, Status_History? status_History) =>
            repository.UpdateApplication(organization, applicant, animal, application, status_History);

        public void DeleteApplications(List<int> applications) => repository.DeleteApplications(applications);
        
        public void ExportToExcel(Dictionary<string, string> sorting, Dictionary<string, Tuple<string, string, int>> filters)
        {
            var pathToDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var pathToFile = Path.Combine(pathToDesktop,"applications_data.xlsx");
            List<Pets_Application> applications = repository.ExportToExcel(sorting,filters);
            var workBook = new XLWorkbook();
            var workSheet = workBook.Worksheets.Add("Заявки на отлов");
            workSheet.Cell(1, 1).SetValue("Дата подачи заявки");
            workSheet.Cell(1, 2).SetValue("Номер заявки");
            workSheet.Cell(1, 3).SetValue("Категория заявителя");
            workSheet.Cell(1, 4).SetValue("Населенный пункт отлова");
            workSheet.Cell(1, 5).SetValue("Место обитания животного");
            workSheet.Cell(1, 6).SetValue("Категория животного");
            workSheet.Cell(1, 7).SetValue("Срочность исполнения");
            workSheet.Cell(1, 8).SetValue("Организация по отлову");
            workSheet.Cell(1, 9).SetValue("Текущий статус заявки");
            workSheet.Cell(1, 10).SetValue("Дата установки статуса");

            for (int i = 1; i <= applications?.Count; i++) 
            {
                workSheet.Cell(i + 1, 1).SetValue(applications?.ElementAt(i - 1).Filling_Date.ToString());
                workSheet.Cell(i + 1, 2).SetValue(applications?.ElementAt(i - 1).Application_Number);
                workSheet.Cell(i + 1, 3).SetValue(applications?.ElementAt(i - 1)?.Applicant?.Organization?.Type_Enterprise?.Type_Enterprise_Name ?? "Физ. лицо");
                workSheet.Cell(i + 1, 4)?.SetValue(applications?.ElementAt(i - 1)?.Locality?.Locality_Name);
                workSheet.Cell(i + 1, 5).SetValue(applications?.ElementAt(i - 1).Animal?.Habitat);
                workSheet.Cell(i + 1, 6).SetValue(applications?.ElementAt(i - 1)?.Animal?.Animal_Category?.Category_Name);
                workSheet.Cell(i + 1, 7).SetValue(applications?.ElementAt(i - 1)?.Urgency?.Urgency_Name);
                workSheet.Cell(i + 1, 8).SetValue(applications?.ElementAt(i - 1)?.Organization?.Organization_Name);
                workSheet.Cell(i + 1, 9).SetValue(applications?.ElementAt(i - 1)?.Status?.Status_Name);
                workSheet.Cell(i + 1, 10).SetValue(applications?.ElementAt(i - 1).Status_Date.ToString());
            }

            workBook.SaveAs(pathToFile);
        }

        public List<Locality>? GetAllLocality() => repository.GetAllLocality();
        public List<Status>? GetAllStatus() => repository.GetAllStatus();
        public List<Urgency>? GetAllUrgency() => repository.GetAllUrgency();
        public List<Animal_Category>? GetAllAnimal_Category() => repository.GetAllAnimal_Category();
        public List<Animal_Wool>? GetAllAnimal_Wool() => repository.GetAllAnimal_Wool();
        public List<Animal_Size>? GetAllAnimal_Size() =>repository.GetAllAnimal_Size();
        public List<Animal_Sex>? GetAllAnimal_Sex() => repository.GetAllAnimal_Sex();
        public List<Organization>? GetAllTrapOrg() => repository.GetAllTrapOrg();

        public int GetLastAnimal() => repository.GetLastAnimal();
        public int GetLastApplicant() => repository.GetLastApplicant();
        public Organization? GetOrganization(string? INN, int? id = null) => repository.GetOrganization(INN, id);
        public Applicant? GetApplicant(string? phone, string? email, int? id = null) => repository.GetApplicant(phone, email, id);
        public Animal? GetAnimal(int id) => repository.GetAnimal(id);
    }
}
