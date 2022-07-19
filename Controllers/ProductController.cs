using CURDUsingADO.DAL;
using CURDUsingADO.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CURDUsingADO.Controllers
{
    public class ProductController : Controller
    {
        ProductDAL db = new ProductDAL();
        // GET: ProductController
        public ActionResult Index()
        {
            var model = db.GetAllProducts();
            return View(model);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            var model = db.GetProductById(id);
            return View(model);

           
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            try
            {
                int result = db.AddProduct(product);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = db.GetProductById(id);
            return View(model);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            try
            {
                int result = db.UpdateProduct(product);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)//
        {
            var model = db.GetProductById(id);
            return View(model);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]//when actionresult name and another one id diff then use it//
        public ActionResult DeleteConfirm(int id)//
        {
            try
            {
                int result = db.DeleteProduct(id);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
