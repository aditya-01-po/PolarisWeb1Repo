using PolarisWeb1.Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
//using PolarisWeb1.Demo.Models;

namespace PolarisWeb1.Demo.Controllers
{
    public class EmployeesController : Controller
    {
        private NewDbContext db = new NewDbContext();
        // GET: Employee
        public ActionResult Index()
        {
            return View(db.Employees.ToList());
        }

       public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Code,FirstName,LastName,DOJ,Mobile,Email")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }
    }
}