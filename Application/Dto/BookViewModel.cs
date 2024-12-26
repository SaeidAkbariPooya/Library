using System.ComponentModel.DataAnnotations;

namespace Library.Application.Dto
{
    public class BookViewModel
    {
        public int BookId { get; set; }
        [Display(Name = "عنوان")]
        [Required]
        [MaxLength(255)]
        [MinLength(3)]
        public string Title { get; set; }
        [Display(Name = "نویسنده")]
        [Required]
        [MaxLength(255)]
        [MinLength(3)]
        public string Author { get; set; }
        [Display(Name = "سال انتشار")]
        public int PublishedYear { get; set; }
        [Display(Name = "ژانر")]
        public string Genre { get; set; }
    }
}
