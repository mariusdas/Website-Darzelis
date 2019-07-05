using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Darzelis.Models.Entities
{
   
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Iveskite vardą.")]
        public string Vardas { get; set; }
        [Required(ErrorMessage = "Iveskite pavardė.")]
        public string Pavarde { get; set; }

        [Required(ErrorMessage = "Iveskite emailą.")]
        [RegularExpression(@"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$" , ErrorMessage = "Neteisingai įvestas emailas.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Iveskite Vartotojo vardą")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Iveskite Vartotojo slaptažodį")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Iveskite Vartotojo slaptažodžio patvirtinimą")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Iveskite vaiko metus.")]
        public DateTime Metai { get; set; }
        [Required(ErrorMessage = "Iveskite vaiko indentifikavimo numerį.")]
        public int VaikoINDnr { get; set; }
        [Required(ErrorMessage = "Iveskite vaiko miestą.")]
        public string City { get; set; }
        [Required(ErrorMessage = "Iveskite vaiko miesto rajoną.")]
        public string Region { get; set; }
        public int UserType { get; set; }
        public bool RequestCreated { get; set; }

    }
}
