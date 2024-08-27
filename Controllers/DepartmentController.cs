using AspNetCoreProject1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreProject1.Controllers
{
	[Authorize] // Authorize -> Yetki Vermek
	public class DepartmentController : Controller
    {
        Context context = new Context();

        [HttpGet]
        public IActionResult GetAllDepartment()
        {
            var getAllDepartment = context.Departments.ToList();

            return View(getAllDepartment);
        }
        [HttpGet]
        public IActionResult InsertDepartment()
        {
            return View();
        }
        [HttpPost]
        public IActionResult InsertDepartment(Department entity)
        {
            context.Departments.Add(entity);
            context.SaveChanges();
            return RedirectToAction("GetAllDepartment");
        }
        public IActionResult DeleteDepartment(int id)
        {
            var departmentToDelete = context.Departments.Find(id);
            if (departmentToDelete != null)
            {
                context.Departments.Remove(departmentToDelete);
                context.SaveChanges();
            }

            return RedirectToAction("GetAllDepartment");
        }

        [HttpGet]
        public IActionResult GetDepartmentToUpdate(int id)
        {
            var departmentToUpdate = context.Departments.Find(id);

            return View(departmentToUpdate);
        }
        [HttpPost]
        public IActionResult UpdateDepartment(Department entity)
        {
            var departmentToUpdate = context.Departments.Find(entity.DepartmentID);
            departmentToUpdate.DepartmentName = entity.DepartmentName;
            context.SaveChanges();

            return RedirectToAction("GetAllDepartment");
        }

       
        
        public IActionResult GetDetail(int id)
        {
            var employeeList = context.Employees.Include(x => x.Department).Where(x => x.DepartmentID == id).ToList();
            var departmentName = context.Departments.Where(x => x.DepartmentID == id).Select(x => x.DepartmentName).FirstOrDefault();
            /* Özetle, Select metodunu kullanmak, her zaman bir koleksiyon döndürür ve sizin bu koleksiyondan 
             sadece bir öğe almak için ekstra bir adım atmanız gerekir yani "FirstOrDefault()" metodunu kullanmalıyız..
            Sorun, Where filtresiyle yalnızca tek bir sonuç dönse bile, sorgunun bir IQueryable koleksiyonu döndürmesidir.
            Bu yüzden, tek bir değere indirgemeniz gerekiyor.
             */
            ViewBag.DepartmentName = departmentName;
            return View(employeeList);
        }
    }

}
