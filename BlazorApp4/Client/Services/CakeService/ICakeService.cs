using BlazorApp4.Shared;
using BlazorApp4.Shared.DataTransferObjects;

namespace BlazorApp4.Client.Services.CakeService
{
    public interface ICakeService
    {
        Task<List<Cake>> GetCakes();
        Task<IEnumerable<string>> GetCurrentDifficultyLevels(List<Cake> cakes);
        Task DeleteCake(int id);
        Task<List<Cake>> FilterByDifficultyLevel(string filterDifficultyLevelValue);
        Task<int> AddEmptyCake();
        Task<ServiceResponse<int>> ModifyCake(NewCakeDto newCakeDto, int newCakeId);
    }
}
