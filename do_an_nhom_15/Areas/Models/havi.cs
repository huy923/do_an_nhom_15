using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace do_an_nhom_15.Areas.admin.Models
{
    [Table("AdminUsers")]
    public class Havi
    {
        [Key]
        public int AdminId { get; set; }
        public string? Username { get; set; }
        public string? FullName { get; set; }
        public string? Password { get; set; }
        public bool IsActive { get; set; }


    }
}
