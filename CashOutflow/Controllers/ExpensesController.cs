using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CashOutflow.Data;

using CashOutflow.Models;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CashOutflow.Controllers
{
    public class ExpensesController : Controller
    {

        private readonly ApplicationDbContext _db;

        public ExpensesController(ApplicationDbContext db)
        {
            _db = db;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            IEnumerable<Expenses> objList = _db.Expenses;
            return View(objList);
            //return View();
        }

        //GET-Create
        public IActionResult Create()
        {
            return View();
        }

        //Post-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Expenses obj)
        {
            // for passing data to database
            if (ModelState.IsValid)
            {
                _db.Expenses.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //Get-Delete ########################################
        public IActionResult Delete(int? id)
        {
            // for passing data to database
            
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Expenses.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }


        //Post-Delete  ########################################
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            // for passing data to database

            var obj = _db.Expenses.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Expenses.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

        //Get-update  ########################################

        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Expenses.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }


        //post-update  ########################################
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Expenses obj)
        {
            // for passing data to database
            if (ModelState.IsValid)
            {
                _db.Expenses.Update(obj);
                _db.SaveChanges();
                //return RedirectToAction("Index");
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }
    }
}

