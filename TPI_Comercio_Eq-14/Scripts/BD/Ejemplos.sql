use TPC_BD
go

INSERT INTO Proveedores (RazonSocial, CUIT, Telefono, Email, Direccion) VALUES
('TecnoSur S.A.', '30-12345678-9', '1145678901', 'contacto@tecnosur.com', 'Av. Corrientes 234'),
('ElectroMax', '30-87654321-5', '1123456789', 'ventas@electromax.com', 'Belgrano 789'),
('Distribuidora Delta', '33-11223344-9', '1132123456', 'info@deltadistrib.com', 'Av. San Martín 450'),
('CompuCity', '30-55443322-1', '1167894321', 'ventas@compucity.com', 'Callao 1500'),
('OfiLine', '30-99887766-3', '1144321567', 'ofiline@empresa.com', 'Maipú 900'),
('PrinterWorld', '30-44556677-0', '1133126789', 'contacto@printerworld.com', 'Av. Córdoba 1234'),
('SoftSolutions', '30-11112222-5', '1176543210', 'support@softsolutions.com', 'Av. Libertador 777'),
('GadgetStore', '30-33334444-7', '1188887777', 'gadget@store.com', 'Florida 999'),
('PCManía', '30-22223333-9', '1134567890', 'ventas@pcmania.com', 'Rivadavia 800'),
('HardwarePlus', '30-66665555-4', '1156789123', 'info@hardwareplus.com', 'Perón 650');

INSERT INTO Clientes (DNI, CUIT, Apellido, Nombre, Telefono, Email, Direccion) VALUES
('40123456', NULL, 'González', 'María', '1167891234', 'maria.g@gmail.com', 'Av. Belgrano 500'),
('39222333', NULL, 'Pérez', 'Juan', '1156789876', 'juanp@hotmail.com', 'Sarmiento 1200'),
('38555111', NULL, 'López', 'Lucía', '1176543210', 'lucial@gmail.com', 'Lavalle 980'),
('40112233', NULL, 'Rodríguez', 'Carlos', '1188886666', 'c.rodriguez@yahoo.com', 'Alsina 1300'),
('37889900', NULL, 'Fernández', 'Laura', '1122334455', 'laura.f@outlook.com', 'Reconquista 200'),
('40222333', NULL, 'Mendoza', 'Sofía', '1165432198', 'sofim@live.com', 'Catamarca 321'),
('39123456', NULL, 'Gómez', 'Nicolás', '1177889900', 'nicolasg@gmail.com', 'Pueyrredón 760'),
('38999888', NULL, 'Domínguez', 'Ana', '1145671234', 'ana.d@hotmail.com', 'Ayacucho 450'),
('39444555', NULL, 'Castro', 'Diego', '1133344455', 'dcastro@gmail.com', 'Córdoba 1600'),
('40000999', NULL, 'Ramos', 'Valentina', '1177775555', 'valen.ramos@yahoo.com', 'Suipacha 300');

INSERT INTO Categorias (Nombre, Descripcion) VALUES
('Computadoras', 'Equipos de escritorio y portátiles'),
('Periféricos', 'Teclados, ratones, auriculares, etc.'),
('Monitores', 'Pantallas LCD, LED y curvas'),
('Impresoras', 'Impresoras y multifuncionales'),
('Software', 'Licencias y programas'),
('Componentes', 'Partes internas de PC'),
('Redes', 'Routers, cables, adaptadores'),
('Almacenamiento', 'Discos duros, SSD, memorias USB'),
('Energía', 'Fuentes, UPS, estabilizadores'),
('Accesorios', 'Cables, fundas, adaptadores');

INSERT INTO Marcas (Nombre) VALUES
('HP'),
('Dell'),
('Lenovo'),
('Asus'),
('Samsung'),
('Logitech'),
('Epson'),
('Kingston'),
('TP-Link'),
('Corsair');

INSERT INTO Articulos (Nombre, Descripcion, PrecioCompra, PrecioVenta, Stock, IDMarca, IDCategoria) VALUES
('Notebook HP Pavilion', '15.6", 8GB RAM, 512GB SSD', 450000, 520000, 15, 1, 1),
('Mouse Logitech M170', 'Mouse inalámbrico óptico', 6000, 8000, 100, 6, 2),
('Monitor Samsung 24"', 'Full HD LED 75Hz', 95000, 110000, 25, 5, 3),
('Impresora Epson L3250', 'Multifunción con sistema continuo', 180000, 210000, 12, 7, 4),
('Memoria Kingston 8GB', 'DDR4 3200MHz', 22000, 28000, 40, 8, 6),
('Router TP-Link Archer', 'Router Wi-Fi AC1200', 35000, 42000, 30, 9, 7),
('Disco SSD Corsair 480GB', 'SATA III', 27000, 33000, 20, 10, 8),
('Fuente Corsair 650W', '80 Plus Bronze', 48000, 56000, 10, 10, 9),
('Teclado Logitech K120', 'Teclado USB resistente', 8000, 10000, 60, 6, 2),
('Monitor Dell 27"', 'QHD IPS', 180000, 210000, 8, 2, 3);

INSERT INTO Usuarios (Email, Contraseña) VALUES
('admin@tpc.com', 'admin123'),
('juan@tpc.com', 'passjuan'),
('maria@tpc.com', 'clave2024'),
('sofia@tpc.com', 'sofiapass'),
('carlos@tpc.com', '123carlitos'),
('nicolas@tpc.com', 'nico_2025'),
('laura@tpc.com', 'laura*pwd'),
('diego@tpc.com', 'diegoseguro'),
('ana@tpc.com', 'ana321'),
('valen@tpc.com', 'valenpass');

INSERT INTO ComprasDetalle (IDArticulo, IDProveedor, Cantidad, PrecioUnitario, Subtotal, IVA, Total) VALUES
(1,1,10,450000,4500000,0.21,5445000),
(2,2,50,6000,300000,0.21,363000),
(3,3,20,95000,1900000,0.21,2299000),
(4,4,5,180000,900000,0.21,1089000),
(5,5,30,22000,660000,0.21,798600),
(6,6,15,35000,525000,0.21,635250),
(7,7,10,27000,270000,0.21,326700),
(8,8,8,48000,384000,0.21,464640),
(9,9,40,8000,320000,0.21,387200),
(10,10,5,180000,900000,0.21,1089000);

INSERT INTO VentasDetalle (IDArticulo, IDCliente, Cantidad, PrecioUnitario, Subtotal, IVA, Total) VALUES
(1,1,1,520000,520000,0.21,629200),
(2,2,2,8000,16000,0.21,19360),
(3,3,1,110000,110000,0.21,133100),
(4,4,1,210000,210000,0.21,254100),
(5,5,2,28000,56000,0.21,67760),
(6,6,1,42000,42000,0.21,50820),
(7,7,1,33000,33000,0.21,39930),
(8,8,1,56000,56000,0.21,67760),
(9,9,3,10000,30000,0.21,36300),
(10,10,1,210000,210000,0.21,254100);