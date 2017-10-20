using MaxWebApp.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace MaxWebApp.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;
        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var upcomingGigs = _context.Gigs.Include(g => g.Artist).Include(b => b.Genre).Where(d => d.Datetime > DateTime.Now);
            return View(upcomingGigs);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}