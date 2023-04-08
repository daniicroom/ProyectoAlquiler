CREATE PROCEDURE Alquilar_Vehiculo
	
@prCodigo int,
@prCedulaCliente varchar(20),
@prIdEmpleado int,
@prPlacaVehiculo varchar(50), 
@prEstadoAlquiler varchar(20), 
@prFechaInicio dateTime, 
@prFechaFin dateTime,
@prEstadoVehiculo varchar(20)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO tblAlquiler (Codigo, CedulaCliente, IDEmpleado, PlacaVehiculo, EstadoAlquiler, FechaInicio, FechaFin)
	values (@prCodigo ,@prIdEmpleado,@prPlacaVehiculo, @prEstadoAlquiler, @prFechaInicio, @prCedulaCliente, @prFechaFin);

	--Update estado de vehiculo
	Update tblVehiculo
	SET
	Estado = @prEstadoVehiculo
	where Placa = @prPlacaVehiculo
END
GO
CREATE PROCEDURE Devolver_Vehiculo
	
@prCodigo int,
@prCodigoAlquiler int,
@prIdEmpleadoRecibe int, 
@prEstadoAlquiler varchar(20),
@prTotalPagar int,
@prPlacaVehiculo varchar(50), 
@prEstadoVehiculo varchar(20)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO tblDevolucion(Codigo, CodigoAlquiler, IDEmpleadoRecibe, TotalPagar)
	values (@prCodigo,@prCodigoAlquiler ,@prIdEmpleadoRecibe, @prTotalPagar);

	--Update estado de alquiler
	Update tblAlquiler
	SET
	EstadoAlquiler = @prEstadoAlquiler
	where Codigo = @prCodigoAlquiler

	--Update estado de vehiculo
	Update tblVehiculo
	SET
	Estado = @prEstadoVehiculo
	where Placa = @prPlacaVehiculo
END
GO