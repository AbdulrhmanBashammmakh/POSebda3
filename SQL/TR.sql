

-- trigger of inventory affected by products table inserted 
CREATE TRIGGER [dbo].[upd_inventory]
   ON  [dbo].[Products]
  AFTER insert   
AS 
BEGIN
Declare @Id int ,@m varchar(50) ,@n varchar(50) 
  SELECT @Id = id,@m=Name,@n=code from inserted  

  INSERT INTO Inventories  
  VALUES(@Id, CONCAT(@m,'-', @Id, '-',@n),0,0,0,@Id)
   

END


-- BillItems
-- InvoiceItems



-- BillItems
-- InvoiceItems

--------------------------------------

-- Qty_purchase_inserted => AvaQuantity =AvaQuantity+@Qtys

CREATE TRIGGER [dbo].[Qty_purchase_inserted]
   ON  [dbo].[BillItems]
FOR INSERT  
AS 
BEGIN

declare @ids int , @Qtys int ,@price float
select @ids=ProductId ,@Qtys=Quantity ,@price=rate from inserted

update  Inventories set AvaQuantity = AvaQuantity + @Qtys,CostPrice= @price ,SellingPrice= @price*1.15
where ItemId=@ids;

END
go
------------------------
-- Qty_purchase_deleted => AvaQuantity =AvaQuantity-@Qtys
CREATE  TRIGGER [dbo].[Qty_purchase_deleted]
   ON  [dbo].[BillItems]
FOR DELETE  
AS 
BEGIN

declare @ids int , @Qtys int 
select @ids=ProductId ,@Qtys=Quantity from deleted

update  Inventories set AvaQuantity =AvaQuantity-@Qtys
where ItemId=@ids;

END

---------------------------------
go
-- Qty_sales_inserted => AvaQuantity =AvaQuantity-@Qtys

CREATE TRIGGER [dbo].[Qty_sales_inserted]
   ON  [dbo].[InvoiceItems]
FOR INSERT  
AS 
BEGIN

declare @ids int , @Qtys int 
select @ids=ProductId ,@Qtys=Quantity from inserted

update  Inventories set AvaQuantity =AvaQuantity-@Qtys
where ItemId=@ids;

END
go
---------------------------------
-- Qty_sales_deleted => AvaQuantity =AvaQuantity+@Qtys

CREATE TRIGGER [dbo].[Qty_sales_deleted]
   ON  [dbo].[InvoiceItems]
FOR DELETE  
AS 
BEGIN

declare @ids int , @Qtys int 
select @ids=ProductId ,@Qtys=Quantity from deleted

update  Inventories set AvaQuantity =AvaQuantity+@Qtys
where ItemId=@ids;

END

go
----------------------------------------


create TRIGGER [dbo].[Qty_sales_deleted_order]
   ON  [dbo].lineorders
FOR delete 
AS 
BEGIN

declare @ids int , @Qtys int 

   BEGIN
    select @ids=ProductId ,@Qtys=Quantity from deleted
update  Inventories set AvaQuantity =AvaQuantity + @Qtys where ItemId=@ids;

END
 end
 
go 
 -------------------
 
create TRIGGER [dbo].[Qty_sales_inserted_order]
   ON  [dbo].[LineOrders]
FOR INSERT 
AS 
BEGIN

declare @ids int , @Qtys int 
 select @ids=ProductId ,@Qtys=Quantity from inserted
update  Inventories set AvaQuantity =AvaQuantity-@Qtys
where ItemId=@ids;


END







