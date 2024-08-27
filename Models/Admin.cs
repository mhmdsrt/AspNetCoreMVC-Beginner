using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCoreProject1.Models
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }

        [Column(TypeName = "Varchar(20)")]
        public string AdminName { get; set; }

        [Column(TypeName = "Varchar(10)")]
        public string AdminPassword { get; set; }
    }
}
