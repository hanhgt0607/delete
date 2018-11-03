using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using static WebApplication2.Models.MyDbContext;

namespace MyNetCoreMVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly MyDbContext _context;
        public ProductsController(MyDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Products.ToList());
        }
        public IActionResult Create(string name, string price)
        {

            ViewData["name"] = name;
            ViewData["price"] = price;

            return View();
        }

        [HttpPost]
        public IActionResult Save(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return Redirect("Index");
        }
        public IActionResult Edit(long id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        public IActionResult Update(Product product)
        {
            var exisProduct = _context.Products.Find(product.id);
            if (exisProduct == null)
            {
                return NotFound();
            }
            exisProduct.name = product.name;
            exisProduct.price = product.price;
            _context.Products.Update(exisProduct);
            _context.SaveChanges();
            TempData["message"] = " Update success!";
            return Redirect("Index");
        }
        [HttpDelete]
        public IActionResult Delete(long id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            _context.Products.Remove(product);
            _context.SaveChanges();
            return Json(product);
        }
        [HttpDelete]
        public IActionResult DeleteMany(string ids)
        {
            return Json(ids);
        }
    }
}

// GET: Products
//public async Task<IActionResult> Index()
//{
//    return View(await _context.Product.ToListAsync());
//}

// GET: Products/Details/5
//public async Task<IActionResult> Details(long? id)
//{
//    if (id == null)
//    {
//        return NotFound();
//    }

//    var product = await _context.Product
//        .FirstOrDefaultAsync(m => m.Id == id);
//    if (product == null)
//    {
//        return NotFound();
//    }

//    return View(product);
//}

// GET: Products/Create

