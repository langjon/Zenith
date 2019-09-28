using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using FinalDatabaseFirst.Models;



namespace FinalDatabaseFirst.Controllers
{
    public class EmpAccountController : Controller
    {
        //private readonly finalAssigContext db;
        finalAssigContext db = new finalAssigContext();
        public IActionResult Login()
        {
            return View();
        }

    public ActionResult Validate(EmployeeLogin employeeLogin)
        {
            var _admin = db.EmployeeLogin.Where(s => s.EmployeeLoginId == employeeLogin.EmployeeLoginId);
            if (_admin.Any())
            {
                if (_admin.Where(s => s.Pass == employeeLogin.Pass).Any())
                {

                    return Json(new { status = true, message = "Login Successfull!" });
                }
                else
                {
                    return Json(new { status = false, message = "Invalid Password!" });
                }
            }
            else
            {
                return Json(new { status = false, message = "Invalid Employee ID!" });
            }
        }

        /*   public ActionResult Validate(Admins admin)
           {
               var _admin = db.Admins.Where(s => s.Email == admin.Email);
               if (_admin.Any())
               {
                   if (_admin.Where(s => s.Password == admin.Password).Any())
                   {

                       return Json(new { status = true, message = "Login Successfull!" });
                   }
                   else
                   {
                       return Json(new { status = false, message = "Invalid Password!" });
                   }
               }
               else
               {
                   return Json(new { status = false, message = "Invalid Email!" });
               }
           }*/
    }
}