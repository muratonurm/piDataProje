using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Uygulama.Models.DataContext;
using Uygulama.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Uygulama.Controllers
{
    public class Admin : Controller
    {
        private readonly PiDataDBContext _ct;
        public Admin(PiDataDBContext ct)
        {
            _ct = ct;
        }
        public IActionResult Error()
        {
            return View();
        }
        public IActionResult Index()
        {

            return View(_ct.Emlaks.ToList());
        }
        public IActionResult EmlakCreate()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EmlakCreate(Emlak emlak)
        {
            _ct.Emlaks.Add(emlak);
            _ct.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult EmlakEdit(int id)
        {
            if (id == null)
            {
                return RedirectToAction("Error");
            }
            var findBusiness = _ct.Emlaks.Where(x => x.EmlakId == id).SingleOrDefault();
            if (findBusiness == null)
            {
                return RedirectToAction("Error");
            }
            return View(findBusiness);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EmlakEdit(int id, Emlak emlak)
        {
            if (ModelState.IsValid)
            {
                var findbusiness = _ct.Emlaks.Where(x => x.EmlakId == id).SingleOrDefault();
                findbusiness.EmlakAdi = emlak.EmlakAdi;
                findbusiness.Adres = emlak.Adres;
                findbusiness.EPosta = emlak.EPosta;
                findbusiness.KurulusTarihi = emlak.KurulusTarihi;
                findbusiness.Yetkili = emlak.Yetkili;
                findbusiness.Telefon = emlak.Telefon;
                _ct.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(emlak);
        }

        public IActionResult EmlakDelete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error");
            }
            Emlak emlak = _ct.Emlaks.Find(id);

            return View(emlak);
        }
        [HttpPost]
        public IActionResult EmlakDelete(int id)
        {
            var deletebusiness = _ct.Emlaks.Find(id);
            if (deletebusiness == null)
            {
                return RedirectToAction("Error");
            }
            _ct.Emlaks.Remove(deletebusiness);
            _ct.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult MusteriIndex()
        {
            return View(_ct.Musteris.Include("Emlak").OrderByDescending(x => x.MusteriId));
        }
        public IActionResult MusteriCreate()
        {
            ViewBag.emlakid = new SelectList(_ct.Emlaks, "EmlakId", "EmlakAdi");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MusteriCreate(Musteri musteri)
        {
            _ct.Musteris.Add(musteri);
            _ct.SaveChanges();
            return RedirectToAction("MusteriIndex");
        }
        public IActionResult MusteriEdit(int id)
        {
            if (id == null)
            {
                return RedirectToAction("Error");
            }
            var findCustomer = _ct.Musteris.Where(x => x.MusteriId == id).SingleOrDefault();
            if (findCustomer == null)
            {
                return RedirectToAction("Error");
            }
            ViewBag.emlakid = new SelectList(_ct.Emlaks, "EmlakId", "EmlakAdi");
            return View(findCustomer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MusteriEdit(int id, Musteri musteri)
        {
            if (ModelState.IsValid)
            {
                var customeredit = _ct.Musteris.Where(x => x.MusteriId == id).SingleOrDefault();
                customeredit.Ad = musteri.Ad;
                customeredit.Soyad = musteri.Soyad;
                customeredit.Tel = musteri.Tel;
                customeredit.GSM = musteri.GSM;
                customeredit.EPosta = musteri.EPosta;
                customeredit.Adres = musteri.Adres;
                customeredit.EmlakId = musteri.EmlakId;
                customeredit.MustKategori = musteri.MustKategori;
                _ct.SaveChanges();
                return RedirectToAction("MusteriIndex");
            }
            return View(musteri);
        }
        public IActionResult MusteriDelete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error");
            }
            Musteri musteri = _ct.Musteris.Find(id);
            if (musteri == null)
            {
                return RedirectToAction("Error");
            }
            return View(musteri);
        }
        [HttpPost]
        public IActionResult MusteriDelete(int id)
        {
            var findcustomer = _ct.Musteris.Find(id);
            if (findcustomer == null)
            {
                return RedirectToAction("Error");
            }
            _ct.Musteris.Remove(findcustomer);
            _ct.SaveChanges();
            return RedirectToAction("MusteriIndex");
        }
        public IActionResult IlceGetir(int SehirId)
        {
            List<Ilceler> IlceList = _ct.Ilcelers.Where(x => x.SehirId == SehirId).ToList();
            ViewBag.IList = new SelectList(IlceList, "IlceId", "IlceAd");
            return PartialView("GosterIlce");
        }
        public IActionResult MahalleGetir(int IlceId)
        {
            List<Mahalleler> MahalleList = _ct.Mahallelers.Where(x => x.IlceId == IlceId).ToList();
            ViewBag.MList = new SelectList(MahalleList, "MahalleId", "MahalleAdi");
            return PartialView("GosterMahalle");
        }
        public ActionResult TipGetir(int DurumId)
        {
            List<Tip> TipList = _ct.Tips.Where(x => x.DurumId == DurumId).ToList();
            ViewBag.TpList = new SelectList(TipList, "TipId", "TipAdi");
            return PartialView("GosterTip");
        }
        public IActionResult PortfoyCreate(int id)
        {
            List<Sehirler> SehirList = _ct.Sehirlers.ToList();
            ViewBag.SehirList = new SelectList(SehirList, "SehirId", "SehirAd");
            List<Durum> DurumList = _ct.Durums.ToList();
            ViewBag.DurumList = new SelectList(DurumList, "DurumId", "DurumAd");

            ViewBag.id = id;

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PortfoyCreate(int id, Portfoy portfoy)
        {
            if (ModelState.IsValid)
            {
                portfoy.MusteriId = id;
                portfoy.KayitTarihi = DateTime.Now;
                _ct.Portfoys.Add(portfoy);
                _ct.SaveChanges();

                return RedirectToAction("MusteriIndex");
            }
            return View();
        }

        public IActionResult Images(int id)
        {
            var ilan = _ct.Portfoys.Where(x => x.PortfoyId == id).ToList();
            var resim = _ct.IlanResims.Where(x => x.PortfoyId == id).ToList();
            ViewBag.ilan = ilan;
            ViewBag.resim = resim;
            return View();
        }
        [HttpPost]
        public IActionResult Images(int id, IFormFile file)
        {
            IlanResim resim = new IlanResim();
            if (file == null)
            {
                var extension = Path.GetExtension(file.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwwroot/Uploads/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                resim.ResimAd = newimagename;
            }
            resim.PortfoyId = id;
            _ct.IlanResims.Add(resim);
            _ct.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Portfoyler()
        {
            return View(_ct.Portfoys.Include("Mahalleler").Include("Tip").ToList());
        }

        public IActionResult FiltrePortfoy()
        {
            List<Sehirler> SehirList = _ct.Sehirlers.ToList();
            ViewBag.SehirList = new SelectList(SehirList, "SehirId", "SehirAd");
            List<Durum> DurumList = _ct.Durums.ToList();
            ViewBag.DurumList = new SelectList(DurumList, "DurumId", "DurumAd");
            return View();
        }
        public IActionResult Filtre(int min, int max, int sehirid, int ilceid, int mahalleid, int semtid, int durumid, int tipid)
        {
            var filtre = _ct.Portfoys.Where(x => x.Fiyat >= min && x.Fiyat <= max && x.DurumId == durumid && x.SehirId == sehirid && x.IlceId == ilceid && x.MahalleId == mahalleid && x.TipId == tipid).Include("Mahalleler").Include("Tip").ToList();
            return View(filtre);
        }
        public IActionResult PortfoyDetay(int id)
        {
            var details = _ct.Portfoys.Include(i => i.Tip).ThenInclude(x => x.Durum)
                .Include(i => i.Mahalleler)
                    .ThenInclude(i => i.Ilceler).ThenInclude(i => i.Sehirler)
                .Where(x => x.PortfoyId == id).SingleOrDefault();
            return View(details);
        }
    }
}
