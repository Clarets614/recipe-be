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

        //retrieves a list of recipes
        [HttpGet()]
        public IActionResult GetAllRecipes()
        {
            List <Recipe> result = DbContext.Recipes.ToList();
            return Ok(result);
        }

        //adds a recipe item to recipes database
        [HttpPost("/Recipe")]
        public IActionResult AddRecipe(Recipe recipe)
        {
            recipe.Id = 0;
            DbContext.Recipes.Add(recipe);
            DbContext.SaveChanges();
            return Created($"/api/Recipe/{recipe.Id}", recipe);
        }

        //removes recipe item from the database by the id number
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

        //updates a recipe item
        [HttpPut("{id}")]
        public IActionResult UpdateRecipe([FromBody]Recipe recipe, int id)
        {
            if(id != recipe.Id) { return BadRequest(); }
            if(!DbContext.Recipes.Any(r=>r.Id == id)) { return NotFound(); }
            DbContext.Recipes.Update(recipe);
            DbContext.SaveChanges();
            return NoContent();
        }

    }
}
