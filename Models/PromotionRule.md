### Kampanya ve İndirim Kuralları

`PromotionRule`, kampanyanın nasıl çalışacağını ve hangi koşullarda uygulanacağını tanımlar.

* **DiscountType:** İndirim türünü belirler.

  * `Percentage` → Yüzdesel indirim
  * `FixedAmount` → Sabit tutar indirimi
  * `BuyXGetY` → Örneğin 3 Al 2 Öde

* **PromotionScope:** Kampanyanın uygulanacağı alanı belirler.

  * `CartTotal` → Tüm sepet
  * `Category` → Belirli kategori
  * `Product` → Belirli ürün

* **DiscountValue:** İndirim değerini belirtir.

* **MinBasketAmount:** Kampanyanın uygulanması için gereken minimum sepet tutarıdır.

* **Priority:** Birden fazla kampanya olduğunda uygulanma önceliğini belirler.

* **IsStackable:** Kampanyanın başka kampanyalarla birleştirilip birleştirilemeyeceğini belirtir.

* **TargetCategoryId:** Kategori bazlı kampanyalarda hedef kategoriyi belirtir.

**Özet:** Bu yapı, kampanyanın **indirim türünü, kapsamını, tutarını, minimum sepet koşulunu ve diğer kampanyalarla ilişkisini** tanımlayan iş kurallarını içerir.
