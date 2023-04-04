namespace DrinkAndGo.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        public Drink Drink { get; set; } = null!;
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; } = null!;
    }
}
