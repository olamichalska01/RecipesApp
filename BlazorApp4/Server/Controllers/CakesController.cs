using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlazorApp4.Shared;
using BlazorApp4.Shared.DataTransferObjects;
using BlazorApp4.Server.Services.CakeService;

namespace BlazorApp4.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CakesController : ControllerBase
    {
        private readonly ICakesRepostiory cakesRepostiory;

        public CakesController(ICakesRepostiory cakesRepostiory)
        {
            this.cakesRepostiory = cakesRepostiory;
        }

        [HttpGet("GetCakesList")]
        public async Task<ActionResult<IEnumerable<Cake>>> GetCakes()
        {
            return Ok(await cakesRepostiory.GetCakes());
        }

        [HttpGet("GetCakesByDifficultyLevel/{difficultyLevel}")]
        public async Task<ActionResult<IEnumerable<Cake>>> GetCakesByDifficultyLevel(string difficultyLevel)
        {
            return Ok(await cakesRepostiory.GetCakes(difficultyLevel));
        }

        [HttpGet("CakesList/{id:int}")]
        public async Task<ActionResult<Cake>> GetCake(int id)
        {
            var result = await cakesRepostiory.GetCake(id);

            if (result == null)
            {
                return NotFound();
            }

            return result;
        }


        [HttpPost]
        public async Task<ActionResult<int>> AddCake(CakeDto cakeDto)
        {
            int id = await cakesRepostiory.AddCake(cakeDto);

            return id;
        }

        [HttpPut("CakesList/{id:int}")]
        public async Task<ActionResult<ServiceResponse<int>>> UpdateCake(int id, CakeDto cakeDto)
        {   
            var response = await cakesRepostiory.UpdateCake(id, cakeDto);

            if(!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpDelete("CakesList/{id:int}")]
        public async Task<ActionResult<Cake>> DeleteCake(int id)
        {
            var result = await cakesRepostiory.DeleteCake(id);

            if (result == null)
            {
                return NotFound($"Cake with Id = {id} not found.");
            }

            return result;
        }
    }
}
