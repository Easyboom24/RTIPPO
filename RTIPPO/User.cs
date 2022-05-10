using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTIPPO
{
    internal class User
    {
        [Key]
        private int User_Id { get; set; }
        private string Login { get; set; }
        private string Password { get; set; }
        public Role Role_FK { get; set; }
        public Organization Organization_FK { get; set; }
    }


    internal class Role 
    {
        [Key]
        private int Role_Id { get; set; }
        public string Role_Name { get; set; }
        public List<string> Permission { get; set; }

    }
}
