using Microsoft.AspNetCore.Mvc;
using WebHomeStay.Models;

namespace WebHomeStay.Controllers
{
    public class KhuyenMaiController : Controller
    {
        private readonly InternWebsiteContext _db;

        public KhuyenMaiController()
        {
            _db = new InternWebsiteContext();
        }

        //Hàm Get: /KhuyenMai/
        public IActionResult index(string Key)
        {
            var khuyenMais = _db.KhuyenMais.AsQueryable();
            if (!String.IsNullOrEmpty(Key))
            {
                khuyenMais = khuyenMais.Where(k => k.TenKhuyenMai.Contains(Key));
            }
            return View(khuyenMais.ToList());
        }

        //Hàm Get: /KhuyenMai/Create
        public IActionResult Create()
        {
            return View();
        }

        //Hàm Post: /KhuyenMai/Create
        [HttpPost] // Để gọi từ post về
        public IActionResult Create(KhuyenMai km) {
            if (ModelState.IsValid) 
            {
                _db.KhuyenMais.Add(km);
                _db.SaveChanges();
                return RedirectToAction("Index"); // Cái ni là về lại trang chính bỏ tên trang chính vô
            }
            return View(km);
        }

        //Hàm Get: /KhuyenMai/Update/số
        public IActionResult Edit(int ID) {
            var khuyenmai = _db.KhuyenMais.Find(ID);
            if(khuyenmai == null){
                return NotFound();
            }
            return View(khuyenmai);
        }

        //Hàm Post /KhuyenMai/UpDate
        [HttpPost]
        public IActionResult Edit(KhuyenMai km)
        {
            if (ModelState.IsValid) { 
                _db.KhuyenMais.Update(km);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(km);
        }

        //Hàm Get: /KhuyenMai/Delete/5
        public IActionResult Delete(int ID) {
            var khuyenMai = _db.KhuyenMais.Find(ID);
            if (khuyenMai == null) { 
                return NotFound();
            }

            _db.KhuyenMais.Remove(khuyenMai);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
