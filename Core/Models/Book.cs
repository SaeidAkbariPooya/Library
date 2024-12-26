
using System.ComponentModel.DataAnnotations;

namespace Library.Core.Models
{
    public class Book
    {
        #region Prop
        [Key]
        public int BookId { get; set; }
        [Required]
        [MaxLength(255)]
        [MinLength(3)]
        public string Title { get; set; }
        [Required]
        [MaxLength(255)]
        [MinLength(3)]
        public string Author { get; set; }
        public int PublishedYear { get; set; }
        public string Genre { get; set; }
        #endregion
    }
}
