using Microsoft.AspNetCore.Mvc;
using ProxyWeb.DataAccess.Data;
using ProxyWeb.DataAccess.Repository.IRepository;
using ProxyWeb.Models;

namespace ProxyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Category> objList = _unitOfWork.Category.GetAll().ToList();
            return View(objList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            //if (category.Name != category.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("name", "The Display Order doesn't match");
            //}

            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Create(category);
                _unitOfWork.Save();
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

            Category? category = _unitOfWork.Category.Get(x => x.Id == id);
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
                _unitOfWork.Category.Update(category);
                _unitOfWork.Save();
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

            Category? category = _unitOfWork.Category.Get(x => x.Id == id);
            if (category is null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category? category = _unitOfWork.Category.Get(x => x.Id == id);

            if (category is null)
            {
                return NotFound();
            }
            _unitOfWork.Category.Delete(category);
            _unitOfWork.Save();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
