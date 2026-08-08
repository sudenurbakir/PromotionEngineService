Feature: Kategori Bazlı Kampanya Hesabı
  Belirli bir kategoriye ait ürünlerin toplamına uygulanan
  indirim kurallarının test edilmesi.

  Scenario: Sadece Elektronik Kategorisindeki Ürünlere %20 İndirim
    Given Sepette 1500.00 TL tutarında "Elektronik" kategorisinden ürün bulunmaktadır
    And Sepette 500.00 TL tutarında "Giyim" kategorisinden ürün bulunmaktadır
    And "Elektronik %20" kampanyası aktif durumdadır
    When İndirim motoru çalıştırıldığında
    Then Sadece Elektronik kategorisine 300.00 TL indirim uygulanmalıdır
    And Toplam sepet tutarı 1700.00 TL olmalıdır
