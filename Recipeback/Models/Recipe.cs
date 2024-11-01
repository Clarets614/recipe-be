using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipeback.Models;

public partial class Recipe
{
    [Column("id")]
    public int Id { get; set; }
    [Column("title")]
    public string? Title { get; set; }
    [Column("directions")]
    public string? Directions { get; set; }
    [Column("cook_time")]
    public string? CookTime { get; set; }


}
