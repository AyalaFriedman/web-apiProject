using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserDTO
    {
        public int UserId { get; set; }
       
        [EmailAddress(ErrorMessage = "unvalid email")]
        public string Email { get; set; }
        public string FirstName { get; set; }
       
       public string LastName { get; set; }
      
        [MinLength(4, ErrorMessage = "password must have 4 char at least")]
        public int Password { get; set; }
      
    }
}
