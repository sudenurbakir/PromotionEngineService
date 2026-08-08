# Kampanya Çakışma ve Önceliklendirme Karar Matrisi (Decision Matrix)

Bu doküman, birden fazla kampanyanın aynı sepete tanımlandığı durumlarda sistemin nasıl karar vereceğini gösteren mantıksal matristir.

---

## 📊 Karar Tablosu

| Aktif Kampanya 1 | Aktif Kampanya 2 | Öncelik Sırası (Priority) | Çakışma İzni (IsStackable) | Sistem Davranışı / Sonuç |
| :--- | :--- | :--- | :--- | :--- |
| **Kupon A:** %20 Sepet İndirimi | **Kupon B:** 50 TL Hoşgeldin İndirimi | Kupon A (P1)  Kupon B (P2) | Kupon A: `false`  Kupon B: `true` | **Yalnızca Kupon A uygulanır.** P1 öncelikli kampanya birleştirilemez olduğu için P2 elenir. |
| **Kupon C:** 30 TL Kargo İndirimi | **Kupon D:** %10 Bahar Fırsatı | Kupon C (P1)  Kupon D (P2) | Kupon C: `true`  Kupon D: `true` | **Her iki indirim de uygulanır.** Her ikisi de `IsStackable = true` olduğu için üst üste biner. |
| **Kupon E:** Kategori Bazlı %15 | **Kupon F:** Genel Sepet %10 | Kupon E (P1)  Kupon F (P2) | Kupon E: `true`  Kupon F: `false` | **Her iki indirim de uygulanır.** P1 önce uygulanır; `IsStackable = false` olan P2 en son uygulanarak çakışma zincirini kapatır. |

---

## ⚙️ Hesaplama Mantığı & Sıralama (Order of Execution)

1. **Filtreleme:** Sepet tutarı `MinBasketAmount` şartını sağlamayan kampanyalar elenir.
2. **Öncelik Sıralaması:** Kalan kampanyalar `Priority` değerine göre küçükten büyüğe (1 en yüksek öncelik) sıralanır.
3. **Çakışma Kontrolü:** İndirimler sırayla uygulanır. `IsStackable = false` olan bir kampanyaya denk gelindiğinde indirim hesaplanır ve döngü sonlandırılır.
