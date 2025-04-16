using Microsoft.AspNetCore.Mvc;
using WebHomeStay.Models;

namespace WebHomeStay.Controllers
{
    public class DemoConnectController : Controller
    {
        InternWebsiteContext _db = new InternWebsiteContext();
        public IActionResult Index()
        {
            var getBaiViet = _db.BaiViets.ToList();
            return View();
        }
    }
}
