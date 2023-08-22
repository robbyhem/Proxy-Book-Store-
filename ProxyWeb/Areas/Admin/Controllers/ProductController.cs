using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProxyWeb.DataAccess.Repository.IRepository;
using ProxyWeb.Models;
using ProxyWeb.Models.ViewModels;

namespace ProxyWeb.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Product> objList = _unitOfWork.Product.GetAll().ToList();
            return View(objList);
        }

        // "@(ViewData["CategoryList_Key"] as IEnumerable<SelectListItem>)"
        public IActionResult Create()
        {
            //ViewBag.CategoryList_Key = CategoryList;
            //ViewData["CategoryList_Key"] = CategoryList;
            ProductVM productVM = new()
            {
                CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                Product = new Product()
            };

            return View(productVM);
        }
        [HttpPost]
        public IActionResult Create(ProductVM product)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Create(product.Product);
                _unitOfWork.Save();
                TempData["success"] = "Product created successfully";
                return RedirectToAction("Index");
            }
            else
            {
                product.CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });
            }
            return View(product);
        }

        public IActionResult Edit(int? id)
        {
            if (id is null || id is 0)
            {
                return NotFound();
            }

            Product? product = _unitOfWork.Product.Get(x => x.Id == id);
            if (product is null)
            {
                return NotFound();
            }
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Update(product);
                _unitOfWork.Save();
                TempData["success"] = "Product updated successfully";
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

            Product? product = _unitOfWork.Product.Get(x => x.Id == id);
            if (product is null)
            {
                return NotFound();
            }
            return View(product);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Product? product = _unitOfWork.Product.Get(x => x.Id == id);

            if (product is null)
            {
                return NotFound();
            }
            _unitOfWork.Product.Delete(product);
            _unitOfWork.Save();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
