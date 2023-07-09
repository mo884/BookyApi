using BookApi.Models;
using System.ComponentModel.DataAnnotations;

namespace BookApi.ModelVM
{
    public class AutherVM
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public List<Book>? books { get; set; }
    }
}
