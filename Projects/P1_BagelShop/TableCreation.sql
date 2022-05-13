CREATE TABLE BagelShop.Stores(
StoreID int IDENTITY(5, 5) Primary Key,
StoreName nvarchar(40) not null,
StoreLocation nvarchar(60) not null
);

CREATE TABLE BagelShop.Inventory(
StoreID int not null FOREIGN KEY REFERENCES BagelShop.Stores(StoreID),
ProductID int not null FOREIGN KEY REFERENCES BagelShop.Stores(ProductID),
Quantity SMALLINT null Default 0
);

CREATE TABLE BagelShop.Products(
ProductID int IDENTITY(1, 1) Primary Key,
ProductName nvarchar(40) not null,
ProductDescription nvarchar(100) null,
ProductPrice SMALLMONEY not null
);

CREATE TABLE BagelShop.Customers(
CustomerID int IDENTITY(5, 5) Primary Key,
CustomerName nvarchar(40) not null,
CustomerUsername nvarchar(40) not null,
CustomerPassword nvarchar(40) not null
);


CREATE TABLE _MembersParentJunction(
JunctionId int IDENTITY(10, 5) Primary Key,
ChildMemberId int not null FOREIGN KEY REFERENCES _Members(MemberIdId),
ParentMemberId int not null FOREIGN KEY REFERENCES _Members(MemberIdId),
DateCreated DATETIME2 not null DEFAULT(GETDATE())
);



