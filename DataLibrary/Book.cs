using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary
{
    public class Book
    {
        [Key]
        public int ISBN {  get; set; }

        [Required, MaxLength(40)]
        public string Title { get; set; }

        public int PiulicationYear { get; set; }

        public int NumOfPages { get; set; }

        public string Genre { get; set; }

        public Book(string title, int pubYear, int numOfPages, string genre) 
        {
            Title = title;
            PiulicationYear = pubYear;
            NumOfPages = numOfPages;
            Genre = genre;
        }

        public Book() { }
    }
}
