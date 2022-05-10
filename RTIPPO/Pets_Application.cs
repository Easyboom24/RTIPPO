using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTIPPO
{
    internal class Pets_Application
    {
        [Key]
        public int Pets_Application_Id { get; set; }
        public int Application_Number { get; set; }
        public DateOnly Filling_Date { get; set; }

        [ForeignKey("Animal")]
        public int Animal_FK { get; set; }
        public Animal? Animal { get; set; }


        [ForeignKey("Locality")]
        public int Locality_FK { get; set; }
        public Locality? Locality { get; set; }

        [ForeignKey("Organization")]
        public int Organization_FK { get; set; }
        public Organization? Organization { get; set; }

        [ForeignKey("Status")]
        public int Status_FK { get; set; }
        public Status? Status { get; set; }
        public DateOnly Status_Date { get; set; }

        [ForeignKey("Urgency")]
        public int Urgency_FK { get; set; }
        public Urgency? Urgency { get; set; }

        [ForeignKey("Applicant")]
        public int Applicant_FK { get; set; }
        public Applicant? Applicant { get; set; }
        public string? Reason { get; set; }
        public List<Status_History> Status_History { get; set; }
    }
}
