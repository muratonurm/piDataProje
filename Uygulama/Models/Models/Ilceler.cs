using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Uygulama.Models.Models
{
    [Table("Ilceler")]
    public class Ilceler
    {
        [Key]
        public int IlceId { get; set; }
        public string IlceAd { get; set; }
        public int SehirId { get; set; }
        public virtual Sehirler Sehirler { get; set; }
        public List<Mahalleler> Mahallelers { get; set; }
    }
}
