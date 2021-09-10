using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Uygulama.Models.Models
{
    [Table("Mahalleler")]
    public class Mahalleler
    {
        [Key]
        public int MahalleId { get; set; }
        public string MahalleAdi { get; set; }
        public int IlceId { get; set; }
        public virtual Ilceler Ilceler { get; set; }
    }
}
