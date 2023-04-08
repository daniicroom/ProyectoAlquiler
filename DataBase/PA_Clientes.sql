
CREATE PROCEDURE Registrar_Cliente 
	
@prDocumento varchar(20),
@prIdTipoDocumento int,
@prNombres varchar(50),
@prApellidos varchar(50), 
@prEdad int, 
@prNumeroLicencia varchar(200), 
@prIdLicencia int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO tblCliente (Documento, TipoDocumento, Nombres, Apellidos, Edad, NumeroLicencia, IdLicencia)
	values (@prDocumento ,@prNombres,@prApellidos, @prEdad, @prNumeroLicencia, @prIdTipoDocumento, @prIdLicencia);
END
GO


CREATE PROCEDURE Actualizar_Cliente 
	
@prDocumento varchar(20),
@prIdTipoDocumento int, 
@prNombres varchar(50),
@prApellidos varchar(50), 
@prEdad int, 
@prNumeroLicencia varchar(200), 
@prIdLicencia int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Update tblCliente
	SET
	Documento = @prDocumento,
	TipoDocumento = @prIdTipoDocumento, 
	Nombres = @prNombres,
	Apellidos = @prApellidos,
	Edad = @prEdad, 
	NumeroLicencia = @prNumeroLicencia, 
	IdLicencia = @prIdLicencia
	where Documento = @prDocumento
END
GO

CREATE PROCEDURE Borrar_Cliente 
	
@prDocumento varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Delete from tblCliente
	Where Documento = @prDocumento;

END
GO

CREATE PROCEDURE Consultar_Cliente 
	
@prDocumento varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select * from tblCliente Where Documento = @prDocumento;
END
GO