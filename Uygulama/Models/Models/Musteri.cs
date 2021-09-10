using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Uygulama.Models.Models
{
    [Table("Musteriler")]
    public class Musteri
    {
        [Key]
        public int MusteriId { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Tel { get; set; }
        public string GSM { get; set; }
        public string EPosta { get; set; }
        public string Adres { get; set; }
        public int? EmlakId { get; set; }
        public Emlak Emlak { get; set; }
        public MustKategori MustKategori { get; set; }
        public ICollection<Portfoy> Portfoys { get; set; }
        public string Tamisim
        {
            get
            {
                return Ad + " " + Soyad;
            }
        }
    }
    public enum MustKategori
    {
        Alici,
        Satici
    }
}
