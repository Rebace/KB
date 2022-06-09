using KitchenBook.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KitchenBook.Api.ApiMessages;

namespace KitchenBook.Api.MessageContracts.Mappers
{
    public static class RecipeMapper
    {
        public static RecipeDto Map(this Recipe recipe)
        {
            return new RecipeDto()
            {
                Title = recipe.Title,
                Description = recipe.Description,
                CookingTime = recipe.CookingTime,
                Portions = recipe.Portions,
                Stars = recipe.Stars,
                Likes = recipe.Likes
            };
        }
    }
}
