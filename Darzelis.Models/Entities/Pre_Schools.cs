using System;
using System.ComponentModel.DataAnnotations;

namespace Darzelis.Models.Entities
{ 
    public class Pre_Schools
    {
        public int ID { get; set; }
        public string Label { get; set; }
        public int PriemimoVaikuKiekis { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string SchoolNo { get; set; }
        public string WWW { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public string School_Type { get; set; }
        public DateTime BuildDate { get; set; }
        public string Elderate { get; set; }
        [DataType("decimal(18 ,2")]
        public decimal GisX { get; set; }
        [DataType("decimal(18 ,2")]
        public decimal GisY { get; set; }
    }
}
