using DataLibrary;
using System.ComponentModel.DataAnnotations;

namespace DataLibrary
{
    public class Author
    {
        [Key]
        public int ID { get; set; }

        [Required, MaxLength(15)]
        public string FirstName { get; set; }

        [Required, MaxLength(15)]
        public string LastName { get; set; }

        public Author(int id, string firstName, string lastName)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            Books = new List<Book>();
        }

        public List<Book> Books { get; set;}

        public Author() { }
    }
}
