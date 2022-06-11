using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using ShopDienThoai.Models;
using ShopDienThoai.Models.ViewModels;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System;
using Microsoft.EntityFrameworkCore;

namespace BooksStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ShopDienThoaiDbContext dbContext;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly ShopDienThoaiDbContext _context;
        private IShopDienThoaiRepository repository;
        public int PageSize = 3;
        public HomeController(IShopDienThoaiRepository repo, ShopDienThoaiDbContext context, IWebHostEnvironment hostEnvironment)
        {
            repository = repo;
            dbContext = context;
            webHostEnvironment = hostEnvironment;
            _context = context;
        }
        public IActionResult Index(string genre, int DienThoaiPage = 1)
                => View(new DienThoaiListViewModels
                {
                    DienThoais = repository.DienThoais
                    .Where(p => genre == null || p.Genre == genre)
                    .OrderBy(p => p.DienThoaiID)
                    .Skip((DienThoaiPage - 1) * PageSize)
                    .Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = DienThoaiPage,
                        ItemsPerPage = PageSize,
                        TotalItems = genre == null ?
                            repository.DienThoais.Count() :
                            repository.DienThoais.Where(e =>
                                e.Genre == genre).Count()
                    },
                    CurrentGenre = genre
                });
        public IActionResult Created()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Created(DienThoaiViewModels model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(model);

                DienThoai dienthoai = new DienThoai
                {
                    
                    Title = model.Title,
                    Description = model.Description,
                    Genre = model.Genre,
                    Price = model.Price,
                    ProfilePicture = uniqueFileName,
                };
                dbContext.Add(dienthoai);
                await dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        private string UploadedFile(DienThoaiViewModels model)
        {
            string uniqueFileName = null;

            if (model.ImagePhone != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ImagePhone.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ImagePhone.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dienThoai = await _context.DienThoais
                .FirstOrDefaultAsync(m => m.DienThoaiID == id);
            if (dienThoai == null)
            {
                return NotFound();
            }

            return View(dienThoai);
        }

        // POST: SMartPhones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var sMartPhone = await _context.DienThoais.FindAsync(id);
            _context.DienThoais.Remove(sMartPhone);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SMartPhoneExists(long id)
        {
            return _context.DienThoais.Any(e => e.DienThoaiID == id);
        }
    }
}