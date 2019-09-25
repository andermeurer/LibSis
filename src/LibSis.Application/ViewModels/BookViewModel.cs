using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LibSis.Application.ViewModels
{
    public class BookViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Author is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Author")]
        public string Author { get; set; }
    }
}
