use TPC_BD
go

INSERT INTO Categorias (Nombre, Descripcion) VALUES
('Bebidas', 'Refrescos, aguas y jugos'),
('Lácteos', 'Leche, yogures y quesos'),
('Panadería', 'Pan, facturas y galletitas'),
('Carnes', 'Vacuna, pollo y cerdo'),
('Limpieza', 'Productos de limpieza del hogar'),
('Perfumería', 'Shampoo, jabones y cosméticos'),
('Congelados', 'Verduras y comidas congeladas'),
('Snacks', 'Papas fritas, galletitas saladas'),
('Verduras', 'Productos frescos de verdulería'),
('Frutas', 'Frutas de estación');

INSERT INTO Marcas (Nombre) VALUES
('Coca Cola'),
('La Serenísima'),
('Panadería Central'),
('Carnes Premium'),
('Ayudín'),
('Pantene'),
('Congelados Express'),
('Lays'),
('Verdulería Verde'),
('Frutas del Valle');


INSERT INTO Articulos (Nombre, CodigoBarra, Descripcion, PrecioCompra, PrecioVenta, Stock, IDMarca,IDCategoria ) VALUES
('Coca Cola 1.5L','7790000000011', 'Bebida gaseosa', 150, 250, 100, 1,1),
('Leche La Serenísima','7790000000028', 'Entera 1L', 120, 190, 80, 2,2),
('Pan francés','7790000000035', 'Pan fresco del día', 80, 120, 50, 3,3),
('Carne picada','7790000000042', '1kg de carne vacuna', 600, 850, 40, 4,4),
('Lavandina Ayudín','7790000000059', '1L', 90, 150, 60, 5,5),
('Shampoo Pantene','7790000000066', '400ml', 300, 450, 30, 6,6),
('Pizza congelada','7790000000073', 'Mozzarella', 500, 750, 25, 7,7),
('Papas Lays','7790000000080', 'Clásicas 120g', 180, 280, 70, 8,8),
('Tomate','7790000000097', 'Por kilo', 200, 300, 100, 9,9),
('Banana','7790000000103', 'Por kilo', 180, 270, 90, 10,10);

INSERT INTO Proveedores (RazonSocial, CUIT, Telefono, Email, Direccion) VALUES
('Distribuidora Norte', '30-12345678-9', '011-4567-8901', 'contacto@norte.com', 'Av. Rivadavia 1234'),
('Lácteos del Sur', '30-98765432-1', '011-2345-6789', 'ventas@lacteossur.com', 'Calle 9 de Julio 456'),
('Panadería Central', '30-11223344-5', '011-1111-2222', 'pan@central.com', 'Av. Belgrano 789'),
('Carnes Premium', '30-55667788-0', '011-3333-4444', 'info@carnespremium.com', 'Ruta 8 km 45'),
('Químicos Limpios', '30-99887766-3', '011-5555-6666', 'ventas@quimlimpios.com', 'Av. San Martín 321'),
('Cosméticos Belleza', '30-44332211-7', '011-7777-8888', 'contacto@belleza.com', 'Calle Lavalle 654'),
('Congelados Express', '30-66778899-2', '011-9999-0000', 'info@congelados.com', 'Av. Mitre 987'),
('SnacksManía', '30-11112222-3', '011-1212-3434', 'ventas@snacksmania.com', 'Calle Corrientes 321'),
('Verdulería Verde', '30-22223333-4', '011-5656-7878', 'verde@verduleria.com', 'Av. Libertador 456'),
('Frutas del Valle', '30-33334444-5', '011-9090-1010', 'contacto@frutasvalle.com', 'Ruta 2 km 12');

INSERT INTO Clientes (DNI, CUIT, Apellido, Nombre, Telefono, Email, Direccion) VALUES
('12345678', NULL, 'Gómez', 'Lucía', '011-1111-1111', 'lucia@gmail.com', 'Calle Falsa 123'),
('23456789', NULL, 'Pérez', 'Juan', '011-2222-2222', 'juanp@gmail.com', 'Av. Siempreviva 742'),
('34567890', NULL, 'Rodríguez', 'María', '011-3333-3333', 'maria.r@gmail.com', 'Calle 25 de Mayo 456'),
('45678901', NULL, 'Fernández', 'Carlos', '011-4444-4444', 'carlosf@gmail.com', 'Av. San Juan 789'),
('56789012', NULL, 'López', 'Ana', '011-5555-5555', 'ana.l@gmail.com', 'Calle Moreno 321'),
('67890123', NULL, 'Martínez', 'Diego', '011-6666-6666', 'diegom@gmail.com', 'Av. Córdoba 654'),
('78901234', NULL, 'Sánchez', 'Laura', '011-7777-7777', 'lauras@gmail.com', 'Calle Santa Fe 987'),
('89012345', NULL, 'García', 'Pedro', '011-8888-8888', 'pedrog@gmail.com', 'Av. Pueyrredón 159'),
('90123456', NULL, 'Ramírez', 'Sofía', '011-9999-9999', 'sofiar@gmail.com', 'Calle Alberdi 753'),
('01234567', NULL, 'Torres', 'Julián', '011-0000-0000', 'juliant@gmail.com', 'Av. La Plata 852');

INSERT INTO Cargos (Nombre) VALUES
('Cajero'),
('Repositor'),
('Encargado'),
('Gerente'),
('Administrativo'),
('Supervisor'),
('Seguridad'),
('Limpieza'),
('Atención al cliente'),
('Compras');

INSERT INTO Empleados (DNI, Apellido, Nombre, IDCargo, Sueldo) VALUES
('10101010', 'Ruiz', 'Martín', 1, 150000),
('20202020', 'Alvarez', 'Camila', 2, 140000),
('30303030', 'Molina', 'Santiago', 3, 180000),
('40404040', 'Vega', 'Florencia', 4, 250000),
('50505050', 'Silva', 'Matías', 5, 160000),
('60606060', 'Castro', 'Valentina', 6, 200000),
('70707070', 'Ortiz', 'Nicolás', 7, 170000),
('80808080', 'Ramos', 'Carla', 8, 130000),
('90909090', 'Medina', 'Tomás', 9, 145000),
('11111111', 'Herrera', 'Luciana', 10, 190000);

INSERT INTO FormaPagos (Descripcion) VALUES
('Efectivo'),
('Tarjeta de crédito'),
('Tarjeta de débito'),
('Transferencia bancaria'),
('Mercado Pago'),
('Cheque'),
('Crédito proveedor'),
('Vale empresa'),
('Pago móvil'),
('QR bancario');

INSERT INTO PagoSueldos (IDEmpleado, Periodo, MontoPagado, MetodoPago) VALUES
(1, '2025-09-01', 150000, 'Transferencia bancaria'),
(2, '2025-09-01', 140000, 'Efectivo'),
(3, '2025-09-01', 180000, 'Cheque'),
(4, '2025-09-01', 250000, 'Transferencia bancaria'),
(5, '2025-09-01', 160000, 'Mercado Pago'),
(6, '2025-09-01', 200000, 'QR bancario'),
(7, '2025-09-01', 170000, 'Tarjeta de débito'),
(8, '2025-09-01', 130000, 'Efectivo'),
(9, '2025-09-01', 145000, 'Transferencia bancaria'),
(10, '2025-09-01', 190000, 'Mercado Pago');

INSERT INTO ComprasDetalle (IDArticulo, IDProveedor, Cantidad, PrecioUnitario, Descuentos, Subtotal, Total, IDEmpleado, IDFormaPago) VALUES
(1, 1, 50, 150, 0, 7500, 7500, 1, 1),
(2, 2, 40, 120, 100, 4700, 4600, 2, 2),
(3, 3, 30, 80, 0, 2400, 2400, 3, 3),
(4, 4, 20, 600, 200, 12000, 11800, 4, 4),
(5, 5, 60, 90, 0, 5400, 5400, 5, 5),
(6, 6, 25, 300, 50, 7500, 7450, 6, 6),
(7, 7, 15, 500, 0, 7500, 7500, 7, 7),
(8, 8, 70, 180, 70, 12600, 12530, 8, 8),
(9, 9, 100, 200, 100, 20000, 19900, 9, 9),
(10, 10, 90, 180, 90, 16200, 16110, 10, 10);

INSERT INTO VentasDetalle (IDArticulo, IDCliente, Cantidad, PrecioUnitario, Descuentos, Subtotal, Total, IDEmpleado, IDFormaPago) VALUES
(1, 1, 2, 250, 0, 500, 500, 1, 1),
(2, 2, 3, 190, 10, 570, 560, 2, 2),
(3, 3, 5, 120, 0, 600, 600, 3, 3),
(4, 4, 1, 850, 50, 850, 800, 4, 4),
(5, 5, 4, 150, 0, 600, 600, 5, 5),
(6, 6, 2, 450, 20, 900, 880, 6, 6),
(7, 7, 1, 750, 0, 750, 750, 7, 7),
(8, 8, 6, 280, 30, 1680, 1650, 8, 8),
(9, 9, 3, 300, 0, 900, 900, 9, 9),
(10, 10, 2, 270, 20, 540, 520, 10, 10);

INSERT INTO Imagenes (IDArticulo, ImagenUrl) VALUES
(1, 'https://tse4.mm.bing.net/th/id/OIP.PTUU1lT-jh0AQIky6PJMOwHaJ4?rs=1&pid=ImgDetMain&o=7&rm=3'),
(2, 'https://tse4.mm.bing.net/th/id/OIP.y1zvW-_ZLspLaCg80RjGNgHaHa?rs=1&pid=ImgDetMain&o=7&rm=3'),
(3, 'https://th.bing.com/th/id/R.a8eccea3caf42870a9993956b63c674e?rik=o0v0L9Q6pvyyRA&riu=http%3a%2f%2fs.libertaddigital.com%2ffotos%2fnoticias%2fpan.jpg&ehk=aPpsPJL8FfvIjFtmYYUvK1abSw0Wp7LnBwFNfttiPCo%3d&risl=&pid=ImgRaw&r=0'),
(3, 'https://tse4.mm.bing.net/th/id/OIP.cZ1JyNduYdYgWmNnGYsbNwHaE8?w=1500&h=1000&rs=1&pid=ImgDetMain&o=7&rm=3'),
(4, 'https://tse1.explicit.bing.net/th/id/OIP.VLimcRwa6vzCaO_rnwd3DQHaE8?rs=1&pid=ImgDetMain&o=7&rm=3'),
(5, 'https://th.bing.com/th/id/OIP.ant1MyoCWLs8H7ipeJeYpAHaHa?o=7rm=3&rs=1&pid=ImgDetMain&o=7&rm=3'),
(6, 'https://th.bing.com/th/id/OIP.oe3FqXC4rq4-LqxBVscx5gHaHa?w=186&h=186&c=7&r=0&o=7&dpr=1.3&pid=1.7&rm=3'),
(7, 'https://th.bing.com/th/id/OIP.rAo9lcEqYPzAuB1fdPzhQQHaD3?w=288&h=180&c=7&r=0&o=7&dpr=1.3&pid=1.7&rm=3'),
(8, 'https://th.bing.com/th/id/OIP.JP-TudtT9NQAIJnejbN09wHaEE?w=254&h=180&c=7&r=0&o=7&dpr=1.3&pid=1.7&rm=3'),
(9, 'https://th.bing.com/th/id/OIP.T21ZfZxrWT0YbtMym-X7DQHaE7?w=231&h=180&c=7&r=0&o=7&dpr=1.3&pid=1.7&rm=3'),
(10, 'https://th.bing.com/th/id/OIP.Osnnv1A-uw6PQbQMnuSJ3gHaE9?w=266&h=180&c=7&r=0&o=7&dpr=1.3&pid=1.7&rm=3');


