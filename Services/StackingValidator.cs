using PromotionEngineService.Models;

namespace PromotionEngineService.Services
{
    public class StackingValidator
    {
        /// 
        /// Yeni bir kampanyanın mevcut uygulanmış kampanyalarla birleşip birleşemeyeceğini kontrol eder.
        /// 
        public bool CanStack(PromotionRule newPromo, List alreadyAppliedPromos)
        {
            // 1. Zaten uygulanmış kampanyalardan biri bile "birleştirilemez" ise yenisi eklenemez
            if (alreadyAppliedPromos.Any(p => !p.IsStackable))
                return false;

            // 2. Eklenmek istenen yeni kampanya birleştirilemez ise ve listede zaten kampanya varsa eklenemez
            if (!newPromo.IsStackable && alreadyAppliedPromos.Any())
                return false;

            return true;
        }
    }
}
