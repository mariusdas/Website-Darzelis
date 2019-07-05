using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Darzelis.Web.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Vartotojo vardas neįvestas.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Vartotojo slaptažodis neįvestas.")]
        public string Password { get; set; }
        public string Email { get; set; }
        public int Type { get; set; }
    }
}