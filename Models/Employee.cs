using System.ComponentModel.DataAnnotations;

namespace AspNetCoreProject1.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeSurName { get; set; }
        public string EmployeeCity { get; set; }

        public int DepartmentID { get; set; } // Veri tabanında DepartmentID sütununu temsil eden property'miz.
        public Department Department { get; set; } /* Bu kod yazdığımız "Department" isimli property'nin sonuna
                                                      ID koyarak database tarafında DepartmentID isimli bir sütun oluşturuyor.
                                                      Böylece DepartmentID adında Employee tablosunda bir foreing key tanımlamış
                                                      oluyoruz.
                                                    */

    }
}
