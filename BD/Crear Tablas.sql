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

CREATE TABLE Compra(
    IDCompra int primary key identity(1,1),
    IDProveedor int not null,
    NroComprobante int,
    Fecha date not null DEFAULT GETDATE(),
    Descuentos decimal(12,2),
    Subtotal decimal(12,2),
    Total decimal(12,2),
    FOREIGN KEY (IDProveedor) REFERENCES Proveedores(IDProveedor),
);
go

CREATE TABLE ComprasDetalle (
    IDDetalleCompra int primary key identity(1,1),
    IDCompra int not null,
    IDArticulo int not null,
    Cantidad int not null,
    Fecha date not null DEFAULT GETDATE(),
    PrecioUnitario decimal(12,2),
    FOREIGN KEY (IDCompra) REFERENCES Compra(IDCompra),
    FOREIGN KEY (IDArticulo) REFERENCES Articulos(IDArticulo)
);
go

CREATE TABLE Venta (
    IDVenta int primary key identity(1,1),
    IDCliente int not null,
    NroComprobante int,
    Fecha date not null DEFAULT GETDATE(),
    Descuentos decimal(12,2),
    Subtotal decimal(12,2),
    Total decimal(12,2),
    FOREIGN KEY (IDCliente) REFERENCES Clientes(IDCliente),
);
go

CREATE TABLE VentasDetalle (
    IDDetalleVenta int primary key identity(1,1),
    IDVenta int not null,
    IDArticulo int not null,
    Cantidad int not null,
    Fecha date not null DEFAULT GETDATE(),
    PrecioUnitario decimal(12,2),
    FOREIGN KEY (IDVenta) REFERENCES Venta(IDVenta),
    FOREIGN KEY (IDArticulo) REFERENCES Articulos(IDArticulo)
);