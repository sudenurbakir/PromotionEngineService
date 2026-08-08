# Promotion Engine - Jira User Stories & Acceptance Criteria

Bu doküman, **PromotionEngineService** projesine ait iş gereksinimlerinin Jira Agile / Scrum standartlarına uygun User Story ve Kabul Kriteri (Acceptance Criteria) tanımlarını içerir.

---

## Epic: PROMO-100 | Kampanya ve İndirim Motoru Yönetimi

---

### User Story 1: Kampanya Çakışma ve Önceliklendirme Mantığı
* **Jira Key:** PROMO-101
* **Summary:** Kampanya Çakışma (Stacking) ve Öncelik Sıralama (Priority) Kurallarının Çalıştırılması

#### Description
**As a** E-ticaret Pazarlama Yöneticisi,  
**I want to** Aynı sepete tanımlanan birden fazla kampanyanın öncelik sırasına göre ve çakışma kurallarına (`IsStackable`) uygun şekilde hesaplanmasını,  
**So that** Şirket marj kaybı yaşamadan doğru indirim kombinasyonlarını müşteriye sunabilsin.

#### Acceptance Criteria (Kabul Kriterleri)
* **AC1 (Öncelik Sıralaması):** Birden fazla aktif kampanya sepete uygulandığında, motor indirimleri `Priority` değerine göre küçükten büyüğe (1 = En yüksek öncelik) doğru sırayla hesaplamalıdır.
* **AC2 (Birleştirilemeyen Kampanya):** Sıradaki kampanyanın `IsStackable = false` olması durumunda, bu kampanya sepete uygulanır ve sonrasındaki daha düşük öncelikli kampanyaların uygulanması engellenir.
* **AC3 (Birleştirilebilir Kampanya):** `IsStackable = true` olan kampanyalar uygulandıktan sonra, sonraki kampanyaların değerlendirilmesine devam edilir.
* **AC4 (Minimum Sepet Tutarı Kontrolü):** Sepet toplamı `MinBasketAmount` değerinin altında kalan kampanyalar değerlendirmeye alınmadan doğrudan elenmelidir.

---

### User Story 2: Kategori Bazlı Dinamik İndirim Tanımlama
* **Jira Key:** PROMO-102
* **Summary:** Belirli Kategoriye Özel Yüzdesel ve Sabit İndirim Hesabı

#### Description
**As a** Kampanya İş Analisti,  
**I want to** Yalnızca hedeflenen kategorideki (`TargetCategoryId`) ürünlerin tutarına özel indirim uygulayabilmeyi,  
**So that** Tüm sepete indirim uygulamak yerine hedef odaklı kategori kampanyaları yapabilelim.

#### Acceptance Criteria (Kabul Kriterleri)
* **AC1 (Kapsam Kontrolü):** İndirim yalnızca `CartItem.CategoryId == TargetCategoryId` eşleşmesi sağlayan kalemlerin tutar toplamı üzerinden hesaplanmalıdır. Eşleşmeyen ürünler hesaplamaya dahil edilmemelidir.
* **AC2 (Çıktı Detayı):** Uygulanan kategori indirimi `DiscountResult.AppliedPromotions` listesine kampanya adı ve düşülen tutar bilgisiyle kaydedilmelidir.

---

### User Story 3: Kullanıcı ve Toplam Kupon Kullanım Limitleri
* **Jira Key:** PROMO-103
* **Summary:** Veritabanı Seviyesinde Kupon Kullanım Sınırı ve Geçmiş Kaydı

#### Description
**As a** Sistem Güvenlik Analisti,  
**I want to** Kullanıcı bazlı ve toplam kupon kullanım limitlerinin `PromotionUsages` tablosu üzerinden denetlenmesini,  
**So that** Kupon suistimalini (abuse) ve bütçe aşımını engelleyebilelim.

#### Acceptance Criteria (Kabul Kriterleri)
* **AC1 (Müşteri Limiti Kontrolü):** Müşteri `MaxUsagePerUser` sınırına ulaştıysa kupon uygulanamaz ve `"Bu kupon için kullanım limitinizi doldurdunuz"` hatası dönmelidir.
* **AC2 (Genel Kullanım Limiti):** Kuponun toplam kullanım sayısı (`MaxTotalUsage`) dolduğunda kupon otomatik olarak pasif duruma geçmelidir.
* **AC3 (Kullanım Kaydı):** Başarılı sipariş oluşturma anında `PromotionUsages` tablosuna `UserId`, `PromotionId` ve `DiscountApplied` değerleri yazılmalıdır.
