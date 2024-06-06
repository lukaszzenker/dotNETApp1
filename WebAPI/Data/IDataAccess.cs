using DataLibrary;
using System.Numerics;

namespace WebAPI.Data
{
    public interface IDataAccess
    {
        public Task<Author> CreateAuthorAsync(Author author);

        public Task<ICollection<Author>> GetAllAuthorsAsync();

        public Task<ICollection<Book>> GetAllBooksAsync();

        public Task AddBookToAuthor(Book book, int authorId);

        public Task DeleteBookAsync(int isbn);
    }
}
