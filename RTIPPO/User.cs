using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTIPPO
{
    internal class User
    {
        private int User_ID { get; set; }
        private string Login { get; set; }
        private string Password { get; set; }
        public Role Role_FK { get; set; }
        public Organization Organization_FK { get; set; }
    }


    internal class Role 
    {
        private int Role_Id { get; set; }
        public string Role_Name { get; set; }
        public List<string> Permission { get; set; }

    }
}
