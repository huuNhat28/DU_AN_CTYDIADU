using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using WebHomeStay.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WebHomeStay.Controllers
{
    public class DatPhongController : Controller
    {
        private readonly InternWebsiteContext _db;
        public DatPhongController(InternWebsiteContext context)
        {
            _db = context;
        }
        public async Task<IActionResult> Index(string? NgayDatPhong, string? NgayTraPhong, bool? TrangThaiThanhToan, bool? TrangThaiDatPhong, string? soPhong)
        {
            var datphongsQuery = _db.DatPhongs
                .Include(p => p.IdphongNavigation)
                .Include(tk => tk.IdtaiKhoanNavigation)
                .AsQueryable();

            ViewData["NgayDatPhong"] = NgayDatPhong;
            ViewData["NgayTraPhong"] = NgayTraPhong;
            ViewData["TrangThaiThanhToan"] = TrangThaiThanhToan;
            ViewData["TrangThaiDatPhong"] = TrangThaiDatPhong;
            ViewData["soPhong"] = soPhong;

            // Lọc theo ngày đặt phòng
            if (!string.IsNullOrEmpty(NgayDatPhong))
            {
                if (DateOnly.TryParseExact(NgayDatPhong, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsedNgayDat))
                {
                    datphongsQuery = datphongsQuery.Where(d => d.NgayDatPhong.HasValue && d.NgayDatPhong.Value == parsedNgayDat);
                }
                else
                {
                    ModelState.AddModelError("NgayDatPhong", "Ngày đặt phòng không hợp lệ.");
                }
            }

            // Tìm kiếm theo ngày trả phòng
            if (!string.IsNullOrEmpty(NgayTraPhong))
            {
                if (DateOnly.TryParseExact(NgayTraPhong, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsedNgayTra))
                {
                    datphongsQuery = datphongsQuery.Where(d => d.NgayTraPhong.HasValue && d.NgayTraPhong.Value == parsedNgayTra);
                }
                else
                {
                    ModelState.AddModelError("NgayTraPhong", "Ngày trả phòng không hợp lệ.");
                }
            }

            // Lọc theo trạng thái thanh toán
            if (TrangThaiThanhToan.HasValue)
            {
                datphongsQuery = datphongsQuery.Where(dp => dp.TrangThaiThanhToan == TrangThaiThanhToan.Value);
            }

            // Lọc theo trạng thái đặt phòng
            if (TrangThaiDatPhong.HasValue)
            {
                datphongsQuery = datphongsQuery.Where(dp => dp.TrangThaiDatPhong == TrangThaiDatPhong.Value);
            }

            // Lọc theo số phòng (tìm gần đúng)
            if (!string.IsNullOrEmpty(soPhong) && int.TryParse(soPhong, out int soPhongInt))
            {
                datphongsQuery = datphongsQuery.Where(dp => dp.IdphongNavigation.SoPhong == soPhongInt);
            }
            
            var datphongs = await datphongsQuery.ToListAsync();

            return View("DSDatPhong", datphongs);
        }


        public IActionResult Create()
        {
            ViewBag.Phongs = _db.Phongs.ToList();
            ViewBag.TaiKhoans = _db.TaiKhoans.ToList();
            return View("ThemDatPhong");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Models.DatPhong datPhong)
        {
            var phong = await _db.Phongs.FindAsync(datPhong.Idphong);
            if (datPhong.NgayDatPhong.HasValue && datPhong.NgayTraPhong.HasValue)
            {
                datPhong.TrangThaiDatPhong = true;
                int soNgay = datPhong.NgayTraPhong.Value.DayNumber - datPhong.NgayDatPhong.Value.DayNumber;

                if (soNgay <= 0)
                    soNgay = 1;
                datPhong.TongTien = phong.Gia * soNgay;
                // Tiếp tục xử lý tính tiền hoặc logic khác ở đây
            }
            else
            {
                ModelState.AddModelError("", "Ngày đặt phòng hoặc ngày trả phòng không hợp lệ.");
            }
            
            if (ModelState.IsValid)
            {
                _db.DatPhongs.Add(datPhong);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Phongs = _db.Phongs.ToList();
            ViewBag.TaiKhoans = _db.TaiKhoans.ToList();
            return View("ThemDatPhong", datPhong);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datphong = await _db.DatPhongs
                .Include(tk => tk.IdtaiKhoanNavigation)
                .Include(p => p.IdphongNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (datphong == null)
            {
                return NotFound();
            }

            return View("ChiTietDatPhong", datphong);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datphong = await _db.DatPhongs.FindAsync(id);
            if (datphong == null)
            {
                return NotFound();
            }

            ViewBag.Phongs = _db.Phongs.ToList();
            return View("CapNhatDatPhong", datphong);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Models.DatPhong datPhong)
        {
            var phong = await _db.Phongs.FindAsync(datPhong.Idphong);
            if (datPhong.NgayDatPhong.HasValue && datPhong.NgayTraPhong.HasValue)
            {
                datPhong.TrangThaiDatPhong = true;
                int soNgay = datPhong.NgayTraPhong.Value.DayNumber - datPhong.NgayDatPhong.Value.DayNumber;

                if (soNgay <= 0)
                    soNgay = 1;
                datPhong.TongTien = phong.Gia * soNgay;
                // Tiếp tục xử lý tính tiền hoặc logic khác ở đây
            }
            else
            {
                ModelState.AddModelError("", "Ngày đặt phòng hoặc ngày trả phòng không hợp lệ.");
            }

            if (ModelState.IsValid)
            {
                _db.DatPhongs.Update(datPhong);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Phongs = _db.Phongs.ToList();
            ViewBag.TaiKhoans = _db.TaiKhoans.ToList();
            return View("CapNhatDatPhong", datPhong);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datphong = await _db.DatPhongs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (datphong == null)
            {
                return NotFound();
            }
            ViewBag.Phong = _db.Phongs.ToList();
            ViewBag.TaiKhoan = _db.TaiKhoans.ToList();
            return View("XoaDatPhong", datphong);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Deletepost(int? id)
        {
            var datphong = await _db.DatPhongs.FindAsync(id);
            if (datphong != null)
            {
                _db.DatPhongs.Remove(datphong);
                await _db.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
