using KitchenBook.Api.ApiMessages;
using KitchenBook.Api.MessageContracts;
using KitchenBook.Api.MessageContracts.Mappers;
using KitchenBook.Domain;
using KitchenBook.Infrastructure.Repository;
using KitchenBook.Infrastructure.UoF;
using Microsoft.AspNetCore.Mvc;

namespace KitchenBook.Api.Controllers
{
    [Route("recipe")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RecipeController(IRecipeRepository recipeRepository, IUnitOfWork unitOfWork)
        {
            _recipeRepository = recipeRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll()
        {
            List<Recipe> recipes = await _recipeRepository.GetRecipeList();
            return Ok(recipes.Select(x => x.Map()));
        }

        [HttpGet]
        [Route("{recipeId}")]
        public async Task<IActionResult> GetById(int recipeId)
        {
            Recipe recipe = await _recipeRepository.GetById(recipeId);
            return Ok(recipe.Map());
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] RecipeDto recipeDto)
        {
            var createdRecipe = await _recipeRepository.Create(new Recipe(recipeDto.Title, recipeDto.Description,
                recipeDto.CookingTime, recipeDto.Portions, recipeDto.Stars, recipeDto.Likes));
            _unitOfWork.Commit();

            return Ok(createdRecipe.Id);
        }

        [HttpDelete]
        [Route("{recipeId}/delete")]
        public async Task<IActionResult> Delete(int recipeId)
        {
            Recipe recipe = await _recipeRepository.GetById(recipeId);

            _recipeRepository.Delete(recipe);
            _unitOfWork.Commit();
            return NoContent();
        }
    }
}
