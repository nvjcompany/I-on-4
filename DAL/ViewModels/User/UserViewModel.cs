using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModels.User
{
    public class UserViewModel
    {
        public string Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        public string OldPassword { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string NewPassword { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
