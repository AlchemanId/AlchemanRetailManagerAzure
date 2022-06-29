CREATE TABLE [dbo].[Sale]
(
	[Id] INT NOT NULL PRIMARY KEY identity,
	[CashierId] nvarchar(128) not null,
	[SaleDate] datetime2 null,
	[SubTotal] money not null,
	[Tax] money not null,
	[Total] money not null, 
    CONSTRAINT [FK_Sale_ToUser] FOREIGN KEY (CashierId) REFERENCES [User]([Id])
)
