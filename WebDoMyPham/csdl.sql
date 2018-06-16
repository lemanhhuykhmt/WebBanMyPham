use master
go

create database WebMyPham
go

use WebMyPham

go

create table Product
(
	ProductID int identity(1,1),
	ProductName nvarchar(100),
	CategoryID int,
	[Image] varchar(500),
	Price decimal(18,2),
	Measure nvarchar(20),
	[Description] nvarchar(500),
	Content nvarchar(MAX),
	Quantity int default 0,
	[Status] bit not null default 1,
	ShowHome bit not null default 0,
	Primary Key (ProductID)
)
go
create table ProductCategory
(
	CategoryID int identity(1,1),
	CategoryName nvarchar(100),
	ParentID int,
	
	Primary Key (CategoryID)
)
go
create table Bill
(
	BillID int identity(1,1),
	CustomerID int,
	CreatedDate datetime default getdate(),
	Total decimal(18,2),

	Primary Key (BillID)
)
go
create table DetailBill
(
	BillID int,
	ProductID int,
	Quantity int,
	UnitPrice decimal(18,2),

	Primary Key (BillID, ProductID)
)
go
create table Customer
(
	CustomerID int identity(1,1),
	CustomerName nvarchar(100),
	Email nvarchar(50),
	[Address] nvarchar(200),
	UserName varchar(30),
	[Password] varchar(30),
	Primary Key(CustomerID)
)
go
create table Account
(
	AccountID int identity(1,1),
	Username varchar(30),
	[Password] varchar(30),
	Primary Key(AccountID)
)



go

alter table Product add constraint FK_Product_ProductCategory foreign key (CategoryID) references ProductCategory(CategoryID)

alter table ProductCategory  add constraint FK_ProductCategory_ProductCategory foreign key (ParentID) references ProductCategory (CategoryID)


alter table Bill add constraint FK_Bill_Customer foreign key (CustomerID) references Customer(CustomerID)


alter table DetailBill add constraint FK_DetailBill_Bill foreign key (BillID) references Bill(BillID)

alter table DetailBill add constraint FK_DetailBill_Product foreign key (ProductID) references Product(ProductID)





