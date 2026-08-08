Feature: Kampanya Birleştirme ve Çakışma Kuralları
  Müşteri sepetine birden fazla kampanya uyduğunda,
  kampanya birleşme (IsStackable) ve öncelik (Priority) kurallarına göre doğru indirimin hesaplanması.

  Scenario: Birleştirilemeyen Kampanya Başka İndirimle Kullanılamaz
    Given Sepet tutarı 500.00 TL'dir
    And "Sepette 100 TL İndirim" kampanyası öncelik 1 ve birleştirilemez (IsStackable = false) olarak tanımlıdır
    And "%10 Hoşgeldin İndirimi" kampanyası öncelik 2 ve birleştirilebilir olarak tanımlıdır
    When İndirim motoru çalıştırıldığında
    Then Sadece "Sepette 100 TL İndirim" uygulanmalıdır
    And Toplam indirim 100.00 TL olmalıdır
    And Ödenecek tutar 400.00 TL olmalıdır

  Scenario: Birleştirilebilir Kampanyalar Üst Üste Biner
    Given Sepet tutarı 1000.00 TL'dir
    And "50 TL Kargo İndirimi" kampanyası öncelik 1 ve birleştirilebilir olarak tanımlıdır
    And "%10 Bahar İndirimi" kampanyası öncelik 2 ve birleştirilebilir olarak tanımlıdır
    When İndirim motoru çalıştırıldığında
    Then Her iki kampanya da sepete uygulanmalıdır
    And Toplam indirim 150.00 TL olmalıdır
