using DUAN_Homestay.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace DUAN_Homestay.Controllers
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
            return View(); 
        }
        //public IActionResult Anh()
        //{
        //    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/360Tour/tour_testingserver.exe");
        //    Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
        //    return Content("Đã mở file tour_testingserver.exe!");
        //}
        public IActionResult Anh()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Blog()
        {
            return View();
        }
        public IActionResult Blog_single()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Restaurant()
        {
            return View();
        }
        public IActionResult Rooms()
        {
            return View();
        }
        public IActionResult Rooms_single()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
