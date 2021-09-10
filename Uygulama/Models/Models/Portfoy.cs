using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Uygulama.Models.Models
{
    [Table("Portfoy")]
    public class Portfoy
    {
        [Key]
        public int PortfoyId { get; set; }
        public string IlanBasligi { get; set; }

        public string Aciklama { get; set; }
        public int OdaSayisi { get; set; }
        public double Fiyat { get; set; }
        public DateTime KayitTarihi { get; set; }
        public Isınma Isınma { get; set; }
        public string Kat { get; set; }
        public int SehirId { get; set; }
        public int IlceId { get; set; }
        public int MahalleId { get; set; }
        public Mahalleler Mahalleler { get; set; }
        public int DurumId { get; set; }
        public int TipId { get; set; }
        public Tip Tip { get; set; }
        public List<IlanResim> IlanResims { get; set; }
        public int MusteriId { get; set; }
        public Musteri Musteri { get; set; }

    }
    public enum Isınma
    {
        Kalorifer,
        Dogalgaz,
        Soba
    }
}
