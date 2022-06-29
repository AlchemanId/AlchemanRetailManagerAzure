CREATE TABLE [dbo].[Inventory]
(
	[Id] INT NOT NULL PRIMARY KEY identity,
	[ProductId] int not null,
	[Quantity] int not null default 1,
	[PurchasePrice] money not null,
	[PurchaseDate] datetime2 not null default getutcdate(), 
    CONSTRAINT [FK_Inventory_ToProduct] FOREIGN KEY (ProductId) REFERENCES [Product]([Id])
)
