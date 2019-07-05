using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Darzelis.Models.Entities
{
    public class Request
    {
        public int Id { get; set; }
        public DateTime PrasymoPateikimoData { get; set; }
        public int? VaikoId { get; set; }
        [ForeignKey("VaikoId")]
        public User VaikoIDNF { get; set; }
        public DateTime VaikoGimimoData { get; set; }
        public DateTime LankymoData { get; set; }
        public string VaikoSeniunija { get; set; }
        public bool Prioritetas_DeklaruotasMiestas { get; set; }
        public bool Prioritetas_3_ar_Daugiau_Vaiku { get; set; }
        public bool Prioritetas_seimosdarbingumoLygis { get; set; }
        public bool Prioritetas_auginaTikVienasTevas { get; set; }
        public int? PrioritetuSuma { get; set; }
        public bool Accepted { get; set; }
        public int? PriimtasDarzelis { get; set; }
        [ForeignKey("PriimtasDarzelis")]
        public Pre_Schools PreSchoolAccepted { get; set; }

    }
}
