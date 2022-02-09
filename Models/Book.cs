using eLibrary.Data;
using eLibrary.Data.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eLibrary.Models
{
    public class Book:IEntityBase
    {
        [Key]
        public int Id { get; set; } 
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public double Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public BookCategory BookCategory { get; set; }

        //Relationship - imamo samo Writer
        public int WriterId { get; set; }
        [ForeignKey("WriterId")]
        public Writer Writer { get; set; }
        

    }
}
