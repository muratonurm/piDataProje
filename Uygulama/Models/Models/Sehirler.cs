using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Uygulama.Models.Models
{
    [Table("Sehirler")]
    public class Sehirler
    {
        [Key]
        public int SehirId { get; set; }
        public string SehirAd { get; set; }
        public List<Ilceler> Ilcelers { get; set; }
    }
}
