using System;
using Microsoft.AspNetCore.Mvc;
using WishList.Data;
using WishList.Models;
using System.Collections.Generic;
using System.Linq;
namespace WishList.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ItemController(ApplicationDbContext context)
        {
            _context = context;
        }
       
        public IActionResult Index()
        {
            var model = _context.Items.ToList();
            return View("Index",model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }
        [HttpPost]
        public IActionResult Create(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
          return  RedirectToAction("Index");
        }


        public IActionResult Delete(int Id)
        {
            var item = _context.Items.FirstOrDefault(p => p.Id == Id);
            _context.Items.Remove(item);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
