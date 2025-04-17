using Microsoft.AspNetCore.Mvc;
using WebHomeStay.Models;

namespace WebHomeStay.Controllers
{
    public class LienHeController : Controller
    {
        private readonly InternWebsiteContext _db;

        public LienHeController()
        {
            _db = new InternWebsiteContext();
        }

        public IActionResult index(string Key)
        {
            var lienhes = _db.LienHes.AsQueryable();

            if (!String.IsNullOrEmpty(Key))
            {
                lienhes = lienhes.Where(k => k.Email.Contains(Key) || k.Sdt.Contains(Key));
            }
            return View("LienHeDS", lienhes.ToList());
        }

        public IActionResult Create()
        {
            return View("LienHeAdd");
        }

        [HttpPost]
        public IActionResult Create(LienHe lh)
        {
            if (ModelState.IsValid)
            {
                _db.LienHes.Add(lh);
                _db.SaveChanges();
                return RedirectToAction("index");
            }
            return View("LienHeAdd", lh);
        }

        public IActionResult Edit(int ID)
        {
            var lh = _db.LienHes.Find(ID);
            if (lh == null)
            {
                return NotFound();
            }
            return View("LienHeEdit", lh);
        }

        [HttpPost]
        public IActionResult Edit(LienHe lh)
        {
            if (ModelState.IsValid)
            {
                _db.LienHes.Update(lh);
                _db.SaveChanges();
                return RedirectToAction("index");
            }
            return View("LienHeEdit", lh);
        }

        public IActionResult Delete(int ID)
        {
            var lh = _db.LienHes.Find(ID);
            if (lh == null)
            {
                return NotFound();
            }

            _db.LienHes.Remove(lh);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
