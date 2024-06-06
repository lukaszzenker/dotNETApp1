using DataLibrary;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net;
using System.Numerics;
using System.Text.Json;

namespace Blazor.Data
{
    public class BookHttpClient : IBookService
    {
        private readonly HttpClient client;

        public BookHttpClient(HttpClient client)
        {
            this.client = client;
        }

        public async Task<ICollection<Book>> GetAllBooksAsync()
        {
            string uri = "/books";
            HttpResponseMessage response = await client.GetAsync(uri);

            string result = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(result);
            }

            try
            {
                ICollection<Book> books = JsonSerializer.Deserialize<ICollection<Book>>(result, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                })!;
                return books;
            }
            catch (JsonException ex)
            {
                throw new Exception("Error deserializing Book data.", ex);

            }


        }

        public async Task DeleteBookAsync(int isbn)
        {
            HttpResponseMessage response = await client.DeleteAsync($"/DeleteBook/{isbn}");

            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new ArgumentException("Book not found");
                }
                else
                {
                    throw new Exception($"Error deleting book. Status code: {response.StatusCode}");
                }
            }
        }
    }
}
