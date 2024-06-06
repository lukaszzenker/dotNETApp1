using DataLibrary;
using System.Numerics;
using System.Text.Json;

namespace Blazor.Data
{
    public class AuthorHttpClient : IAuthorService
    {
        private readonly HttpClient client;

        public AuthorHttpClient(HttpClient client)
        {
            this.client = client;
        }

        public async Task<Author> CreateAuthorAsync(Author author)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("author", author);
            string result = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(result);
            }

            Author createdAuthor = JsonSerializer.Deserialize<Author>(result, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;

            return createdAuthor;
        }

        public async Task<ICollection<Author>> GetAllAuthorsAsync()
        {
            string uri = "/authors";
            HttpResponseMessage response = await client.GetAsync(uri);

            string result = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(result);
            }

            try
            {
                ICollection<Author> authors = JsonSerializer.Deserialize<ICollection<Author>>(result, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                })!;
                return authors;
            }
            catch (JsonException ex)
            {
                throw new Exception("Error deserializing Author data.", ex);

            }
        }

        public async Task AddBookToAuthorAsync(string title, int pubYear, int numOfPages, string genre, int id)
        {
            // Build the endpoint URL with query parameters
            string endpoint = $"/AddBookToAuthor?Title={title}&PiulicationYear={pubYear}&NumOfPages={numOfPages}&Genre={genre}&ID={id}";

            // Send the POST request to add the grade to the student
            HttpResponseMessage response = await client.PostAsync(endpoint, null);
            string result = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                throw new Exception(content);
            }
        }
    }
}
