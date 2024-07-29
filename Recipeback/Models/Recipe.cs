using System;
using System.Collections.Generic;

namespace Recipeback.Models;

public partial class Recipe
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public virtual ICollection<Ingredient>? Ingredients { get; set; } = new List<Ingredient>();
}
