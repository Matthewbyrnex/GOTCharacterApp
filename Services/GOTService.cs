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
            return await _httpClient.GetFromJsonAsync<Book>(url);
        }

        // Method to get a character by URL
        public async Task<Character> GetCharacterByUrlAsync(string url)
        {
            return await _httpClient.GetFromJsonAsync<Character>(url);
        }

        public async Task<string> GetCharacterNameByUrlAsync(string url)
        {
            var character = await _httpClient.GetFromJsonAsync<Character>(url);
            return character != null ? character.FullName : null;
        }

        // In GOTService.cs
        public async Task<string> GetHouseNameByUrlAsync(string url)
        {
            var house = await _httpClient.GetFromJsonAsync<House>(url);
            return house != null ? house.Name : null;
        }

        

    }
}
