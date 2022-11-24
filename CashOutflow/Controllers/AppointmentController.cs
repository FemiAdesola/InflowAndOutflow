using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CashOutflow.Controllers
{
    public class AppointmentController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            //string todaysDate = DateTime.Now.ToShortDateString();
            //return Ok(todaysDate);
            return View();
        }


        public IActionResult Details(int id)
        {
            return Ok("let see it = {id}" + id);
        }

    }
}

