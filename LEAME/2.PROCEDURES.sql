CREATE PROCEDURE SucursalInsert
(
	@Descripcion nvarchar (250) ,
	@Direccion nvarchar (250) ,
	@Identificacion nvarchar (50) ,
	@FechaCreacion smalldatetime ,
	@CodigoMoneda nvarchar (20)
)
AS
BEGIN
	INSERT Quala_Sucursal
	SELECT @Descripcion,@Direccion, @Identificacion,@FechaCreacion,(SELECT Codigo_Moneda FROM Quala_Moneda WHERE Descripcion = @CodigoMoneda)
END
GO

CREATE PROCEDURE SucursalUpdate
(
	@Codigo int,
	@Descripcion nvarchar (250) ,
	@Direccion nvarchar (250) ,
	@Identificacion nvarchar (50) ,
	@FechaCreacion smalldatetime ,
	@CodigoMoneda nvarchar(20)
)
AS
BEGIN

    UPDATE Quala_Sucursal
        SET
        Descripcion=@Descripcion,
		Direccion=@Direccion,
		Identificacion=@Identificacion,
		Fecha_Creacion=@FechaCreacion,
		Codigo_Moneda=(SELECT Codigo_Moneda FROM Quala_Moneda WHERE Descripcion = @CodigoMoneda)
    WHERE Codigo=@Codigo

END
GO

CREATE PROCEDURE SucursalDelete
(
	@Codigo int
)
AS
BEGIN

    DELETE Quala_Sucursal
    WHERE Codigo=@Codigo

END
GO

CREATE PROCEDURE SucursalList
AS
BEGIN
    SELECT Codigo,S.Descripcion,Direccion,Identificacion,Fecha_Creacion,M.Descripcion AS Codigo_Moneda
    FROM Quala_Sucursal S
	LEFT JOIN Quala_Moneda M ON S.Codigo_Moneda = M.Codigo_Moneda
END
GO

ALTER PROCEDURE SucursalGetByID
(
    @Codigo int
)
AS
BEGIN

    SELECT Codigo,S.Descripcion,Direccion,Identificacion,Fecha_Creacion,M.Descripcion AS Codigo_Moneda
    FROM Quala_Sucursal S
	LEFT JOIN Quala_Moneda M ON S.Codigo_Moneda = M.Codigo_Moneda
    WHERE Codigo=@Codigo

END
GO

CREATE PROCEDURE MonedaList
AS
BEGIN

    SELECT Codigo_Moneda,Descripcion
    FROM Quala_Moneda
END
GO

CREATE PROCEDURE MonedaGetByID
(
    @CodigoMoneda int
)
AS
BEGIN

    SELECT Codigo_Moneda,Descripcion
    FROM Quala_Moneda
    WHERE Codigo_Moneda=@CodigoMoneda

END
GO