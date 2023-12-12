using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using GOTCharacterApp.Models;

using System.Collections.Generic;
using System.Linq;


namespace GOTCharacterApp.Services
{
    public class GOTService
    {
        private readonly HttpClient _httpClient;

        public GOTService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Character[]> GetAllCharactersAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<Character[]>("/Characters");
            return response;
        }

        public async Task<IceAndFireCharacter> GetIceAndFireCharacterAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<IceAndFireCharacter>($"https://anapioficeandfire.com/api/Characters/{id}");
        }

        public async Task<IceAndFireCharacter> GetIceAndFireCharacterByNameAsync(string name)
        {
            var characters = await _httpClient.GetFromJsonAsync<List<IceAndFireCharacter>>($"https://anapioficeandfire.com/api/Characters?name=" + Uri.EscapeDataString(name));
            return characters.FirstOrDefault();
        }

        // Method to get a house by URL
        public async Task<House> GetHouseByUrlAsync(string url)
        {
            return await _httpClient.GetFromJsonAsync<House>(url);
        }


        // Method to get a book by URL
        public async Task<Book> GetBookByUrlAsync(string url)
        {
            try
            {
                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<Book>();
            }
            catch (HttpRequestException ex)
            {
                // Log the exception details here
                Console.Error.WriteLine($"Error fetching book data: {ex.Message}");
                return null; // or handle the exception as appropriate
            }
        }

        // Method to get a character by URL
        public async Task<Character> GetCharacterByUrlAsync(string url)
        {
            return await _httpClient.GetFromJsonAsync<Character>(url);
        }

       
        public async Task<(string Id, string Name)> GetCharacterNameByUrlAsync(string url)
        {
            var character = await _httpClient.GetFromJsonAsync<IceAndFireCharacter>(url);
            if (character != null)
            {
                var id = new Uri(url).Segments.Last();
                return (Id: id, Name: character.Name);
            }
            else
            {
                return (Id: null, Name: "Unknown Character");
            }
        }

        // In GOTService.cs
        public async Task<string> GetHouseNameByUrlAsync(string url)
        {
            var house = await _httpClient.GetFromJsonAsync<House>(url);
            return house != null ? house.Name : null;
        }


        public async Task<Book> GetBookByIdAsync(string id)
        {
            var url = $"https://anapioficeandfire.com/api/books/{id}";
            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Book>();
            }
            else
            {
                // Handle the case where the API does not return a 2xx success code
                throw new HttpRequestException($"HTTP request failed with status code {response.StatusCode}");
            }
        }


    }
}
