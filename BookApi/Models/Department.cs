using System.ComponentModel.DataAnnotations;

namespace BookApi.Models
{
    public class Department
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public bool ISDeleted { get; set; }
        public List<Book>? Books { get; set; }

    }
}
