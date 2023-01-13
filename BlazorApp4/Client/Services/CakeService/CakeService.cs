using BlazorApp4.Shared;
using BlazorApp4.Shared.DataTransferObjects;
using System.Net.Http.Json;

namespace BlazorApp4.Client.Services.CakeService
{
    public class CakeService : ICakeService
    {
        private readonly HttpClient httpClient;

        public CakeService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<Cake>> GetCakes()
        {
            return await httpClient.GetFromJsonAsync<List<Cake>>("api/Cakes/GetCakesList");
        }

        public async Task<IEnumerable<string>> GetCurrentDifficultyLevels(List<Cake> cakes)
        {
            return cakes.Select(c => c.DifficultyLevel).Distinct();
        }

        public async Task DeleteCake(int id)
        {
            await httpClient.DeleteAsync($"api/Cakes/CakesList/{id}");
        }

        public async Task<int> AddEmptyCake()
        {
            Cake NewCake = new Cake
            {
                CakeName = " ",
                DifficultyLevel = "easy",
                PreparationTime = " "
            };

            var result = await httpClient.PostAsJsonAsync("api/Cakes", NewCake);
            return Int32.Parse(await result.Content.ReadAsStringAsync());
        }

        public async Task<ServiceResponse<int>> ModifyCake(NewCakeDto newCakeDto, int newCakeId)
        {
            CakeDto cakeDto = new CakeDto
            {
                PreparationTime = newCakeDto.PreparationTime,
                CakeName = newCakeDto.CakeName,
                DifficultyLevel = newCakeDto.DifficultyLevel
            };

            var result = await httpClient.PutAsJsonAsync($"api/Cakes/CakesList/{newCakeId}", cakeDto);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<int>>();
        }

        public async Task<List<Cake>> FilterByDifficultyLevel(string filterDifficultyLevelValue)
        {
            return await httpClient.GetFromJsonAsync<List<Cake>>($"api/Cakes/GetCakesByDifficultyLevel/{filterDifficultyLevelValue}");
        }
    }
}
