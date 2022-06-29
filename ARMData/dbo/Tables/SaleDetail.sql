CREATE TABLE [dbo].[SaleDetail]
(
	[Id] INT NOT NULL PRIMARY KEY identity,
	[SaleId] int not null,
	[ProductId] int not null,
	[Quantity] int not null default 1,
	[PurchasePrice] money not null,
	[Tax] money not null default 0, 
    CONSTRAINT [FK_SaleDetail_ToSale] FOREIGN KEY (SaleId) REFERENCES Sale(Id), 
    CONSTRAINT [FK_SaleDetail_ToProduct] FOREIGN KEY (ProductId) REFERENCES Product(Id)
)
