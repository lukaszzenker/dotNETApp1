using DataLibrary;

namespace Blazor.Data
{
    public interface IAuthorService
    {
        public Task<Author> CreateAuthorAsync(Author author);

        public Task<ICollection<Author>> GetAllAuthorsAsync();

        public Task AddBookToAuthorAsync(string title, int pubYear, int numOfPages, string genre, int id);
    }
}
