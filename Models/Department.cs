using System.ComponentModel.DataAnnotations;

namespace AspNetCoreProject1.Models
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }

        public string DepartmentName { get; set; }

        public List<Employee> Employees { get; set; }
        // Yani bu ifadeyle benim her departmanımın içerisinde birden fazla çalışan bulunabilir diyoruz.
    }
}
