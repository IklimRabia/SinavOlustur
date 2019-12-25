using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

       
        public IActionResult Index()
        {  
            WebClient wclient = new WebClient();
            string RSSURL = "https://www.wired.com/feed/rss";
            string RSSData = wclient.DownloadString(RSSURL);  
  
            XDocument xml = XDocument.Parse(RSSData);  
            var RSSFeedData = (from x in xml.Descendants("item")
                             select new RSSOku  
                             {  
                                 title = ((string) x.Element("title")),  
                                 link = ((string) x.Element("link")),  
                                 description = ((string) x.Element("description"))
                                
                             });
            
            ViewBag.RSS = RSSFeedData;  
            ViewBag.URL = RSSURL;  
            return View(RSSFeedData);  
        } 
    
        public IActionResult SinavOlustur(string description, string [] soru ,string [] secenek, string [] cevap)
        {
            if(description!=""& soru.Count()!=0 & secenek.Count() != 0 & cevap.Count() != 0)
            return RedirectToAction("Index", "Home");
            else
                return RedirectToAction("Error", "Home");
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string kullaniciAd,string sifre)
        {
            if (kullaniciAd == "konusarakOgren" & sifre == "1")
                return RedirectToAction("Index", "Home");
            else
                return RedirectToAction("Error", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }





    }
}
