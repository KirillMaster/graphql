CREATE TABLE CatalogProduct (
    SKU VARCHAR(50)  NOT NULL,
    ShortId INT NOT NULL,
    DataJson JSONB NOT NULL,
    CurrencyCode VARCHAR(10)  NOT NULL,
    CreatedAt TIMESTAMPTZ NOT NULL,
    CatalogVersionId BIGINT  NOT NULL,
    FriendlyUrl VARCHAR(850),
	PRIMARY KEY (SKU, CurrencyCode, CatalogVersionId)
);

CREATE INDEX idx_FriendlyUrl ON CatalogProduct (FriendlyUrl);
CREATE INDEX idx_ShortId ON CatalogProduct (ShortId);