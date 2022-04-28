using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTIPPO
{
    internal class ApplyApplicationsApi
    {
        private readonly BaseRepository repository = new BaseRepository();
        private readonly User user;

        public ApplyApplicationsApi(User user=null) 
        {
            
        }

        public Pets_Application GetApplication(BaseRepository repository,int numberApplication)
        {
           
            return repository.GetApplication(numberApplication);
        }

        public List<Pets_Application> GetAllApplications()// BaseRepository repository,Dictionary<string, string> filters,int countApplications)
        {
            var apps = repository.GetAllApplications();
            return apps.ToList();// filters, countApplications);
        }


        public void CreateApplication(BaseRepository repository,Pets_Application application)
        {
             repository.CreateApplication(application);
        }

        public void UpdateApplication(BaseRepository repository,Pets_Application application)
        {
            repository.UpdateApplication(application);
        }

        public void DeleteApplications(BaseRepository repository,List<Pets_Application> applications)
        {
            repository.DeleteApplications(applications);
        }

        public void ExportToExcel(BaseRepository repository,List<Pets_Application> applications)
        {
            repository.ExportToExcel(applications);
        }

        public User Authrization(BaseRepository repository, string login, string password)
        {
            
            return repository.Authrization(login, password);
        }


        public void ExportToWord(Pets_Application application)
        {

        }
    }
}
