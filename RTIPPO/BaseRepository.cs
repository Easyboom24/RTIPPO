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
        private DbSet<Pets_Application>? Pets_Application { get; set; }
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
        private DbSet<Status_History>? Status_History { get; set; } 

        private string joinAnimal = " LEFT JOIN \"Animal\" ON \"Pets_Application\".\"Animal_FK\"=\"Animal\".\"Animal_Id\"";
        private string joinAnimalCategory = " LEFT JOIN \"Animal_Category\" ON \"Animal\".\"Category_FK\"=\"Animal_Category\".\"Category_Id\"";
        private string joinOrganization = " LEFT JOIN \"Organization\" ON \"Pets_Application\".\"Organization_FK\"=\"Organization\".\"Organization_Id\"";
        private string joinUrgency = " LEFT JOIN \"Urgency\" ON \"Pets_Application\".\"Urgency_FK\"=\"Urgency\".\"Urgency_Id\"";
        private string joinStatus = " LEFT JOIN \"Status\" ON \"Pets_Application\".\"Status_FK\"=\"Status\".\"Status_Id\"";
        private string joinLocality = " LEFT JOIN \"Locality\" ON \"Pets_Application\".\"Locality_FK\"=\"Locality\".\"Locality_Id\"";

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
            var status_history = this?.Status_History?.ToList();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
            => optionsBuilder
            .UseNpgsql("Host=localhost;Port=5432;Database=Pets;Username=postgres;Password=123123");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Status_History>()
            .HasKey(t => new { t.Pets_Application_Id, t.Status_Id });

            modelBuilder.Entity<Status_History>()
                    .HasOne(pt => pt.Status)
                    .WithMany(p=>p.Status_History)
                    .HasForeignKey(pt=>pt.Status_Id);

            modelBuilder.Entity<Status_History>()
                    .HasOne(pt => pt.Pets_Application)
                    .WithMany(p => p.Status_History)
                    .HasForeignKey(pt => pt.Pets_Application_Id);
        }

        public Pets_Application? GetApplication(int idApplication)
            => Pets_Application?.Where(a => a.Pets_Application_Id == idApplication).ToList().First();
        
        public List<Pets_Application>? GetAllApplications(int countApplications, Dictionary<string,string> sorting, Dictionary<string, Tuple<string, string, int>> filters)
        {
            string query = Create_Query_String(sorting, filters);
            return this.Pets_Application?.FromSqlRaw(query).Take(countApplications).ToList();
        }

        public void CreateApplication(Organization? org, Applicant? appt, Animal ani, Pets_Application appl)
        {
            if (org != null) Organization?.Add(org);
            if (appt != null) Applicant?.Add(appt);

            if (ani != null) Animal?.Add(ani);
            if (appl != null) Pets_Application?.Add(appl);
            SaveChanges();
        }

        public void UpdateApplication(Organization? organization, Applicant? applicant, Animal animal, Pets_Application application)
        {
            if (organization != null) Organization?.Update(organization);
            if (applicant != null) Applicant?.Update(applicant);
            if (animal != null) Animal?.Update(animal);
            if (application != null) Pets_Application?.Update(application);

            SaveChanges();
        }

        public User Authrization(string login, string password)
        {
            User user = new User();
            return user;
        }

        public void DeleteApplications(List<int> idApplications)
        {
            foreach(int idApplication in idApplications) {
                var application = Pets_Application?.Where(app => app.Pets_Application_Id == idApplication).First();
                if(application?.Status_FK == 1)
                    Pets_Application?.Remove(application);
            }
            SaveChanges();
        }

        public List<Pets_Application>? ExportToExcel(Dictionary<string, string> sorting, Dictionary<string, Tuple<string, string, int>> filters)
        {
            string query = Create_Query_String(sorting,filters);

            return this.Pets_Application?.FromSqlRaw(query).ToList();
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
            string query = "SELECT * FROM \"Pets_Application\"";
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
        
        private string Create_Query_SubString(string from) => $"SELECT * FROM \"{from}\"";
        
        public List<Locality>? GetAllLocality()
        {
            string query = Create_Query_SubString("Locality");
            return this.Locality?.FromSqlRaw(query).ToList();
        }

        public List<Status>? GetAllStatus()
        {
            string query = Create_Query_SubString("Status");
            return this.Status?.FromSqlRaw(query).ToList();
        }

        public List<Urgency>? GetAllUrgency()
        {
            string query = Create_Query_SubString("Urgency");
            return this.Urgency?.FromSqlRaw(query).ToList();
        }

        public List<Animal_Category>? GetAllAnimal_Category()
        {
            string query = Create_Query_SubString("Animal_Category");
            return this.Animal_Category?.FromSqlRaw(query).ToList();
        }

        public List<Animal_Wool>? GetAllAnimal_Wool()
        {
            string query = Create_Query_SubString("Animal_Wool");
            return this.Animal_Wool?.FromSqlRaw(query).ToList();
        }

        public List<Animal_Size>? GetAllAnimal_Size()
        {
            string query = Create_Query_SubString("Animal_Size");
            return this.Animal_Size?.FromSqlRaw(query).ToList();
        }

        public List<Animal_Sex>? GetAllAnimal_Sex()
        {
            string query = Create_Query_SubString("Animal_Sex");
            return this.Animal_Sex?.FromSqlRaw(query).ToList();
        }

        public List<Organization>? GetAllTrapOrg()
        {
            string query = "SELECT * FROM \"Organization\" WHERE \"Type_FK\" = 4";
            return this.Organization?.FromSqlRaw(query).ToList();
        }

        public Organization? GetOrganization(string? INN, int? id = null)
            => (id == null) ? ((Organization?.Where(a => a.INN == INN).ToList().Count != 0) ? Organization?.Where(a => a.INN == INN).ToList().First() : null) :
            Organization?.Where(a => a.Organization_Id == id).ToList().First();

        public Applicant? GetApplicant(string? phone, string? email, int? id = null)
            => (id == null) ?((Applicant?.Where(a => a.Applicant_Phone == phone && a.Applicant_Email == email).ToList().Count != 0) ? 
            Applicant?.Where(a => a.Applicant_Phone == phone && a.Applicant_Email == email).ToList().First() : null):
            Applicant?.Where(a => a.Applicant_Id == id).ToList().First();

        public Animal? GetAnimal(int id ) => Animal?.Where(a => a.Animal_Id == id).ToList().First();

        public int GetLastAnimal() => Animal.ToList().Max(p => p.Animal_Id);

        public int GetLastApplicant() => Applicant.ToList().Max(p => p.Applicant_Id);
    }
}
