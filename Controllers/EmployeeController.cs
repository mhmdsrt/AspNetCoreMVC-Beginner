using AspNetCoreProject1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace AspNetCoreProject1.Controllers
{
	[Authorize] // Authorize -> Yetki Vermek
	public class EmployeeController : Controller
    {
        Context context = new Context();

        [HttpGet]
     
        public IActionResult GetAllEmployee()
        {
            var getAllEmployee = context.Employees.Include(m => m.Department).ToList();
            return View(getAllEmployee);
        }


        [HttpGet]
        public IActionResult InsertEmployee()
        {
            List<SelectListItem> selectListDepartment = (from i in context.Departments
                                             select new SelectListItem
                                             {
                                                 Text = i.DepartmentName,
                                                 Value = i.DepartmentID.ToString()
                                             }).ToList();

            ViewBag.selectListDepartment = selectListDepartment;

            return View();
        }


        [HttpPost]
        public IActionResult InsertEmployee(Employee entity)
        {
            context.Employees.Add(entity);
            context.SaveChanges();

            return RedirectToAction("GetAllEmployee");
        }


        public IActionResult DeleteEmployee(int id)
        {
            var employeeToDelete = context.Employees.Find(id);
            if (employeeToDelete != null)
            {
                context.Employees.Remove(employeeToDelete);
                context.SaveChanges();

            }
            return RedirectToAction("GetAllEmployee");
        }
    }
}
