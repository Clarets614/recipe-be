using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Recipeback.Models;

namespace Recipeback.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        StockRecipesContext DbContext = new StockRecipesContext();

        [HttpGet()]
        public IActionResult GetAllRecipes()
        {
            List <Recipe> result = DbContext.Recipes.ToList();
            return Ok(result);
        }

        [HttpPost()]
        public IActionResult AddRecipe(Recipe recipe)
        {
            DbContext.Recipes.Add(recipe);
            DbContext.SaveChanges();
            return Created($"/api/Recipe/{recipe.Id}", recipe);
        }

        [HttpDelete("id")]
        public IActionResult DeleteRecipe(int id)
        {
            Recipe recipe = DbContext.Recipes.Find(id);
            if(recipe == null)
            {
                return NotFound();
            }
            DbContext.Recipes.Remove(recipe);
            DbContext.SaveChanges();
            return NoContent();
        }
    }
}
