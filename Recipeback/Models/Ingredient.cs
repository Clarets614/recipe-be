using System;
using System.Collections.Generic;

namespace Recipeback.Models;

public partial class Ingredient
{
    public int Id { get; set; }

    public string? Recipe { get; set; }

    public string? Itemname { get; set; }

    public float? Qty { get; set; }

    public string? Units { get; set; }
}
