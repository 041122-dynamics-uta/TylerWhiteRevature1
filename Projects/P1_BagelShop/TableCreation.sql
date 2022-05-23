CREATE SCHEMA BagelShop;
GO

CREATE TABLE BagelShop.Stores(
StoreID int IDENTITY(5, 5) Primary Key,
StoreName nvarchar(40) not null,
StoreLocation nvarchar(80) not null
);

CREATE TABLE BagelShop.Products(
ProductID int IDENTITY(1, 1) Primary Key,
ProductName nvarchar(60) not null,
ProductDescription nvarchar(400) null,
ProductPrice SMALLMONEY not null
);

CREATE TABLE BagelShop.Customers(
CustomerID int IDENTITY(1, 1) Primary Key,
CustomerFName nvarchar(30) not null,
CustomerLName nvarchar(30) not null,
CustomerUsername nvarchar(40) not null,
CustomerPassword nvarchar(40) not null
);

CREATE TABLE BagelShop.Inventory(
InventoryID int IDENTITY(1, 1) Primary Key,
StoreID int not null FOREIGN KEY REFERENCES BagelShop.Stores(StoreID),
ProductID int not null FOREIGN KEY REFERENCES BagelShop.Products(ProductID),
InventoryQuantity SMALLINT not null Default 0
);


CREATE TABLE BagelShop.ProductOrders(
ProductOrderID int IDENTITY(1,1) Primary Key,
OrderID  int not null FOREIGN KEY REFERENCES BagelShop.Order(OrderID),
ProductID int not null FOREIGN KEY REFERENCES BagelShop.Products(ProductID),
ProductQuantity SMALLINT not null Default 0
)


/* CREATE TABLE BagelShop.Orders(
OrderID int IDENTITY(100, 1) Primary Key,
StoreID int not null FOREIGN KEY REFERENCES BagelShop.Stores(StoreID),
CustomerID int not null FOREIGN KEY REFERENCES BagelShop.Customers(CustomerID),
ProductTotalCost SMALLMONEY not null,
DateCreated DATETIME2 not null DEFAULT(GETDATE())
); */

CREATE TABLE BagelShop.Orders(
LineItemID int IDENTITY(1,1) Primary Key,
OrderID UNIQUEIDENTIFIER not null,
StoreID int not null FOREIGN KEY REFERENCES BagelShop.Stores(StoreID),
ProductID int not null FOREIGN KEY REFERENCES BagelShop.Products(ProductID),
CustomerID int not null FOREIGN KEY REFERENCES BagelShop.Customers(CustomerID),
ProductQuantity int not null DEFAULT(1),
ProductTotalCost decimal(9,2) not null,
DateCreated DATETIME2 not null DEFAULT(GETDATE())
);


INSERT INTO BagelShop.Stores (StoreName, StoreLocation) VALUES('Big Boi Bagel Shop', '5749 N Artesian Ave, Chicago, IL 60625');
INSERT INTO BagelShop.Stores (StoreName, StoreLocation) VALUES('Big Boii Bagel Shop', '14234 Dzuibanek Rd, Thompsonville, MI 49683');
INSERT INTO BagelShop.Stores (StoreName, StoreLocation) VALUES('Bigger Boi Bagel Shop', '133 W Front St, Wheaton, IL 60187');
INSERT INTO BagelShop.Stores (StoreName, StoreLocation) VALUES('Biggest Boi Bagel Shop', '740 N Collier Blvd #105, Marco Island, FL 34145');

INSERT INTO BagelShop.Products (ProductName, ProductDescription, ProductPrice) VALUES('Plain Bagel', 'Boring.', .49);
INSERT INTO BagelShop.Products (ProductName, ProductDescription, ProductPrice) VALUES('Blueberry Bagel', 'Little tiny blue balls in your bagel', .99);
INSERT INTO BagelShop.Products (ProductName, ProductDescription, ProductPrice) VALUES('Choco-tato Chip Bagel', 'Chocolate chips, potato chips, all are welcome', .99);
INSERT INTO BagelShop.Products (ProductName, ProductDescription, ProductPrice) VALUES('Cinnamon Raisin Bagel', '*HOTT SELLER* Perfect for the Raisin King!', .99);
INSERT INTO BagelShop.Products (ProductName, ProductDescription, ProductPrice) VALUES('Triple Chocolate Bagel', 'Diabeetus!', 1.49);
INSERT INTO BagelShop.Products (ProductName, ProductDescription, ProductPrice) VALUES('Everything Bagel', 'Spice up your life with this special blend made from all the leftover spices stuck at the bottom of our spice jars.', 1.49);
INSERT INTO BagelShop.Products (ProductName, ProductDescription, ProductPrice) VALUES('Cranberry Walnut Bagel', 'Pairs well with our Thanksgiving Gravy Cream Cheese.', 1.49);
INSERT INTO BagelShop.Products (ProductName, ProductDescription, ProductPrice) VALUES('Mango Habañero Bagel', 'A pleasant sweetness followed by a growing level of heat that you can only stop by eating more ;)', 3.49);
INSERT INTO BagelShop.Products (ProductName, ProductDescription, ProductPrice) VALUES('The Reaper From Carolina', 'This is a healthy, green-energy method for purging all your tastebuds so you can grow new, fresh ones in a couple weeks.', 3.49);
INSERT INTO BagelShop.Products (ProductName, ProductDescription, ProductPrice) VALUES('Roast Beef Bagel', 'Yes, this is a bagel.', 3.49);
INSERT INTO BagelShop.Products (ProductName, ProductDescription, ProductPrice) VALUES('Garlic Pesto Bagel', 'Your coworkers will love sitting next to you.', 3.49);
INSERT INTO BagelShop.Products (ProductName, ProductDescription, ProductPrice) VALUES('The Big Boi Bagel', '*HOTT SELLER* All the other bagel ingredients combined and 2X the size. Get your Big Boi pants ready.', 5.49);
INSERT INTO BagelShop.Products (ProductName, ProductDescription, ProductPrice) VALUES('Plain Cream Cheese', 'Perfect for trying our more flavorful bagels, 4oz', 2.99);
INSERT INTO BagelShop.Products (ProductName, ProductDescription, ProductPrice) VALUES('Cinnamon Swirl Cream Cheese', 'Yummy, 4oz', 4.99);
INSERT INTO BagelShop.Products (ProductName, ProductDescription, ProductPrice) VALUES('Horseradish Cream Cheese', 'Try it with the Everything Bagel, 4oz', 5.99);
INSERT INTO BagelShop.Products (ProductName, ProductDescription, ProductPrice) VALUES('Thanksgiving Gravy Cream Cheese', '*HOTT SELLER* Sometimes I buy a few tubs and just dig in with a spoon. We even colored it brown to get your gravy vibes flowing! 3oz', 5.99);

INSERT INTO BagelShop.Customers (CustomerFName, CustomerLName, CustomerUsername, CustomerPassword) VALUES('1', '1', 'admin', 'admin');
INSERT INTO BagelShop.Customers (CustomerFName, CustomerLName, CustomerUsername, CustomerPassword) VALUES('Frank', 'McBeef', 'FrankM', 'ExtraBeefy');
INSERT INTO BagelShop.Customers (CustomerFName, CustomerLName, CustomerUsername, CustomerPassword) VALUES('Pippi', 'Longstockings', 'RedHead', 'Freckle');

INSERT INTO BagelShop.Inventory (StoreID, ProductID, InventoryQuantity) VALUES(5, 1, 40);
INSERT INTO BagelShop.Inventory (StoreID, ProductID, InventoryQuantity) VALUES(5, 2, 40);
INSERT INTO BagelShop.Inventory (StoreID, ProductID, InventoryQuantity) VALUES(5, 3, 40);
INSERT INTO BagelShop.Inventory (StoreID, ProductID, InventoryQuantity) VALUES(5, 4, 40);
INSERT INTO BagelShop.Inventory (StoreID, ProductID, InventoryQuantity) VALUES(5, 5, 40);
INSERT INTO BagelShop.Inventory (StoreID, ProductID, InventoryQuantity) VALUES(5, 6, 40);
INSERT INTO BagelShop.Inventory (StoreID, ProductID, InventoryQuantity) VALUES(5, 7, 40);
INSERT INTO BagelShop.Inventory (StoreID, ProductID, InventoryQuantity) VALUES(5, 8, 40);
INSERT INTO BagelShop.Inventory (StoreID, ProductID, InventoryQuantity) VALUES(5, 9, 40);
INSERT INTO BagelShop.Inventory (StoreID, ProductID, InventoryQuantity) VALUES(5, 10, 40);
INSERT INTO BagelShop.Inventory (StoreID, ProductID, InventoryQuantity) VALUES(5, 11, 40);
INSERT INTO BagelShop.Inventory (StoreID, ProductID, InventoryQuantity) VALUES(5, 12, 40);
INSERT INTO BagelShop.Inventory (StoreID, ProductID, InventoryQuantity) VALUES(5, 13, 30);
INSERT INTO BagelShop.Inventory (StoreID, ProductID, InventoryQuantity) VALUES(5, 14, 30);
INSERT INTO BagelShop.Inventory (StoreID, ProductID, InventoryQuantity) VALUES(5, 15, 30);
INSERT INTO BagelShop.Inventory (StoreID, ProductID, InventoryQuantity) VALUES(5, 16, 30);

INSERT INTO BagelShop.Inventory (StoreID, ProductID, InventoryQuantity) VALUES(10, 1, 50);
INSERT INTO BagelShop.Inventory (StoreID, ProductID, InventoryQuantity) VALUES(10, 2, 50);
INSERT INTO BagelShop.Inventory (StoreID, ProductID, InventoryQuantity) VALUES(10, 3, 55);
INSERT INTO BagelShop.Inventory (StoreID, ProductID, InventoryQuantity) VALUES(10, 8, 55);
INSERT INTO BagelShop.Inventory (StoreID, ProductID, InventoryQuantity) VALUES(10, 9, 55);
INSERT INTO BagelShop.Inventory (StoreID, ProductID, InventoryQuantity) VALUES(10, 10, 50);
INSERT INTO BagelShop.Inventory (StoreID, ProductID, InventoryQuantity) VALUES(10, 11, 50);
INSERT INTO BagelShop.Inventory (StoreID, ProductID, InventoryQuantity) VALUES(10, 12, 30);
INSERT INTO BagelShop.Inventory (StoreID, ProductID, InventoryQuantity) VALUES(10, 13, 30);

INSERT INTO BagelShop.Inventory (StoreID, ProductID, InventoryQuantity) VALUES(15, 1, 35);
INSERT INTO BagelShop.Inventory (StoreID, ProductID, InventoryQuantity) VALUES(15, 2, 35);
INSERT INTO BagelShop.Inventory (StoreID, ProductID, InventoryQuantity) VALUES(15, 3, 35);
INSERT INTO BagelShop.Inventory (StoreID, ProductID, InventoryQuantity) VALUES(15, 6, 35);
INSERT INTO BagelShop.Inventory (StoreID, ProductID, InventoryQuantity) VALUES(15, 9, 35);
INSERT INTO BagelShop.Inventory (StoreID, ProductID, InventoryQuantity) VALUES(15, 11, 35);
INSERT INTO BagelShop.Inventory (StoreID, ProductID, InventoryQuantity) VALUES(15, 13, 35);
INSERT INTO BagelShop.Inventory (StoreID, ProductID, InventoryQuantity) VALUES(15, 14, 35);
INSERT INTO BagelShop.Inventory (StoreID, ProductID, InventoryQuantity) VALUES(15, 16, 35);

INSERT INTO BagelShop.Inventory (StoreID, ProductID, InventoryQuantity) VALUES(20, 1, 15);
INSERT INTO BagelShop.Inventory (StoreID, ProductID, InventoryQuantity) VALUES(20, 2, 15);
INSERT INTO BagelShop.Inventory (StoreID, ProductID, InventoryQuantity) VALUES(20, 3, 15);
INSERT INTO BagelShop.Inventory (StoreID, ProductID, InventoryQuantity) VALUES(20, 4, 15);
INSERT INTO BagelShop.Inventory (StoreID, ProductID, InventoryQuantity) VALUES(20, 5, 15);
INSERT INTO BagelShop.Inventory (StoreID, ProductID, InventoryQuantity) VALUES(20, 6, 20);
INSERT INTO BagelShop.Inventory (StoreID, ProductID, InventoryQuantity) VALUES(20, 14, 10);
INSERT INTO BagelShop.Inventory (StoreID, ProductID, InventoryQuantity) VALUES(20, 15, 10);
INSERT INTO BagelShop.Inventory (StoreID, ProductID, InventoryQuantity) VALUES(20, 16, 10);


insert into [BagelShop].[Orders]
(OrderID, StoreID, ProductID, CustomerID, ProductQuantity, ProductTotalCost, DateCreated)
Select 
NewID(), 5, 2, 2, 4, 3.96, GetDate()

insert into [BagelShop].[Orders]
(OrderID, StoreID, ProductID, CustomerID, ProductQuantity, ProductTotalCost, DateCreated)
Select 
NewID(), 5, 3, 2, 4, 3.96, GetDate()

insert into [BagelShop].[Orders]
(OrderID, StoreID, ProductID, CustomerID, ProductQuantity, ProductTotalCost, DateCreated)
Select 
'238d2a50-6998-4275-8b67-751ba15ea95a', 5, 4, 2, 6, 6.48, GetDate()

insert into [BagelShop].[Orders]
(OrderID, StoreID, ProductID, CustomerID, ProductQuantity, ProductTotalCost, DateCreated)
Select 
'238d2a50-6998-4275-8b67-751ba15ea95a', 5, 5, 2, 7, 6.48, GetDate()

insert into [BagelShop].[Orders]
(OrderID, StoreID, ProductID, CustomerID, ProductQuantity, ProductTotalCost, DateCreated)
Select 
'238d2a50-6998-4275-8b67-751ba15ea95a', 5, 5, 2, 3, 3.48, GetDate()

insert into [BagelShop].[Orders]
(OrderID, StoreID, ProductID, CustomerID, ProductQuantity, ProductTotalCost, DateCreated)
Select 
NewID(), 10, 12, 3, 7, 6.99, GetDate()

insert into [BagelShop].[Orders]
(OrderID, StoreID, ProductID, CustomerID, ProductQuantity, ProductTotalCost, DateCreated)
Select 
NewID(), 10, 8, 2, 2, 3.49, GetDate()

insert into [BagelShop].[Orders]
(OrderID, StoreID, ProductID, CustomerID, ProductQuantity, ProductTotalCost, DateCreated)
Select 
NewID(), 10, 12, 2, 3, 4.49, GetDate()