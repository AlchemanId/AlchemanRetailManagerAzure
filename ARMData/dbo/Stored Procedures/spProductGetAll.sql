CREATE PROCEDURE [dbo].[spProductGetAll]
as
begin
	set nocount on;

	select Id, ProductName, [Description], RetailPrice, QuantityInStock, IsTaxAble
	from dbo.Product
	order by ProductName;
end
