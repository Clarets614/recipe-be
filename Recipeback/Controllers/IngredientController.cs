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

        [HttpPost("name")]
        public IActionResult AddIngredient(Ingredient name)
        {
            if(name == null)
            {
                return BadRequest();
            }
            dbContext.Ingredients.Add(name);
            dbContext.SaveChanges();
            return Created($"api/Ingredient/{name.Id}", name);

        }
        [HttpGet()]
        public IActionResult GetAllIngredients()
        {
            List<Ingredient> result = dbContext.Ingredients.ToList();
            return Ok(result);
        }

        [HttpGet("recipe")]
        public IActionResult GetIngredients(string recipe)
        {
            if (recipe == null)
            {
                return NotFound();
            }
            {
                
            }
            List<Ingredient> ingredient = dbContext.Ingredients.Where(x => x.Recipe == recipe).ToList();
            return Ok(ingredient);
        }

        [HttpDelete("{name}")]
        public IActionResult RemoveIngredient(string name)
        {
            if (string.IsNullOrEmpty(name)) { return NotFound(); }
            Ingredient ingredient = dbContext.Ingredients.FirstOrDefault(x => x.Itemname == name);
            dbContext.Ingredients.Remove(ingredient);
            dbContext.SaveChanges();
            return NoContent();
        }
    }
}
