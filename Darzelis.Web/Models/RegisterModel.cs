

namespace Darzelis.Web.Models
{
    public class RegisterModel
    {

        public string Vardas { get; set; }
        
        public string Pavarde { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string BornYear { get; set; }
        public int VaikoINDnr { get; set; }
        public string City { get; set; }
        public string Region { get; set; }

    }
}