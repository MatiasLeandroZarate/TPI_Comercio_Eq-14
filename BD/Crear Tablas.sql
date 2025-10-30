Create Database TPC_DB
Collate Latin1_General_CI_AI
go
use TPC_DB
go
Create Table Proveedores(
	IDProveedor int primary key identity(1,1),
	RazonSocial nvarchar (50) not null,
	CUIT nvarchar(25) not null,
	Telefono nvarchar(20) not null,
	Email nvarchar(50) not null,
	Direccion nvarchar(50) not null,
	Activo bit DEFAULT 1 not null
)
go

Create Table Clientes(
	IDCliente int primary key identity(1,1),
	DNI nvarchar (25) not null,
	CUIT nvarchar (25) null,
	Apellido nvarchar (50) null,
	Nombre nvarchar (50) null,
	Telefono nvarchar (20) null,
	Email nvarchar (50) null,
	Direccion nvarchar(50) null,
	Activo bit DEFAULT 1 not null
)
go

Create Table Categorias(
	IDCategoria int primary key identity(1,1),
	Nombre nvarchar (50) not null,
	Descripcion nvarchar (100) null
)
go

create table Marcas(
	IDMarca int primary key identity(1,1),
	Nombre nvarchar (50) not null
)

go

Create Table Articulos(
	IDArticulo int primary key identity(1,1),
	Nombre nvarchar (50) not null,
	Descripcion nvarchar (100) null,
	PrecioCompra money not null check (PrecioCompra > 0),
	PrecioVenta money not null check (PrecioVenta > 0),
	Stock int not null check (Stock >= 0),
	IDMarca int NOT NULL,
	IDCategoria int not null,
	FOREIGN KEY (IDMarca) References Marcas(IDMarca),
	FOREIGN KEY (IDCategoria) References Categorias(IDCategoria),
	Activo bit DEFAULT 1 not null
)
go

Create Table Usuarios(
	IDUsuario int primary key identity(1,1),
	Email nvarchar (50) not null,
	Contraseña nvarchar (50) not null,
)
go

Create Table ComprasDetalle(
	IDCompraDetalle int primary key identity(1,1),
	IDArticulo int not null,
	IDProveedor int not null,
	Cantidad int not null,
	PrecioUnitario money not null check (PrecioUnitario > 0),
	Subtotal money not null check (Subtotal > 0),
	IVA decimal(4,2) not null check (IVA > 0),
	Total money not null check (Total > 0),
	FOREIGN KEY (IDArticulo) References Articulos(IDArticulo),
	FOREIGN KEY (IDProveedor) References Proveedores(IDProveedor)
)
go

Create Table VentasDetalle(
	IDVentaDetalle int primary key identity(1,1),
	IDArticulo int not null,
	IDCliente int not null,
	Cantidad int not null,
	PrecioUnitario money not null check (PrecioUnitario > 0),
	Subtotal money not null check (Subtotal > 0),
	IVA decimal(4,2) not null check (IVA > 0),
	Total money not null check (Total > 0),
	FOREIGN KEY (IDArticulo) References Articulos(IDArticulo),
	FOREIGN KEY (IDCliente) References Clientes(IDCliente)
)
