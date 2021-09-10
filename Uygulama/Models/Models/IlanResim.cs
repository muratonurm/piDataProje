using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Uygulama.Models.Models
{
    [Table("IlanResim")]
    public class IlanResim
    {
        [Key]
        public int IlanResimId { get; set; }
        public string ResimAd { get; set; }
        public int PortfoyId { get; set; }
        public virtual Portfoy Portfoy { get; set; }
    }
}
