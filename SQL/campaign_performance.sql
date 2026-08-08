-- 1. En Çok Ciro Ve İndirim Kazandıran Kampanyaların Analizi
SELECT 
    p.PromotionId,
    p.Name AS KampanyaAdi,
    COUNT(pu.UsageId) AS ToplamKullanimSayisi,
    SUM(pu.DiscountApplied) AS ToplamVerilenIndirimTL
FROM Promotions p
LEFT JOIN PromotionUsages pu ON p.PromotionId = pu.PromotionId
GROUP BY p.PromotionId, p.Name
ORDER BY ToplamVerilenIndirimTL DESC;

-- 2. Kategori Bazlı Kampanya Verimliliği Raporu
SELECT 
    p.TargetCategoryId,
    COUNT(pu.UsageId) AS KullanimAdedi,
    AVG(pu.DiscountApplied) AS OrtalamaIndirimTutari
FROM Promotions p
INNER JOIN PromotionUsages pu ON p.PromotionId = pu.PromotionId
WHERE p.Scope = 2 -- Category Scope
GROUP BY p.TargetCategoryId;
