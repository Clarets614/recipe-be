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

        [HttpPost()]
        public IActionResult AddIngredient(Ingredient name)
        {
            dbContext.Ingredients.Add(name);
            dbContext.SaveChanges();
            return Created($"api/Ingredient/{name.Id}", name);

        }

        [HttpGet()]
        public IActionResult GetIngredients(string recipe)
        {
            List<Ingredient> ingredient = dbContext.Ingredients.Where(x => x.Recipe == recipe).ToList();
            return Ok(ingredient);
        }
    }
}
