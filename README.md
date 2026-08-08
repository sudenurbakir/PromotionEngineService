# Promotion Engine & İndirim Motoru Servisi

Bu proje, bir e-ticaret platformundaki **Kampanya Yönetimi**, **İndirim Çakışmaları (Stacking Rules)**, **Kampanya Önceliklendirmesi (Priority)**, **Kategori Bazlı İndirimler** ve **Kupon Kullanım Limitlerinin** bir **İş Analisti** gözüyle C#, BDD (Gherkin), SQL, Jira User Story'leri ve Karar Matrisleri kullanılarak kurgulandığı modüler bir indirim motoru mimarisidir.

---

## İş Analizi & Kampanya Yönetim Kuralları

### 1. Dinamik İndirim Tipleri

**Dosya:** `Models/PromotionRule.cs`

Kampanya sisteminde farklı indirim türleri desteklenmektedir:

* **Percentage (%):** Sepet veya hedeflenen kategori toplamı üzerinden yüzdesel indirim uygulanır.
* **FixedAmount (TL):** Belirlenen sabit tutar kadar indirim uygulanır.
* **BuyXGetY:** Belirli miktarda ürün alımına bağlı olarak ücretsiz veya indirimli ürün sunulur.

---

### 2. Kampanya Çakışma ve Birleştirilebilirlik

**Dosya:** `Services/StackingValidator.cs`

Kampanyaların birlikte kullanılıp kullanılamayacağını kontrol etmek için `IsStackable` parametresi kullanılır.

* `IsStackable = true` → Kampanya diğer uygun kampanyalarla birlikte kullanılabilir.
* `IsStackable = false` → Kampanya diğer kampanyalarla birlikte kullanılamaz.
* Birleştirilemeyen bir kampanya uygulandığında, daha düşük öncelikli kampanyaların uygulanması engellenir.

---

### 3. Kategori Bazlı İndirimler

**Dosya:** `Tests/CategoryDiscount.feature`

Kampanyanın tüm sepete değil, yalnızca belirlenen kategoriye ait ürünlere uygulanması sağlanır.

`TargetCategoryId` kullanılarak kampanyanın geçerli olduğu kategori belirlenir.

**Örnek:**

```text
Sepet:
- Tişört       → 500 TL
- Ayakkabı     → 1.000 TL
- Çanta        → 750 TL

Hedef Kategori: Ayakkabı
İndirim: %20

İndirim yalnızca 1.000 TL'lik ayakkabı tutarı üzerinden hesaplanır.
```

---

### 4. Kampanya Kullanım Limitleri ve Veri Yönetimi

**Dosya:** `SQL/create_promotion_tables.sql`

`PromotionUsages` tablosu, kampanyaların hangi müşteri tarafından ve hangi siparişte kullanıldığını kayıt altına alır.

Bu yapı sayesinde:

* Müşteri bazlı kampanya kullanım geçmişi tutulabilir.
* Aynı kampanyanın tekrar kullanım durumu kontrol edilebilir.
* Uygulanan indirim tutarı kayıt altına alınabilir.
* Kampanya kullanım raporları oluşturulabilir.

---

## Gereksinimler ve Jira Dokümantasyonu

Projede tanımlanan **kabul kriterleri, iş kuralları, gereksinimler ve Agile/Jira çalışmaları** aşağıdaki dosyalarda detaylandırılmıştır:

* `Docs/user_stories.md` → User Story ve kabul kriterleri
* `Docs/promotion_decision_matrix.md` → Kampanya karar matrisi

Bu dokümanlar, kampanya motorunun teknik geliştirme öncesindeki **iş gereksinimlerini ve karar kurallarını** tanımlamak amacıyla kullanılmıştır.

## Proje Klasör Mimarisi (Project Architecture)

```text
PromotionEngineService/
├── Models/                         # Kampanya & Sepet Veri Modelleri
│   ├── PromotionRule.cs            # Kampanya tipleri (Yüzde, Sabit, BuyXGetY) ve kuralları
│   ├── Cart.cs                     # Sepet ve Sepet Kalemleri DTO
│   └── DiscountResult.cs           # Hesaplanan toplam indirim ve uygulanan kampanyalar
├── Services/                       # İndirim Hesaplama Motoru
│   ├── PromotionEngine.cs          # Öncelik sıralama ve hesaplama mantığı
│   └── StackingValidator.cs        # Kampanya birleşebilirlik (IsStackable) kontrolü
├── Tests/                          # BDD Kabul Kriterleri (Gherkin)
│   ├── CampaignStacking.feature    # Kampanya birleştirme kabul kriterleri
│   └── CategoryDiscount.feature    # Kategori bazlı indirim senaryoları
├── SQL/                            # Veritabanı & Raporlama Sorguları
│   ├── create_promotion_tables.sql # Kampanyalar ve kullanım geçmişi tabloları
│   └── campaign_performance.sql    # En çok kazandıran kampanya performans analizi
└── Docs/                           # İş Analizi & Dokümantasyon
    ├── promotion_decision_matrix.md# Kampanya çakışma karar matrisi
    └── user_stories.md             # Jira User Story ve Kabul Kriterleri (AC)
