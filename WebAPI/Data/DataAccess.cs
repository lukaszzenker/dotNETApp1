using DataLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Numerics;

namespace WebAPI.Data
{
    public class DataAccess : IDataAccess
    {
        private readonly Context context;

        public DataAccess(Context context)
        {
            this.context = context;
        }

        public async Task<Author> CreateAuthorAsync(Author author)
        {
            EntityEntry<Author> newAuthor = await context.Authors.AddAsync(author);
            await context.SaveChangesAsync();
            return newAuthor.Entity;
        }

        public async Task<ICollection<Author>> GetAllAuthorsAsync()
        {
            ICollection<Author> authors;
            authors = await context.Authors.ToListAsync();
            return authors;
        }

        public async Task AddBookToAuthor(Book book, int authorId)
        {
            Author foundAuthor = await context.Authors.Include(t => t.Books).FirstOrDefaultAsync(t => t.ID == authorId);

            if (foundAuthor != null)
            {
                Book newBook = book;
                foundAuthor.Books.Add(newBook);
                await context.SaveChangesAsync();

            }
            else
            {
                throw new ArgumentException("Author not found");
            }

            
        }

        public async Task<ICollection<Book>> GetAllBooksAsync()
        {
            ICollection<Book> books;
            books = await context.Books.ToListAsync();
            return books;
        }

        public async Task DeleteBookAsync(int isbn)
        {
            Book bookToDelete = await context.Books.FindAsync(isbn);

            if (bookToDelete != null)
            {
                context.Books.Remove(bookToDelete);
                await context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("Book not found");
            }
        }
    }
}
