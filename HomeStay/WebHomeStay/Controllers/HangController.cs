using Microsoft.AspNetCore.Mvc;
using WebHomeStay.Models;

namespace WebHomeStay.Controllers
{
    public class HangController : Controller
    {
        private readonly InternWebsiteContext _db;

        public HangController()
        {
            _db = new InternWebsiteContext();
        }

        public IActionResult index(string Key)
        {
            var Hangs = _db.Hangs.AsQueryable();
            if (!String.IsNullOrEmpty(Key))
            {
                Hangs = Hangs.Where(k => k.TenHang.Contains(Key));
            }
            return View(Hangs.ToList());
        }

        //Hàm Get: /KhuyenMai/Create
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost] // Để gọi từ post về
        public IActionResult Create(Hang hang)
        {
            if (ModelState.IsValid)
            {
                _db.Hangs.Add(hang);
                _db.SaveChanges();
                return RedirectToAction("Index"); 
            }
            return View(hang);
        }

        public IActionResult Edit(int ID)
        {
            var hang = _db.Hangs.Find(ID);
            if (hang == null)
            {
                return NotFound();
            }
            return View(hang);
        }

        [HttpPost]
        public IActionResult Edit(Hang hang)
        {
            if (ModelState.IsValid)
            {
                _db.Hangs.Update(hang);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hang);
        }

        public IActionResult Delete(int ID)
        {
            var hang = _db.Hangs.Find(ID);
            if (hang == null)
            {
                return NotFound();
            }

            _db.Hangs.Remove(hang);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
