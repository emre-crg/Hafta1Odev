using Hafta1Odev.Data;
using Microsoft.AspNetCore.Mvc;

namespace Hafta1Odev.Web.Controllers
{
    public class UrunEklemeController : Controller
    {
        Veritabani veritabani = new Veritabani();
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UrunEkle(UrunModel urun)
        {
            veritabani.UrunEkle(urun);
            return View("/Views/UrunEkleme/Index.cshtml");
        }
    }
}
