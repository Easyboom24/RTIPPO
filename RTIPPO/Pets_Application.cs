using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTIPPO
{
    internal class Pets_Application
    {
        public int Application_Id { get; set; }
        public int Application_Number { get; set; }
        public DateTime Filling_Date { get; set; }
        public Animal Animal_FK { get; set; }
        public string Locality_FK { get; set; }
        public Organization Orgnization_FK { get; set; }
        public string Status { get; set; }
        public DateTime Status_Date { get; set; }
        public string Urgency { get; set; }
        public Applicant Applicant_FK { get; set; }
        public string Reason { get; set; }
    }
}
