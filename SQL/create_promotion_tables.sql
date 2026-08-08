-- 1. Kampanya Tanımları Tablosu
CREATE TABLE Promotions (
    PromotionId INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(100) NOT NULL,
    DiscountType INT NOT NULL,         -- 1: Percentage, 2: FixedAmount, 3: BuyXGetY
    Scope INT NOT NULL,                -- 1: CartTotal, 2: Category, 3: Product
    DiscountValue DECIMAL(18,2) NOT NULL,
    MinBasketAmount DECIMAL(18,2) DEFAULT 0.00,
    Priority INT NOT NULL DEFAULT 99,
    IsStackable BIT NOT NULL DEFAULT 0,-- 0: Birleşemez, 1: Birleşebilir
    StartDate DATETIME NOT NULL,
    EndDate DATETIME NOT NULL,
    IsActive BIT DEFAULT 1
);

-- 2. Müşteri Kupon Kullanım Geçmişi (Limit Kontrolü İçin)
CREATE TABLE PromotionUsages (
    UsageId INT PRIMARY KEY IDENTITY(1,1),
    PromotionId INT FOREIGN KEY REFERENCES Promotions(PromotionId),
    UserId INT NOT NULL,
    OrderId VARCHAR(50) NOT NULL,
    DiscountApplied DECIMAL(18,2) NOT NULL,
    UsedDate DATETIME DEFAULT GETDATE()
);
