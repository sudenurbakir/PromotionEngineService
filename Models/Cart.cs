namespace PromotionEngineService.Models
{
    public class CartItem
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal LineTotal => UnitPrice * Quantity;
    }

    public class Cart
    {
        public int CartId { get; set; }
        public int UserId { get; set; }
        public List Items { get; set; } = new List();
        public decimal TotalAmount => Items.Sum(x => x.LineTotal);
    }
}
