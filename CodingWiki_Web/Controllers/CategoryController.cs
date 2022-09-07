using CodingWiki_DataAccess.Data;
using CodingWiki_Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodingWiki_Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Category> objList = _db.Categories.ToList();
            return View(objList);
        }

        public IActionResult Upsert(int? id)
        {
            Category obj = new();
            if (id == null || id==0)
            {
                //create
                return View(obj);
            }
            //edit
            obj = _db.Categories.First(u => u.CategoryId == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
    }
}
