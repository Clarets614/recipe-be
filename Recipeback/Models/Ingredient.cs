using System;
using System.Collections.Generic;

namespace Recipeback.Models;

public partial class Ingredient
{
    public int Id { get; set; }

    public int? Recipeid { get; set; }

    public string? Itemname { get; set; }

    public float? Quantity { get; set; }

    public string? Unit { get; set; }

    public virtual Recipe? Recipe { get; set; }
}
