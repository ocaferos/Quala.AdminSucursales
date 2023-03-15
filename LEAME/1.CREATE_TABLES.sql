USE TestDB
CREATE TABLE Quala_Moneda (
		Codigo_Moneda int IDENTITY (1, 1) PRIMARY KEY not null,
		Descripcion NVARCHAR(50) not null,
		);

CREATE TABLE Quala_Sucursal (
	Codigo int IDENTITY (1, 1) primary key not null,
	Descripcion nvarchar(250) not null,
	Direccion nvarchar(250) not null,
	Identificacion nvarchar(50) not null,
	Fecha_Creacion smalldatetime,
	Codigo_Moneda int, 
	constraint fk_Quala_moneda foreign key (Codigo_Moneda) references Quala_Moneda (Codigo_Moneda)
);

INSERT INTO Quala_Moneda(Descripcion)
VALUES('COP'),('USD'),('EUR'),('BOL'),('ARS')