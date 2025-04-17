using Microsoft.AspNetCore.Mvc;
using WebHomeStay.Models;

namespace WebHomeStay.Controllers
{
    public class LoaiPhongController : Controller
    {
        private readonly InternWebsiteContext _db;

        public LoaiPhongController()
        {
            _db = new InternWebsiteContext();
        }

        public IActionResult index(string Key)
        {
            var LoaiPhongs = _db.LoaiPhongs.AsQueryable();

            if (!String.IsNullOrEmpty(Key))
            {
                LoaiPhongs = LoaiPhongs.Where(k => k.TenLoaiPhong.Contains(Key));
            }
            return View("LoaiPhongDS", LoaiPhongs.ToList());
        }

        public IActionResult Create()
        {
            return View("LoaiPhongAdd");
        }

        [HttpPost] 
        public IActionResult Create(LoaiPhong lp)
        {
            if (ModelState.IsValid)
            {           
                _db.LoaiPhongs.Add(lp);
                _db.SaveChanges();
                return RedirectToAction("index");
            }
            return View("LoaiPhongAdd", lp);
        }

        public IActionResult Edit(int ID)
        {
            var lp = _db.LoaiPhongs.Find(ID);
            if (lp == null)
            {
                return NotFound();
            }
            return View("LoaiPhongEdit", lp);
        }

        [HttpPost]
        public IActionResult Edit(LoaiPhong lp)
        {
            if (ModelState.IsValid)
            {
                _db.LoaiPhongs.Update(lp);
                _db.SaveChanges();
                return RedirectToAction("index");
            }
            return View("LoaiPhongEdit", lp);
        }

        public IActionResult Delete(int ID)
        {
            var lp = _db.LoaiPhongs.Find(ID);
            if (lp == null)
            {
                return NotFound();
            }

            _db.LoaiPhongs.Remove(lp);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
