using jsgriddynamic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Graph;
using Microsoft.Graph.Models;
using System.Collections.Specialized;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Numerics;
using System.Security.Principal;
using System.Web;
using static Microsoft.Graph.Constants;

namespace jsgriddynamic.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext context;

        public HomeController(ApplicationDbContext context)
        {
            this.context = context;
        }


       
        public IActionResult Index()
        {
            return View();
        }

        

        public IActionResult Employee()
        {
            var data = context.Employees.ToList();
            return new JsonResult(data);
        }
        [HttpPost]
        public JsonResult AddEmployee(Employee employee) 
        {
            var emp = new Employee()
            {
                Name = employee.Name,
                Email = employee.Email,
                Phone = employee.Phone,
                Age = employee.Age,
                Gender = employee.Gender,
                Country = employee.Country,
                State = employee.State,
                City = employee.City,
                PostalCode = employee.PostalCode,
            };
            context.Employees.Add(emp);
            context.SaveChanges();
            return new JsonResult(employee);
           
        }

        [HttpPut]
        public ActionResult EditEmployee(int id,Employee edited)
        {
            Employee emp = context.Employees.Find(id);

            if(emp == null) 
            { 
                return View();  
            }

            emp.Name = edited.Name;
            emp.Email = edited.Email;
            emp.Phone = edited.Phone;
            emp.Age = edited.Age;
            emp.Gender = edited.Gender;
            emp.Country = edited.Country;
            emp.State = edited.State;
            emp.City = edited.City;
            emp.PostalCode = edited.PostalCode;
            
            
            context.SaveChanges();
            return new JsonResult(edited);

        }
       
        public JsonResult Delete(int? id)
        {
            if (id == null || context.Employees == null)
            {
                return new JsonResult("");
            }

            var stdData = context.Employees.FirstOrDefault(s => s.Id == id);
            if (stdData == null)
            {
                return new JsonResult("");
            }
            return new JsonResult(stdData);


        }

        [HttpPost, ActionName("Delete")]
        public JsonResult DeleteConfimed(int? id)
        {
            var stdData = context.Employees?.Find(id);
            if (stdData != null)
            {
                context.Employees?.Remove(stdData);
            }
            context.SaveChanges();
            return new JsonResult(stdData);


        }
        


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}