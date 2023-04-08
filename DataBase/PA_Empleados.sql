CREATE PROCEDURE Registrar_Empleado
	
@prDocumento varchar(20),
@prNombres varchar(50),
@prApellidos varchar(50),
@prIdCargoEmpleado int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO tblEmpleado (Documento, Nombres, Apellidos, IdCargoEmpleado)
	values (@prDocumento ,@prNombres,@prApellidos, @prIdCargoEmpleado);
END
GO

CREATE PROCEDURE Actualizar_Empleado
	
@prDocumento varchar(20),
@prNombres varchar(50),
@prApellidos varchar(50), 
@prIdCargoEmpleado int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Update tblEmpleado
	SET
	Documento = @prDocumento,
	Nombres = @prNombres, 
	Apellidos = @prApellidos, 
	IdCargoEmpleado = @prIdCargoEmpleado
	where Documento = @prDocumento
END
GO

CREATE PROCEDURE Borrar_Empleado
	
@prDocumento varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Delete from tblEmpleado
	Where Documento = @prDocumento;

END
GO

CREATE PROCEDURE Consultar_Empleado
	
@prDocumento varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select * from tblEmpleado Where Documento = @prDocumento;
END
GO