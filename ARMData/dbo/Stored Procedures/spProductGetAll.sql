CREATE PROCEDURE [dbo].[spProductGetAll]
as
begin
	set nocount on;

	select Id, ProductName, [Description], RetailPrice, QuantityInStock, CreateDate, LastModified
	from dbo.Product
	order by ProductName;
end
