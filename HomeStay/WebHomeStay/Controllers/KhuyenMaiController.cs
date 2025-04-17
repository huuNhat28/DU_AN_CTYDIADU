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
        public IActionResult index(string Key, DateOnly? fromDate, DateOnly? toDate, bool? TrangThai, double? soTienGiam)
        {
            var khuyenMais = _db.KhuyenMais.AsQueryable();
            foreach (var km in khuyenMais)
            {
                if (km.ThoiGian < DateOnly.FromDateTime(DateTime.Now))
                {
                    km.TrangThai = false; // Ngưng áp dụng
                    _db.KhuyenMais.Update(km);
                }
            }
            _db.SaveChanges();

            if (!String.IsNullOrEmpty(Key))
            {
                khuyenMais = khuyenMais.Where(k => k.TenKhuyenMai.Contains(Key));
            }

            if (fromDate.HasValue)
            {
                khuyenMais = khuyenMais.Where(k => k.ThoiGian >= fromDate);
            }

            if (toDate.HasValue)
            {
                khuyenMais = khuyenMais.Where(k => k.ThoiGian <= toDate);
            }

            if (soTienGiam.HasValue)
            {
                khuyenMais = khuyenMais.Where(k => k.SoTienGiam == soTienGiam);
            }

            if (TrangThai.HasValue)
            {
                khuyenMais = khuyenMais.Where(k => k.TrangThai == TrangThai);
            }


            return View("KhuyenMaiDS", khuyenMais.ToList());
        }

        //Hàm Get: /KhuyenMai/Create
        public IActionResult Create()
        {
            return View("KhuyenMaiAdd");
        }

        //Hàm Post: /KhuyenMai/Create
        [HttpPost] // Để gọi từ post về
        public IActionResult Create(KhuyenMai km)
        {
            if (ModelState.IsValid)
            {
                if (km.ThoiGian < DateOnly.FromDateTime(DateTime.Now))
                {
                    km.TrangThai = false;
                }
                _db.KhuyenMais.Add(km);
                _db.SaveChanges();
                return RedirectToAction("index");
            }
            return View("KhuyenMaiAdd", km);
        }

        //Hàm Get: /KhuyenMai/Update/số
        public IActionResult Edit(int ID)
        {
            var km = _db.KhuyenMais.Find(ID);
            if (km == null)
            {
                return NotFound();
            }
            return View("KhuyenMaiEdit", km);
        }

        //Hàm Post /KhuyenMai/UpDate
        [HttpPost]
        public IActionResult Edit(KhuyenMai km)
        {
            if (ModelState.IsValid)
            {
                if (km.ThoiGian < DateOnly.FromDateTime(DateTime.Now))
                {
                    km.TrangThai = false;
                }
                _db.KhuyenMais.Update(km);
                _db.SaveChanges();
                return RedirectToAction("index");
            }
            return View("KhuyenMainEdit", km);
        }

        //Hàm Get: /KhuyenMai/Delete/5
        public IActionResult Delete(int ID)
        {
            var khuyenMai = _db.KhuyenMais.Find(ID);
            if (khuyenMai == null)
            {
                return NotFound();
            }

            _db.KhuyenMais.Remove(khuyenMai);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
