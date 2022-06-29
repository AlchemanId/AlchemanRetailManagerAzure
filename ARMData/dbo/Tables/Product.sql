CREATE TABLE [dbo].[Product]
(
	[Id] INT NOT NULL PRIMARY KEY identity,
	[ProductName] nvarchar(100) not null,
	[Description] nvarchar(max) null,
	[RetailPrice] money not null,
	[QuantityInStock] int not null default 1,
	[CreateDate] datetime2 not null default getutcdate(),
	[LastModified] datetime2 not null default getutcdate(),
	[IsTaxable] bit not null DEFAULT 1

)
