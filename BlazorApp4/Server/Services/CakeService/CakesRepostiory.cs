using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using BlazorApp4.Shared;
using BlazorApp4.Shared.DataTransferObjects;
using BlazorApp4.Server.Models;

namespace BlazorApp4.Server.Services.CakeService
{
    public class CakesRepostiory : ICakesRepostiory
    {
        private readonly CakesDBContext cakesDBContext;
        public CakesRepostiory(CakesDBContext cakesDBContext)
        {
            this.cakesDBContext = cakesDBContext;
        }

        public async Task<IEnumerable<Cake>> GetCakes()
        {
            return await cakesDBContext.Cakes.Include(c => c.Recipe).ToListAsync();
        }

        public async Task<IEnumerable<Cake>> GetCakes(string difficultyLevel)
        {
            if (difficultyLevel.Equals("-"))
            {
                return await cakesDBContext.Cakes.Include(c => c.Recipe).ToListAsync();
            }

            return await cakesDBContext.Cakes.Include(c => c.Recipe)
                .Where(c => c.DifficultyLevel == difficultyLevel)
                .ToListAsync();
        }

        public async Task<Cake> GetCake(int cakeId)
        {
            var cake = await cakesDBContext.Cakes
                .FirstOrDefaultAsync(e => e.CakeId == cakeId);

            if (cake != null)
            {
                return cake;
            }

            return null;
        }

        public async Task<int> AddCake(CakeDto cakeDto)
        {
            Cake newCake = new Cake
            {
                CakeName = cakeDto.CakeName,
                DifficultyLevel = cakeDto.DifficultyLevel,
                PreparationTime = cakeDto.PreparationTime
            };

            await cakesDBContext.Cakes.AddAsync(newCake);
            await cakesDBContext.SaveChangesAsync();

            return newCake.CakeId;
        }

        public async Task<ServiceResponse<int>> UpdateCake(int cakeId, CakeDto cakeDto)
        {
            var cakeToUpdate = await cakesDBContext.Cakes
                .FirstOrDefaultAsync(e => e.CakeId == cakeId);

            if (cakeToUpdate == null)
            {
                return new ServiceResponse<int>
                {
                    Success = false,
                    Message = "No cake with this id was found."
                };
            }

            if (cakeDto.PreparationTime == "" || cakeDto.CakeName == "" || cakeDto.DifficultyLevel == "")
            {
                return new ServiceResponse<int>
                {
                    Success = false,
                    Message = "Please provide all cake information before submitting."
                };           
            }

            cakeToUpdate.CakeName = cakeDto.CakeName;
            cakeToUpdate.DifficultyLevel = cakeDto.DifficultyLevel;
            cakeToUpdate.PreparationTime = cakeDto.PreparationTime;

            await cakesDBContext.SaveChangesAsync();

            return new ServiceResponse<int> { Data = cakeId, Message = "Cake updated successfully."};
        }

        public async Task<Cake> DeleteCake(int cakeId)
        {
            var result = await cakesDBContext.Cakes
                .FirstOrDefaultAsync(e => e.CakeId == cakeId);

            if (result != null)
            {
                cakesDBContext.Cakes.Remove(result);

                await cakesDBContext.SaveChangesAsync();

                return result;
            }

            return null;
        }
    }
}
