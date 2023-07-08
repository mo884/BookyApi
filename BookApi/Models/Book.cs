using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookApi.Models
{
    [Table("Book")]
    public class Book
    {
        [Key]
        public int ID { get; set; }
        [Required, MaxLength(200, ErrorMessage = "Title  Max Length 200 !")]
        public string Title { get; set; }
        [Required, MaxLength(700, ErrorMessage = "*")]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }

    }
}
