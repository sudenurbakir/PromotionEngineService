using PromotionEngineService.Models;

namespace PromotionEngineService.Services
{
    public class PromotionEngine
    {
        /// 
        /// Sepete uygulanabilecek en avantajlı ve kurallara uygun indirimleri hesaplar.
        /// 
        public DiscountResult ApplyPromotions(decimal cartTotal, List activePromotions)
        {
            var result = new DiscountResult { OriginalTotal = cartTotal };

            // 1. İş Kuralı: Min Sepet Tutanını Karşılayan ve Önceliğe (Priority) Göre Sıralanan Kampanyalar
            var eligiblePromotions = activePromotions
                .Where(p => cartTotal >= p.MinBasketAmount)
                .OrderBy(p => p.Priority)
                .ToList();

            decimal currentDiscount = 0;
            bool hasNonStackableApplied = false;

            foreach (var promo in eligiblePromotions)
            {
                // 2. İş Kuralı: Çakışma Kontrolü (Daha önce birleşemeyen kampanya uygulandıysa dur)
                if (hasNonStackableApplied)
                    break;

                decimal calculatedDiscount = 0;

                if (promo.DiscountType == DiscountType.Percentage)
                {
                    calculatedDiscount = (cartTotal * promo.DiscountValue) / 100;
                }
                else if (promo.DiscountType == DiscountType.FixedAmount)
                {
                    calculatedDiscount = promo.DiscountValue;
                }

                currentDiscount += calculatedDiscount;
                result.AppliedPromotions.Add(promo.Name);

                // Eğer bu kampanya "birleştirilemez" (IsStackable = false) ise sonraki kampanyaları engelle
                if (!promo.IsStackable)
                {
                    hasNonStackableApplied = true;
                }
            }

            result.TotalDiscount = currentDiscount;
            result.FinalTotal = cartTotal - currentDiscount;
            return result;
        }
    }

    public class DiscountResult
    {
        public decimal OriginalTotal { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal FinalTotal { get; set; }
        public List AppliedPromotions { get; set; } = new List();
    }
}
