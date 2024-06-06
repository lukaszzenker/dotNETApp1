using DataLibrary;
using Microsoft.AspNetCore.Mvc;

namespace Blazor.Data
{
    public interface IBookService
    {
        public Task<ICollection<Book>> GetAllBooksAsync();

        public Task DeleteBookAsync(int isbn);
    }
}
