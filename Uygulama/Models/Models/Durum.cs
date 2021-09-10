using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Uygulama.Models.Models
{
    [Table("Durum")]
    public class Durum
    {
        [Key]
        public int DurumId { get; set; }
        public string DurumAd { get; set; }
        public List<Tip> Tips { get; set; }
    }
}
