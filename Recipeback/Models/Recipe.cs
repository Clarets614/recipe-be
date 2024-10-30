using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipeback.Models;

public partial class Recipe
{
    public int Id { get; set; }

    public string? Title { get; set; }
    public string? Steps { get; set; }

}
