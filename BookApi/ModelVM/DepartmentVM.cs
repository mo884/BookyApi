using BookApi.Models;
using System.ComponentModel.DataAnnotations;

namespace BookApi.ModelVM
{
    public class DepartmentVM
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public bool ISDeleted { get; set; }
        public List<Book>? Books { get; set; }

    }
}
