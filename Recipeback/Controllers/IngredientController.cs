using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recipeback.Models;

namespace Recipeback.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        StockRecipesContext dbContext = new StockRecipesContext();
        
        //add ingredient
        [HttpPost("/Ingredient/{name}")]
        public IActionResult AddIngredient(Ingredient name)
        {
            name.Id = 0;
            if(name == null)
            {
                return BadRequest();
            }
            dbContext.Ingredients.Add(name);
            dbContext.SaveChanges();
            return Created($"api/Ingredient/{name.Id}", name);

        }

        //retrieving ingredient information in a list
        [HttpGet()]
        public IActionResult GetAllIngredients()
        {
            List<Ingredient> result = dbContext.Ingredients.ToList();
            return Ok(result);
        }

        //retrieving ingredient information for the recipe requested
        [HttpGet("recipe")]
        public IActionResult GetIngredients(string recipe)
        {
            //recipe = recipe.Trim().ToLower();
            if (recipe == null)
            {
                return NotFound();
            }
            {
                
            }
            List<Ingredient> ingredient = dbContext.Ingredients.Where(x => x.Recipe.ToLower().Contains(recipe.ToLower())).ToList();
            return Ok(ingredient);
        }

        //removing ingredients ny name
        [HttpDelete("{name}")]
        public IActionResult RemoveIngredient(string name)
        {
            if (string.IsNullOrEmpty(name)) { return NotFound(); }
            Ingredient ingredient = dbContext.Ingredients.FirstOrDefault(x => x.Itemname == name);
            dbContext.Ingredients.Remove(ingredient);
            dbContext.SaveChanges();
            return NoContent();
        }

        //updating an ingredients item
        [HttpPut("{id}")]
        public IActionResult UpdateIngredient([FromBody] Ingredient ingredient, int id)
        {
            if(id != ingredient.Id){ return BadRequest(); }
            if(!dbContext.Ingredients.Any(i => i.Id == id)){ return NotFound(); }
            dbContext.Ingredients.Update(ingredient);
            dbContext.SaveChanges();
            return NoContent();

        }
    }
}
