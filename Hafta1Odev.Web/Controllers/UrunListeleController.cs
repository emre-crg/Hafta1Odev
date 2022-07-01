using Hafta1Odev.Data;
using Microsoft.AspNetCore.Mvc;

namespace Hafta1Odev.Web.Controllers
{
    public class UrunListeleController : Controller
    {
        Veritabani veritabani = new Veritabani();
        public IActionResult Index()
        {
           List<UrunModel> model = veritabani.TumUrunler();
            
            return View(model);
        }
    }
}
