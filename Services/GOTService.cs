using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using GOTCharacterApp.Models;

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

    }
}
