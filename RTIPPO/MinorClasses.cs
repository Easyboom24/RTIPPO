using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTIPPO
{
    internal class Animal
    {
        public int Animal_Id { get; set; }
        public string Sex { get; set; }
        public string Size_FK { get; set; }
        public string Wool_FK { get; set; }
        public string Color { get; set; }
        public string Ears { get; set; }
        public string Tail { get; set; }
        public string Habibat { get; set; }
        public string Signs { get; set; }
        public string Category_FK { get; set; }

    }

    internal class Organization 
    {
        public int Organization_Id { get; set; }
        public string INN { get; set; }
        public string KPP { get; set; }
        public string Organization_Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Surname_Director { get; set; }
        public string Firstname_Director { get; set; }
        public string Patronymic_Director { get; set; }
        public string Type_FK { get; set; }
        public string Locality_FK { get; set; }
        public string Type_Enterprise_FK { get; set; }

    }

    internal class Applicant 
    {
        public string Applicant_Id { get; set; }
        public string Applicant_Phone { get; set; }
        public string Applicant_Email { get; set; }
        public string Applicant_Surname { get; set; }
        public string Applicant_Firstname { get; set; }
        public string Applicant_Patronymic { get; set; }
        public string Applicant_Address { get; set; }
        public Organization Organization_FK { get; set; }

    }   
}
