namespace PromotionEngineService.Models
{
    public class DiscountResult
    {
        public decimal OriginalTotal { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal FinalTotal { get; set; }
        public List AppliedPromotions { get; set; } = new List();
    }
}
