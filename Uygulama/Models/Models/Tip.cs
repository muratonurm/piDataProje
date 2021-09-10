using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Uygulama.Models.Models
{
    [Table("Tip")]
    public class Tip
    {
        [Key]
        public int TipId { get; set; }
        public string TipAdi { get; set; }
        public int DurumId { get; set; }
        public virtual Durum Durum { get; set; }
    }
}
