using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darzelis.Models.Entities
{
    public class RequestInfo
    {
        public int Id { get; set; }
        public int? DarzelioEilesPrioritetas { get; set; }
        public int? RequestIdRef { get; set; }
        [ForeignKey("RequestIdRef")]
        public Request request { get; set; }
        public int? PasirinktasDarzelis { get; set; }
        [ForeignKey("PasirinktasDarzelis")]
        public Pre_Schools PreSchool { get; set; }
        public int? UzpildytasDarzelis { get; set; }
        [ForeignKey("UzpildytasDarzelis")]
        public PreRequestSchool PreRequestSchool { get; set; }
    }
}
