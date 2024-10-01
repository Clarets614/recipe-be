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
        [HttpPost()]
        public IActionResult AddIngredient([FromBody] Ingredient ingredient)
        {
            ingredient.Id = 0;
            dbContext.Ingredients.Add(ingredient);
            dbContext.SaveChanges();
            return Created($"api/Ingredient/{ingredient.Id}", ingredient);

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
            if (recipe == null)
            {
                return NotFound();
            }
            {
                
            }
            List<Ingredient> ingredient = dbContext.Ingredients.Where(x => x.Recipe.ToLower().Contains(recipe.ToLower())).ToList();
            return Ok(ingredient);
        }

        ////removing ingredients by name
        //[HttpDelete("{name}")]
        //public IActionResult RemoveIngredient(string name)
        //{
        //    if (string.IsNullOrEmpty(name)) { return NotFound(); }
        //    Ingredient ingredient = dbContext.Ingredients.FirstOrDefault(x => x.Itemname == name);
        //    dbContext.Ingredients.Remove(ingredient);
        //    dbContext.SaveChanges();
        //    return NoContent();
        //}

        [HttpDelete("{id}")]

        public IActionResult DeleteIngredient(int id)
        {
            Ingredient result = dbContext.Ingredients.Find(id);
            if (result == null) { return NotFound(); }
            dbContext.Ingredients.Remove(result);
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
