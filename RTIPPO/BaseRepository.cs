using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore;
using System.Threading.Tasks;

namespace RTIPPO
{
    internal class BaseRepository : DbContext
    {
        //NpgsqlConnection Npgsql = new NpgsqlConnection();
        
        public DbSet<Pets_Application> Apps { get; set; }

        public BaseRepository()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
            => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Pets;Username;Password=123123");

      
        public Pets_Application GetApplication(int numberApplication) {
            Pets_Application ap = new Pets_Application();
            return ap;
        }

        public List<Pets_Application> GetAllApplications()//Dictionary<string,string> filters,int countApplications)
        {
            List<Pets_Application> ap = new List<Pets_Application>();

            return ap;
        }

        public void CreateApplication(Pets_Application application)
        {
           
        }

        public void UpdateApplication(Pets_Application application)
        {

        }

        public void DeleteApplications(List<Pets_Application> applications)
        {

        }

        public void ExportToExcel(List<Pets_Application> application)
        {

        }

        public User Authrization(string login, string password)
        {
            User user = new User();
            return user;
        }
    }
}
