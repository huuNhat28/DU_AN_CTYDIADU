using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebHomeStay.Models;

namespace WebHomeStay.Controllers
{
    public class PhongController : Controller
    {
        private readonly InternWebsiteContext _db;
        private readonly IWebHostEnvironment _env;

        public PhongController(InternWebsiteContext context, IWebHostEnvironment env)
        {
            _db = context;
            _env = env;
        }

        public async Task<IActionResult> Index(String Gia)
        {


            var phongs = await _db.Phongs
                .Include(p => p.IdloaiPhongNavigation).Where(p => p.TrangThai == true)
                .ToListAsync();
            
            
            if (!string.IsNullOrEmpty(Gia))
            {
                phongs = phongs.Where(p => p.Gia.ToString().Contains(Gia)).ToList();
            }

            return View("DSPhong", phongs);
        }
      
        public IActionResult Create()
        {
            ViewBag.LoaiPhongs = _db.LoaiPhongs.ToList();
            return View("ThemPhong");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Phong phong, List<IFormFile> HinhAnh, IFormFile AnhNho)
        {
            long size = HinhAnh.Sum(f => f.Length);
            string filePath = Path.Combine(_env.WebRootPath, "uploads");
            string anh = "";
            string anhnho = "";

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            //lưu hình ảnh
            foreach (var formFile in HinhAnh)
            {
                if (formFile.Length > 0)
                {
                    // Lấy tên gốc của file (không bao gồm path)
                    var originalFileName = Path.GetFileNameWithoutExtension(formFile.FileName);
                    var extension = Path.GetExtension(formFile.FileName);

                    // Tạo chuỗi thời gian (giây hiện tại)
                    var seconds = DateTime.Now.ToString("ss");

                    // Gộp tên file mới
                    var newFileName = $"{originalFileName}_{seconds}{extension}";
                    anh += newFileName;
                    // Gộp đường dẫn lưu file
                    var filePaths = Path.Combine(_env.WebRootPath, "uploads", newFileName);

                    // Ghi file
                    using (var stream = System.IO.File.Create(filePaths))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }
            //lưu ảnh nhỏ
            if (AnhNho != null && AnhNho.Length > 0)
            {
                // Lấy tên gốc của file (không bao gồm path)
                var originalFileName = Path.GetFileNameWithoutExtension(AnhNho.FileName);
                var extension = Path.GetExtension(AnhNho.FileName);

                // Tạo chuỗi thời gian (giây hiện tại)
                var seconds = DateTime.Now.ToString("ss");

                // Gộp tên file mới
                var newFileName = $"{originalFileName}_{seconds}{extension}";
                
                // Gộp đường dẫn lưu file
                var filePaths = Path.Combine(_env.WebRootPath, "uploads", newFileName);

                // Ghi file
                using (var stream = System.IO.File.Create(filePaths))
                {
                    await AnhNho.CopyToAsync(stream);
                }
                anhnho = newFileName;
            }

            phong.HinhAnh = anh;
            phong.AnhNho = anhnho;

            _db.Add(phong);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            //if (ModelState.IsValid)
            //{
            //    _db.Add(phong);
            //    await _db.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            ViewBag.LoaiPhongs = _db.LoaiPhongs.ToList();
            return View("ThemPhong",phong);
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phong = await _db.Phongs
                .Include(p => p.IdloaiPhongNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (phong == null)
            {
                return NotFound();
            }

            return View("ChiTietPhong",phong);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phong = await _db.Phongs.FindAsync(id);
            if (phong == null)
            {
                return NotFound();
            }

            ViewBag.LoaiPhongs = _db.LoaiPhongs.ToList();
            return View("CapNhatPhong",phong);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Phong phong, List<IFormFile> HinhAnh, IFormFile AnhNho)
        {
            
            if (id != phong.Id)
            {
                return NotFound();
            }
            long size = HinhAnh.Sum(f => f.Length);
            string filePath = Path.Combine(_env.WebRootPath, "uploads");
            string anh = "";
            string anhnho = "";

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            //lưu hình ảnh
            foreach (var formFile in HinhAnh)
            {
                if (formFile.Length > 0)
                {
                    // Lấy tên gốc của file (không bao gồm path)
                    var originalFileName = Path.GetFileNameWithoutExtension(formFile.FileName);
                    var extension = Path.GetExtension(formFile.FileName);

                    // Tạo chuỗi thời gian (giây hiện tại)
                    var seconds = DateTime.Now.ToString("ss");

                    // Gộp tên file mới
                    var newFileName = $"{originalFileName}_{seconds}{extension}";
                    anh += newFileName;
                    // Gộp đường dẫn lưu file
                    var filePaths = Path.Combine(_env.WebRootPath, "uploads", newFileName);

                    // Ghi file
                    using (var stream = System.IO.File.Create(filePaths))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }
            //lưu ảnh nhỏ
            if (AnhNho != null && AnhNho.Length > 0)
            {
                // Lấy tên gốc của file (không bao gồm path)
                var originalFileName = Path.GetFileNameWithoutExtension(AnhNho.FileName);
                var extension = Path.GetExtension(AnhNho.FileName);

                // Tạo chuỗi thời gian (giây hiện tại)
                var seconds = DateTime.Now.ToString("ss");

                // Gộp tên file mới
                var newFileName = $"{originalFileName}_{seconds}{extension}";

                // Gộp đường dẫn lưu file
                var filePaths = Path.Combine(_env.WebRootPath, "uploads", newFileName);

                // Ghi file
                using (var stream = System.IO.File.Create(filePaths))
                {
                    await AnhNho.CopyToAsync(stream);
                }
                anhnho = newFileName;
            }

            phong.HinhAnh = anh;
            phong.AnhNho = anhnho;

            _db.Update(phong);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        _db.Update(phong);
            //        await _db.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
                    
            //    }
            //    return RedirectToAction(nameof(Index));
            //}
            ViewBag.LoaiPhongs = _db.LoaiPhongs.ToList();
            return View("DSPhong",phong);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phong = await _db.Phongs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (phong == null)
            {
                return NotFound();
            }
            ViewBag.LoaiPhongs = _db.LoaiPhongs.ToList();
            return View("XoaPhong",phong);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var phong = await _db.Phongs.FindAsync(id);
            if (phong != null)
            {
                _db.Phongs.Remove(phong);
                await _db.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }


    }
}
