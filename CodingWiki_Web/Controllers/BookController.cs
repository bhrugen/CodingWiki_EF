using CodingWiki_DataAccess.Data;
using CodingWiki_Model.Models;
using CodingWiki_Model.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CodingWiki_Web.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db;
        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Book> objList = _db.Books.ToList();
            return View(objList);
        }

        public IActionResult Upsert(int? id)
        {
            BookVM obj = new();

            obj.PublisherList = _db.Publishers.Select(i=> new SelectListItem
            {
               Text = i.Name,
               Value=i.Publisher_Id.ToString()
            });

            if (id == null || id == 0)
            {
                //create
                return View(obj);
            }
            //edit
            obj.Book = _db.Books.FirstOrDefault(u => u.BookId == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Upsert(Category obj)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (obj.CategoryId == 0)
        //        {
        //            //create
        //            await _db.Categories.AddAsync(obj);
        //        }
        //        else
        //        {
        //            //update
        //            _db.Categories.Update(obj);
        //        }
        //        await _db.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(obj);
        //}

        //public async Task<IActionResult> Delete(int id)
        //{
        //    Category obj = new();
        //    obj = _db.Categories.FirstOrDefault(u => u.CategoryId == id);
        //    if (obj == null)
        //    {
        //        return NotFound();
        //    }

        //    _db.Categories.Remove(obj);
        //    await _db.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}


    }
}
