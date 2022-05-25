using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTIPPO
{
    internal class User
    {
        [Key]
        public int User_Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        [ForeignKey("Role")]
        public int? Role_FK { get; set; }
        public Role? Role { get; set; }

        [ForeignKey("Organization")]
        public int? Organization_FK { get; set; }
        public Organization? Organization { get; set; }
    }


    internal class Role 
    {
        [Key]
        public int Role_Id { get; set; }
        public string Role_Name { get; set; }
        public List<string> Permission { get; set; }

    }
}
