CREATE PROCEDURE [dbo].[spProductGetById]
	@Id int
as
begin
	set nocount on;

	select Id, ProductName, [Description], RetailPrice, QuantityInStock, IsTaxAble
	from dbo.Product
	where Id = @Id
end
