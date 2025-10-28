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
	Estado bit DEFAULT 1 not null,
	FechaAlta datetime not null DEFAULT GETDATE(),
	FechaUltimaModificacion datetime not null DEFAULT GETDATE()
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
	Estado bit DEFAULT 1 not null,
	FechaAlta datetime not null DEFAULT GETDATE(),
	FechaUltimaModificacion datetime not null DEFAULT GETDATE()
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
	CodigoBarra nvarchar(50) NOT NULL,
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

Create Table Cargos(
	IDCargo int primary key identity(1,1),
	Nombre nvarchar (50) not null,
	--SalarioMensual?
)
go

Create Table Empleados(
	IDEmpleado int primary key identity(1,1),
	DNI nvarchar (25) not null,
	Apellido nvarchar (50) not null,
	Nombre nvarchar (50) not null,
	IDCargo int not null,
	Estado bit DEFAULT 1 not null,
	FechaIngreso Datetime not null default getdate(),
	FechaDesvinculacion datetime not null default getdate(),
	Sueldo money not null check (Sueldo > 0),
	FOREIGN KEY (IDCargo) References Cargos(IDCargo)
)
go

Create Table PagoSueldos(
	IDPago int primary key identity(1,1),
	IDEmpleado int not null,
	FechaPago Datetime not null default getdate(),
	Periodo Datetime not null default getdate(),
	MontoPagado money not null check (MontoPagado > 0),
	MetodoPago nvarchar(50) not null,
	FOREIGN KEY (IDEmpleado) References Empleados(IDEmpleado)
)
go

Create table FormaPagos(
	IdFormaPago int primary key identity(1,1),
	Descripcion nvarchar(50) not null
)
-- Revisar las columnas de las tablas "ComprasDetalle" y "VentasDetalle".

Create Table ComprasDetalle(
	--IDCompraDetalle int primary key identity(1,1),
	IDArticulo int not null,
	IDProveedor int not null,
	Cantidad int not null,
	Fecha Datetime not null default getdate(),
	PrecioUnitario money not null check (PrecioUnitario > 0),
	Descuentos money null check (Descuentos >= 0),
	Subtotal money not null check (Subtotal > 0),
	Total money not null check (Total > 0),
	IDEmpleado int not null,
	IDFormaPago int not null
	FOREIGN KEY (IDFormaPago) References FormaPagos(IDFormaPago),
	FOREIGN KEY (IDEmpleado) References Empleados(IDEmpleado),
	FOREIGN KEY (IDArticulo) References Articulos(IDArticulo),
	FOREIGN KEY (IDProveedor) References Proveedores(IDProveedor)
)
go

Create Table VentasDetalle(
	--IDVentaDetalle int primary key identity(1,1),
	IDArticulo int not null,
	IDCliente int not null,
	Cantidad int not null,
	Fecha Datetime not null default getdate(),
	PrecioUnitario money not null check (PrecioUnitario > 0),
	Descuentos money null check (Descuentos >= 0),
	Subtotal money not null check (Subtotal > 0),
	Total money not null check (Total > 0),
	IDEmpleado int not null,
	IDFormaPago int not null
	FOREIGN KEY (IDFormaPago) References FormaPagos(IDFormaPago),
	FOREIGN KEY (IDEmpleado) References Empleados(IDEmpleado),
	FOREIGN KEY (IDArticulo) References Articulos(IDArticulo),
	FOREIGN KEY (IDCliente) References Clientes(IDCliente)
)
go

create table Imagenes(
	IDImagen int primary key identity(1,1),
	IDArticulo int not null,
	ImagenUrl nvarchar(250) null,
	FOREIGN KEY (IDArticulo) References Articulos(IDArticulo)
)
