using Microsoft.AspNetCore.Mvc;
using BlazorApp4.Shared;
using BlazorApp4.Shared.DataTransferObjects;

namespace BlazorApp4.Server.Services.CakeService
{
    public interface ICakesRepostiory
    {
        Task<IEnumerable<Cake>> GetCakes();
        Task<Cake> GetCake(int cakeId);
        Task<int> AddCake(CakeDto cakeDto);
        Task<ServiceResponse<int>> UpdateCake(int cakeId, CakeDto cakeDto);
        Task<Cake> DeleteCake(int cakeId);
        Task<IEnumerable<Cake>> GetCakes(string difficultyLevel);
    }
}
