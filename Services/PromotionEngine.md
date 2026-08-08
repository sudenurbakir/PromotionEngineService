### Kampanya Motoru (PromotionEngine)

`PromotionEngine`, sepete uygulanabilecek kampanyaları belirler ve indirim sonrası ödenecek tutarı hesaplar.

* **Minimum Sepet Tutarı:** Şartı karşılamayan kampanyalar uygulanmaz.
* **Priority:** Uygun kampanyalar öncelik sırasına göre değerlendirilir.
* **IsStackable:** Bir kampanya başka kampanyalarla birleştirilemiyorsa sonraki kampanyalar uygulanmaz.
* **Percentage:** İndirim, sepet tutarı üzerinden yüzde olarak hesaplanır.
* **FixedAmount:** Belirlenen sabit tutar indirim olarak uygulanır.
* **AppliedPromotions:** Uygulanan kampanyaların isimleri kaydedilir.
* **FinalTotal:** Orijinal sepet tutarından toplam indirim çıkarılarak hesaplanır.

**Özet:** Kampanya motoru, uygun kampanyaları ve iş kurallarını kontrol ederek **toplam indirimi ve müşterinin ödeyeceği son tutarı** belirler.
