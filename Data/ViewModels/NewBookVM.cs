using eLibrary.Data;
using eLibrary.Data.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eLibrary.Models
{
    public class NewBookVM
    {
        public int Id { get; set; }
        [Display(Name  = "Book Title")]
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [Display(Name = "Book description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        [Display(Name = "Book image cover")]
        [Required(ErrorMessage = "Image cover URL is required")]
        public string ImageURL { get; set; }
        [Display(Name = "Book price")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }
        [Display(Name = "Book release date")]
        [Required(ErrorMessage = "Release date is required")]
        public DateTime ReleaseDate { get; set; }
        [Display(Name = "Book category")]
        [Required(ErrorMessage = "Category is required")]
        public BookCategory BookCategory { get; set; }
        [Display(Name = "Select Book writer")]
        [Required(ErrorMessage = "Writer is required")]

        public int WriterId { get; set; }
    }
}
