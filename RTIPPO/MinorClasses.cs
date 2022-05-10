using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTIPPO
{
    internal class Animal
    {
        [Key]
        public int Animal_Id { get; set; }

        [ForeignKey("Animal_Sex")]
        public int Sex_FK { get; set; }
        public Animal_Sex? Animal_Sex { get; set; }

        [ForeignKey("Animal_Size")]
        public int? Size_FK { get; set; }
        public Animal_Size? Animal_Size { get; set; }

        [ForeignKey("Animal_Wool")]
        public int? Wool_FK { get; set; }
        public Animal_Wool? Animal_Wool { get; set; }
        public string? Color { get; set; }
        public string? Ears { get; set; }
        public string? Tail { get; set; }
        public string? Habitat { get; set; }
        public string? Signs { get; set; } 

        [ForeignKey("Animal_Category")]
        public int Category_FK { get; set; }
        public Animal_Category? Animal_Category { get; set; }

    }

    internal class Animal_Category 
    {
        [Key]
        public int Category_Id { get; set; }
        public string? Category_Name { get; set; }
    }

    internal class Animal_Size
    {
        [Key]
        public int Size_Id { get; set; }
        public string? Size_Name { get; set; }
    }

    internal class Animal_Wool
    {
        [Key] 
        public int  Wool_Id { get; set; }
        public string? Wool_Name { get; set; }
    }

    internal class Animal_Sex
    {
        [Key]
        public int Sex_Id { get; set; }
        public string? Sex_Name { get; set; }
    }

    internal class Locality
    {
        [Key]
        public int Locality_Id { get; set; }
        public string? Locality_Name { get; set; }

        [ForeignKey("Municipality")]
        public int? Municipality_FK { get; set; }
        public Municipality? Municipality { get; set; }
    }

    internal class Municipality 
    {
        [Key]
        public int Municipality_Id { get; set; }
        public string? Municipality_Name { get; set; }
    }

    internal class Status 
    {
        [Key]
        public int Status_Id { get; set; }
        public string? Status_Name { get; set; }
    }

    internal class Organization 
    {
        [Key]
        public int Organization_Id { get; set; }
        public string? INN { get; set; }
        public string? KPP { get; set; }
        public string? Organization_Name { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Surname_Director { get; set; }
        public string? Firstname_Director { get; set; }
        public string? Patronymic_Director { get; set; }
        public int Type_FK { get; set; }

        [ForeignKey("Locality")]
        public int Organization_Locality_FK { get; set; }
        public Locality? Locality { get; set; }

        [ForeignKey("Type_Enterprise")]
        public int Type_Enterprise_FK { get; set; }
        public Type_Enterprise? Type_Enterprise { get; set; }

    }

    internal class Applicant 
    {
        [Key]
        public int Applicant_Id { get; set; }
        public string? Applicant_Phone { get; set; }
        public string? Applicant_Email { get; set; }
        public string? Applicant_Surname { get; set; }
        public string? Applicant_Firstname { get; set; }
        public string? Applicant_Patronymic { get; set; }
        public string? Applicant_Address { get; set; }

        [ForeignKey("Organization")]
        public int? Applicant_Organization_FK { get; set; }
        public Organization? Organization { get; set; }
    }

    internal class Type_Enterprise
    {
        [Key]
        public int Type_Enterprise_Id { get; set; }
        
        public string? Type_Enterprise_Name { get; set; }
    }

    internal class Urgency
    {
        [Key]
        public int Urgency_Id { get; set; }
        public string? Urgency_Name { get; set; }
    }
}
