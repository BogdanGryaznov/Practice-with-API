use master
DROP DATABASE IF EXISTS shop_api_db

create database shop_api_db
go 
use shop_api_db
go
create table Roles(
role_id int not null,
role_name nvarchar(50) not null,
is_deleted bit not null
)




create table Users(
id_user int not null,
email nvarchar(50) not null,
password nvarchar(50) not null,
role_id int not null,
is_deleted bit not null
)





create table Carts(
id_user int not null,
item_id int not null,
quantity int not null,
is_deleted bit not null
)




create table Orders(
id_user int not null,
order_id int not null,
delivery_type nvarchar(20) not null,
status nvarchar(20) not null,
is_deleted bit not null
)



create table Orders_item(
order_id int not null,
item_id int not null,
quantity int not null,
is_deleted bit not null
)



create table Products(
item_id int not null,
item_name nvarchar(50) not null,
item_description nvarchar(100),
warehouse_quantity int not null,
price int,
category_id int,
is_deleted bit not null,
)




create table Categories(
category_id int not null,
category_name nvarchar(50) not null,
is_deleted bit not null
)



create table Specs(
spec_id int not null,
category_id int not null,
spec_name nvarchar(50) not null,
is_deleted bit not null
)



create table Specs_item(
item_id int not null,
spec_id int not null,
spec_value nvarchar(50),
is_deleted bit not null
)








alter table Roles
ADD CONSTRAINT PK_Roles PRIMARY KEY (role_id);

alter table Users
ADD CONSTRAINT PK_Users PRIMARY KEY (id_user);

alter table Carts
ADD CONSTRAINT PK_Carts PRIMARY KEY (id_user, item_id);
go

alter table Specs_item
ADD CONSTRAINT PK_Specs_item PRIMARY KEY (spec_id, item_id);
go

alter table Orders
ADD CONSTRAINT PK_Orders PRIMARY KEY (order_id, id_user);
go

alter table Orders_item
ADD CONSTRAINT PK_Orders_item PRIMARY KEY (item_id, order_id);
go

alter table Products
ADD CONSTRAINT PK_Products PRIMARY KEY (item_id);
go

alter table Categories
ADD CONSTRAINT PK_Categories PRIMARY KEY (category_id);
go

alter table Specs
ADD CONSTRAINT PK_Specs PRIMARY KEY (spec_id, category_id);
go





alter table Carts
ADD CONSTRAINT FK_UserCarts FOREIGN KEY (id_user) REFERENCES Users(id_user);
go
alter table Carts
ADD CONSTRAINT FK_ItemsCarts FOREIGN KEY (item_id) REFERENCES Products(item_id);

alter table Orders
ADD CONSTRAINT FK_UsersOrders FOREIGN KEY (id_user) REFERENCES Users(id_user);

alter table Orders_item
ADD CONSTRAINT FK_ItemsOrders_item FOREIGN KEY (item_id) REFERENCES Products(item_id);
go
alter table Orders_item
ADD CONSTRAINT FK_OrdersOrders_item FOREIGN KEY (order_id) REFERENCES Orders(order_id);

alter table Specs
ADD CONSTRAINT FK_CategorySpecs FOREIGN KEY (category_id) REFERENCES Category(category_id);

alter table Specs_item
ADD CONSTRAINT FK_SpecsSpecs_item FOREIGN KEY (spec_id) REFERENCES Specs(spec_id);
go
alter table Specs_item
ADD CONSTRAINT FK_ItemsSpecs_item FOREIGN KEY (item_id) REFERENCES Products(item_id);