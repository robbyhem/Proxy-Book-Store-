using Microsoft.AspNetCore.Mvc;
using ProxyWeb.DataAccess.Data;
using ProxyWeb.Models;

namespace ProxyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Category> objList = _context.Categories.ToList();
            return View(objList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The Display Order doesn't match");
            }

            if (ModelState.IsValid)
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        //[Route("Category/{id:int}")]
        public IActionResult Edit(int? id)
        {
            if (id is null || id is 0)
            {
                return NotFound();
            }

            Category? category = _context.Categories.Find(id);
            //Category? category1 = _context.Categories.FirstOrDefault(c => c.Id == id);
            //Category? category2 = _context.Categories.Where(c => c.Id == id).FirstOrDefault();
            if (category is null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Update(category);
                _context.SaveChanges();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id is null || id is 0)
            {
                return NotFound();
            }

            Category? category = _context.Categories.Find(id);
            if (category is null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category? category = _context.Categories.Find(id);

            if (category is null)
            {
                return NotFound();
            }
            _context.Categories.Remove(category);
            _context.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
