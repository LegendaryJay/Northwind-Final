using Microsoft.AspNetCore.Mvc;
using Northwind.Models;
using System.Linq;
using System;
using Microsoft.AspNetCore.Authorization;

namespace Northwind.Controllers
{
    public class ProductController : Controller
    {
        // this controller depends on the NorthwindRepository
        private NorthwindContext _northwindContext;
        public ProductController(NorthwindContext db) => _northwindContext = db;
        public IActionResult Category() => View(_northwindContext.Categories.OrderBy(c => c.CategoryName));
        public IActionResult Index(int id){
            ViewBag.id = id;
            return View(_northwindContext.Categories.OrderBy(c => c.CategoryName));
        }

        [Authorize(Roles = "Northwind-Employee")]
        public IActionResult Inventory(){
            return View(_northwindContext.Products);
        }
        public IActionResult Discounts() => View(_northwindContext.Discounts.Where(d => d.StartTime <= DateTime.Now && d.EndTime > DateTime.Now));
    
    }
}
