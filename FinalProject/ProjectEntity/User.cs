using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEntity
{
    public class User : Entity
    {
       
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
               
        public string Password { get; set; }
        public string Gender { get; set; }
        public string DOB { get; set; }
        public int Deactive { get; set; }
    }
}
