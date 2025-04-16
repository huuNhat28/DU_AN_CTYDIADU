using Microsoft.AspNetCore.Mvc;
using WebHomeStay.Models;

namespace WebHomeStay.Controllers
{
    public class VaiTroController : Controller
    {
        private readonly InternWebsiteContext _db;

        public VaiTroController()
        {
            _db = new InternWebsiteContext();
        }

        public IActionResult index(string Key)
        {
            var vaitros = _db.VaiTros.AsQueryable();
            if (!String.IsNullOrEmpty(Key))
            {
                vaitros = vaitros.Where(k => k.TenVaiTro.Contains(Key));
            }
            return View(vaitros.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] // Để gọi từ post về
        public IActionResult Create(VaiTro vt)
        {
            if (ModelState.IsValid)
            {
                _db.VaiTros.Add(vt);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vt);
        }

        public IActionResult Edit(int ID)
        {
            var vt = _db.VaiTros.Find(ID);
            if (vt == null)
            {
                return NotFound();
            }
            return View(vt);
        }

        [HttpPost]
        public IActionResult Edit(VaiTro vt)
        {
            if (ModelState.IsValid)
            {
                _db.VaiTros.Update(vt);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vt);
        }

        public IActionResult Delete(int ID)
        {
            var vt = _db.VaiTros.Find(ID);
            if (vt == null)
            {
                return NotFound();
            }

            _db.VaiTros.Remove(vt);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
