using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Uygulama.Models.Models
{
    [Table("Emlak")]
    public class Emlak
    {
        [Key]
        public int EmlakId { get; set; }
        public string EmlakAdi { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }
        public string Yetkili { get; set; }
        public string EPosta { get; set; }
        public DateTime KurulusTarihi { get; set; }
        public ICollection<Musteri> Musteris { get; set; }

    }
}
