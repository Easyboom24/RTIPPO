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
        private DbSet<Pets_Application>? Application { get; set; }
        private DbSet<Status>? Status { get; set; }
        private DbSet<Applicant>? Applicant { get; set; }
        private DbSet<Urgency>? Urgency { get; set; }
        private DbSet<Organization>? Organization { get; set; }
        private DbSet<Animal>? Animal { get; set; }
        private DbSet<Animal_Category>? Animal_Category { get; set; }
        private DbSet<Animal_Sex>? Animal_Sex { get; set; }
        private DbSet<Animal_Size>? Animal_Size { get; set; }
        private DbSet<Animal_Wool>? Animal_Wool { get; set; }
        private DbSet<Type_Enterprise>? Type_Enterprise { get; set; }
        private DbSet<Locality>? Locality { get; set; }
        private DbSet<Municipality>? Municipality { get; set; }

        private string joinAnimal = " LEFT JOIN \"Animal\" ON \"Application\".\"Animal_FK\"=\"Animal\".\"Animal_Id\"";
        private string joinAnimalCategory = " LEFT JOIN \"Animal_Category\" ON \"Animal\".\"Category_FK\"=\"Animal_Category\".\"Category_Id\"";
        private string joinOrganization = " LEFT JOIN \"Organization\" ON \"Application\".\"Organization_FK\"=\"Organization\".\"Organization_Id\"";
        private string joinUrgency = " LEFT JOIN \"Urgency\" ON \"Application\".\"Urgency_FK\"=\"Urgency\".\"Urgency_Id\"";
        private string joinStatus = " LEFT JOIN \"Status\" ON \"Application\".\"Status_FK\"=\"Status\".\"Status_Id\"";
        private string joinLocality = " LEFT JOIN \"Locality\" ON \"Application\".\"Locality_FK\"=\"Locality\".\"Locality_Id\"";

        public BaseRepository() 
        {
            var statuses = this?.Status?.ToList();
            var animals = this?.Animal?.ToList();
            var animal_categories = this?.Animal_Category?.ToList();
            var animal_wools = this?.Animal_Wool?.ToList();
            var animal_size = this?.Animal_Size?.ToList();
            var animal_sex = this?.Animal_Sex?.ToList();
            var organizations = this?.Organization?.ToList();
            var applicants = this?.Applicant?.ToList();
            var urgencies = this?.Urgency?.ToList();
            var localities = this?.Locality?.ToList();
            var municipalities = this?.Municipality?.ToList();
            var enterprises = this?.Type_Enterprise?.ToList();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
            => optionsBuilder
            .UseNpgsql("Host=localhost;Port=5432;Database=Pets;Username=postgres;Password=123123");

        public Pets_Application? GetApplication(int idApplication)
            => Application?.Where(a => a.Application_Id == idApplication).ToList().First();
        

        public List<Pets_Application>? GetAllApplications(int countApplications, Dictionary<string,string> sorting, Dictionary<string, Tuple<string, string, int>> filters)
        {
            string query = Create_Query_String(sorting, filters);
            return this.Application?.FromSqlRaw(query).Take(countApplications).ToList();
        }

        public void CreateApplication(Pets_Application application)
        {
           
        }

        public void UpdateApplication(Pets_Application application)
        {

        }

        public void DeleteApplications(List<int> idApplications)
        {
            foreach(int idApplication in idApplications) {
                var application = Application?.Where(app => app.Application_Id == idApplication).First();
                if(application?.Status_FK == 1)
                    Application?.Remove(application);
            }
            SaveChanges();
        }

        public List<Pets_Application>? ExportToExcel(Dictionary<string, string> sorting, Dictionary<string, Tuple<string, string, int>> filters)
        {
            string query = Create_Query_String(sorting,filters);

            return this.Application?.FromSqlRaw(query).ToList();
        }

        private string Sorted(Dictionary<string, string> sorting) 
        {
            string sorting_query = " ORDER BY ";
           
            foreach (var sort in sorting)
            {
                if (sorting.Last().Equals(sort))
                    sorting_query += "\"" + sort.Key + "\" " + sort.Value;
                else
                    sorting_query += "\"" + sort.Key + "\" " + sort.Value + ", ";
            }
            return sorting_query;
        }

        private string Filtration(Dictionary<string, Tuple<string, string, int>> filters) 
        {
            string filtration_query = " WHERE ";

            foreach (var filter in filters) 
            {
                if (filters.Last().Equals(filter))
                    filtration_query += "\"" + filter.Key + "\" " + filter.Value.Item1 + " " + "\'" + filter.Value.Item2 + "\'";
                else
                    filtration_query +=  "\"" + filter.Key + "\" " + filter.Value.Item1 + " " + "\'" + filter.Value.Item2 + "\'" + " AND ";
            }
            return filtration_query;
        }

        private string Create_Query_String(Dictionary<string, string> sorting, Dictionary<string, Tuple<string, string, int>> filters) 
        {
            string query = "SELECT * FROM \"Application\"";
            string filters_query = "";
            string sorting_query = "";

            if (filters.Count != 0 || sorting.Count != 0)
            {
                if (filters.ContainsKey("Habitat") || filters.ContainsKey("Category_Name") || sorting.ContainsKey("Habitat"))
                    query += joinAnimal;

                if (filters.ContainsKey("Category_Name"))
                    query += joinAnimalCategory;

                if (filters.ContainsKey("Status_Name") || filters.ContainsKey("Status_Id"))
                    query += joinStatus;

                if (filters.ContainsKey("Urgency_Name"))
                    query += joinUrgency;

                if (filters.ContainsKey("Locality_Name"))
                    query += joinLocality;

                if (filters.ContainsKey("Organization_Name"))
                    query += joinOrganization;

                if (sorting.Count != 0)
                    sorting_query = Sorted(sorting);

                if (filters.Count != 0)
                    filters_query = Filtration(filters);
            }
            query += filters_query;
            query += sorting_query;

            return query;
        }
        
        public User Authrization(string login, string password)
        {
            User user = new User();
            return user;
        }
    }
}
