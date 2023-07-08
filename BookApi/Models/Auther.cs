using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookApi.Models
{
    [Table("Auther")]
    public class Auther
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Book> books { get; set; }

    }
}
