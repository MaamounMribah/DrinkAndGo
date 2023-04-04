namespace DrinkAndGo.Models
{
    public class Drink
    {
        public int DrinkId { get; set; }
        public string Name { get; set; } = null!;
        public string ShortDescription { get; set; } = null!;
        public string LongDescription { get; set; } = null!;
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = null!;
        public string ImageThumbnailUrl { get; set; } = null!;
        public bool IsPreferredDrink { get; set; }
        public bool InStock { get; set; }
        public int CategoryId { get; set; } 
        public virtual Category Category { get; set; } = null!;
    }
}
