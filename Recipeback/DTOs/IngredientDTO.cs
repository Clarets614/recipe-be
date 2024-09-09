namespace Recipeback.DTOs
{
    public class IngredientDTO
    {
        public int Id { get; set; }
        public string Recipe {  get; set; }

        public string? Itemname { get; set; }

        public float? Qty { get; set; }

        public string? Units { get; set; }
    }
}
