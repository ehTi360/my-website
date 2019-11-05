using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Auth_MVC.Models
{
    [Table("tbl_account")]
    public class Signup
    {
        [Key]
        public int userid { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "name required")]
        public string name { get; set; }

        [StringLength(50)]
        [EmailAddress]
        [Required(ErrorMessage = "mail required")]
        [Display(Name = "Email Address")]
        public string email { get; set; }

        
        [Required(ErrorMessage = "Password required")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Does not Match!")]
        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage = "The password and confirmation password do not match.")]
        public string Confirmpassword { get; set; }

    }
}