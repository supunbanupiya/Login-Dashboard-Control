using LogiinLogout.Models;
using Microsoft.AspNetCore.Mvc;

namespace LogiinLogout.Controllers
{
	public class userController : Controller
	{
		public readonly mycontext my_context;

		public userController(mycontext my)
		{
			this.my_context = my;
		}
		public IActionResult Index()
		{
          
            var name = HttpContext.Session.GetString("myname");
            ViewBag.myname = name;
            return View();
        }
		public IActionResult register() 
		{ 
			return View();
		}
	
		[HttpPost]
		public IActionResult register(employee emp)   
		{
			my_context.employees.Add(emp);
			my_context.SaveChanges();
			ViewBag.success = "Record Added"; 
			ModelState.Clear();
			return View();      
		}
		public IActionResult login() 
		{ 
			return View();
		}
		[HttpPost]
		public IActionResult login(employee emp)
		{
			var check = my_context.employees.Where(x=>x.employeemail==emp.employeemail && x.employeepassword==emp.employeepassword).FirstOrDefault();
			if(check!=null)
			{
				HttpContext.Session.SetString("myname",check.employeename);
				var name = HttpContext.Session.GetString("myname");
				ViewBag.myname = name;
				return View("Index");
			}
			ViewBag.error = "Error - Data not found!";
			return View();
	    }
		public IActionResult logout()
		{
			if(HttpContext.Session.GetString("myname")!="")
			{
				HttpContext.Session.SetString("myname", "");
				return RedirectToAction("login");
			}
			return View();
		}
	}
}
