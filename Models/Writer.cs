using eLibrary.Data.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eLibrary.Models
{
    public class Writer : IEntityBase
    {
        [Key]
        public int Id { get; set; } 
        [Display(Name = "Writer profile picture")]
        [Required(ErrorMessage = "Profile picture is required")]
        public string ProfilePictureURL { get; set; }
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength =3, ErrorMessage = "Name must beetwen 3 and 50 chars")]
        public string FullName { get; set; }
        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Biography is required")]
        public string Bio { get; set; }

        //Relationships
        public List<Book> Books { get; set; }
    }
}
