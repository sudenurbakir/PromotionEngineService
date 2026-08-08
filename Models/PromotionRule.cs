namespace PromotionEngineService.Models
{
    public enum DiscountType
    {
        Percentage = 1,   // Yüzdesel İndirim (%20 vb.)
        FixedAmount = 2,  // Sabit Tutar İndirimi (50 TL vb.)
        BuyXGetY = 3      // 3 Al 2 Öde vb.
    }

    public enum PromotionScope
    {
        CartTotal = 1,    // Tüm Sepet
        Category = 2,     // Belirli Kategori
        Product = 3       // Belirli Ürün
    }

    public class PromotionRule
    {
        public int PromotionId { get; set; }
        public string Name { get; set; }                  // Örn: "Bahar İndirimi"
        public DiscountType DiscountType { get; set; }
        public PromotionScope Scope { get; set; }
        public decimal DiscountValue { get; set; }       // 20 (%20) veya 50 (50 TL)
        public decimal MinBasketAmount { get; set; }     // Min Sepet Tutarı (Örn: 200 TL)
        public int Priority { get; set; }                 // Kampanya Önceliği (1: En yüksek)
        public bool IsStackable { get; set; }             // Başka kampanyayla birleşebilir mi?
        public int? TargetCategoryId { get; set; }       // Eğer Kategori bazlıysa Kategori ID
    }
}
