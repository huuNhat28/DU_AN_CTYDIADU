using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DUAN_Homestay.Controllers
{
    public class ImageController : Controller
    {
        private readonly string _uploadsPath = "wwwroot/uploads";
        private readonly string _krpanoPath = "/path-to-krpano/krpanotools";

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Upload(IFormFile image)
        {
            if (image != null && image.Length > 0)
            {
                var fileName = Path.GetFileName(image.FileName);
                var filePath = Path.Combine(_uploadsPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyTo(stream);
                }

                // Gọi krpano xử lý ảnh
                var outputPath = Path.Combine(_uploadsPath, "output", Path.GetFileNameWithoutExtension(fileName));
                Directory.CreateDirectory(outputPath);
                var cmd = $"{_krpanoPath} makepano -config=templates/normal.config \"{filePath}\" -outputpath=\"{outputPath}\"";

                Process.Start("cmd.exe", "/C " + cmd);

                return RedirectToAction("ViewImage", new { imageName = Path.GetFileNameWithoutExtension(fileName) });
            }
            return View("Index");
        }

        [HttpGet]
        public IActionResult ViewImage(string imageName)
        {
            var xmlPath = $"/uploads/output/{imageName}/tour.xml";
            ViewBag.XmlPath = xmlPath;
            return View();
        }
    }
}
