

  Create database DBAlquilerVehiculo
  go

  use DBAlquilerVehiculo
  go

  create table tblPais
  (
  Codigo int primary key identity (1,1) not null,
  Nombre varchar(30) not null
  )

  insert into tblPais values( 'COLOMBIA' )


  create table tblDepartamento
  (
  Codigo int primary key identity (1, 1) not null,
  Nombre varchar(30) not null,
  Activo bit not null,
  IDPais int foreign key references tblPais(Codigo) not null
  )

   insert into tblDepartamento VALUES   ('ANTIOQUIA', 1, 1),
										('ATLÁNTICO', 1, 1),
										('BOLÍVAR', 1, 1),
										('BOYACÁ', 1, 1),
										('CALDAS', 1, 1),
										('CAQUETÁ', 1, 1),
										('CAUCA', 1, 1),
										('CESAR', 1, 1),
										('CÓRDOVA', 1, 1),
										('CUNDINAMARCA', 1, 1),
										('CHOCO', 1, 1),
										('HUILA', 1, 1),
										('LA GUAJIRA', 1, 1),
										('MAGDALENA', 1, 1),
										('META', 1, 1),
										('NARIÑO', 1, 1),
										('NORTE DE SANTANDER', 1, 1),
										('QUINDÍO', 1, 1),
										('RISARALDA', 1, 1),
										('SANTANDER', 1, 1),
										('SUCRE', 1, 1),
										('TOLIMA', 1, 1),
										('VALLE', 1, 1),
										('ARAUCA', 1, 1),
										('CASANARE', 1, 1),
										('PUTUMAYO', 1, 1),
										('AMAZONAS', 1, 1),
										('GUAINÍA', 1, 1),
										('GUAVIARE', 1, 1),
										('VAUPÉS', 1, 1),
										('VICHADA', 1, 1)


create table tblCiudad
(
Codigo int primary key identity (1,1) not null,
Nombre varchar(50) not null,
Activo bit not null,
CodigoDepartamento int foreign key references tblDepartamento(Codigo) not null
)

insert into tblCiudad values  ('MEDELLIN', 1, 1),
								('BELLO', 1, 1),
								('COPACABANA', 1, 1),
								('BARRANQUILLA', 1, 2),
								('CARTAGENA', 1, 3),
								('TUNJA', 1, 4),
								('MANIZALES', 1, 5),
								('FLORENCIA', 1, 6),	
								('POPAYAN', 1, 7),
								('VALLEDUPAR', 1, 8),
								('MONTERIA', 1, 9),
								('BOGOTÁ', 1, 10 ),
								('CHIA', 1, 10),
								('FUSAGASUGA', 1, 10),
								('QUIBDO', 1, 11 ),
								('NEIVA', 1, 12),
								('RIOHACHA', 1, 13),
								('SANTA MARTA', 1, 14),
								('VILLAVICENCIO', 1, 15),
								('PASTO', 1, 16),
								('CUCUTA', 1, 17),
								('ARMENIA', 1, 18),
								('PEREIRA', 1, 19),
								('BUCARAMANGA', 1, 20),
								('SINCELEJO', 1, 21),	
								('IBAGUE', 1, 22),
								('CALI', 1, 23),
								('ARAUCA', 1, 24),	
								('YOPAL', 1, 25),
								('MOCOA', 1, 26),		
								('LETICIA', 1, 27),
								('PUERTO INIRIDA', 1, 28),
								('SAN JOSE DEL GUAVIARE', 1, 29),
								('MITU', 1, 30),
						        ('PUERTO CARREÑO', 1, 31)

create table tblLicencia
  (
  Codigo int primary key identity (1, 1) not null,
  CategoriaLicencia varchar(20) not null
  )

  insert into tblLicencia values ('CATEGORIA A1' ),
                             ('CATEGORIA A2' ),
						     ('CATEGORIA B1' ),
					         ('CATEGORIA B2' ),
						     ('CATEGORIA B3' ),
							 ('CATEGORIA C1' ),
							 ('CATEGORIA C2' ),
						     ('CATEGORIA C3' )


  create table tblTipoDocumento
  (
  Codigo int primary Key identity (1, 1) not null,
  Nombre varchar(50) not null
  )

  insert into tblTipoDocumento values ('CEDULA DE CIUDADANIA'),
                                     ('CEDULA DE EXTRANJERIA'),
									 ('PASAPORTE')
									 

create table tblCliente
  (
  Documento varchar(20) primary key  not null,
  TipoDocumento int foreign key references tblTipoDocumento(Codigo) not null,
  Nombres varchar(50) not null,
  Apellidos varchar(50) not null,
  Direccion varchar(100) not null,
  Edad int not null,
  NumeroLicencia varchar(20) not null,
  IDLicencia int foreign key references tblLicencia(Codigo) not null,

  )

  insert into tblCliente values ( '12345', 2, 'JUAN ESTEBAN', 'MARIN LOPEZ', 'CRA 55 N 25 43', 29, 1000, 3)
  
  

  create table tblTipoTelefono
  (
  Codigo int primary Key identity (1, 1) not null,
  Nombre varchar(20) not null
  )

  insert into tblTipoTelefono values ('CASA'),
                                     ('TRABAJO'),
									 ('CELULAR'),
									 ('FAX')

  create table tblTelefonoCliente
  (
  Codigo int primary key identity (1, 1) not null,
  Numero varchar(20) not null,
  CedulaCliente varchar(20) foreign key references tblCliente(Documento) not null,
  IDTipoTelefono int foreign key references tblTipoTelefono(Codigo) not null
  )

  insert into tblTelefonoCliente values ( '2315456', '12345', 1),
                                        ( '3213256', '12345', 3)

create table tblSede
(
Codigo int primary key identity (1, 1) not null,
Nombre varchar(50) not null,
Direccion varchar(50) not null,
IDCiudadSede int foreign key references tblCiudad(Codigo) not null
)

insert into tblSede values ('Principal', 'CR 54 N 25 36', 1 )

create table tblMarca
(
Codigo int primary key identity(1, 1) not null,
Nombre varchar(20) not null
)

insert into tblMarca  values('FORD' ),
                            ('CHEVROLET'),
							('RENAULT'),
							('TOYOTA'),
							('MAZDA'),
							('VOLKSWAGEN'),
							('KIA' ),
							('MERCEDES BENZ' ),
                            ('AUDI'),
							('BENTLEY' )
							

create table tblGama
(
Codigo int primary key identity(1, 1) not null,
Nombre varchar(20) not null
)

insert into tblGama values ('BAJA' ),
                            ('MEDIA'),
							('ALTA' ) 

create table tblColor
(
Codigo int primary key identity(1, 1) not null,
Nombre varchar(20) not null
)

insert into tblColor values( 'NEGRO' ),
                            ('BLANCO'),
							('ROJO' ),
							( 'VERDE' ),
                            ('GRIS')

create table tblTipoVehiculo
(
Codigo int primary key identity (1, 1) not null,
Nombre varchar(20) not null
)
							
insert into tblTipoVehiculo values( 'AUTOMOVIL' ),
                            ('CAMPERO'),
							('CAMIONETA' ),
							('CONVERTIBLE'),
							('LIMUSINA' ),
							('VAN')
													

create table tblVehiculo
(
Placa varchar(6) primary key not null,
Descripcion varchar(100) not null,
Estado varchar(20) not null,
IDSede int foreign key references tblSede(Codigo) not null,
IDMarca int foreign key references tblMarca(Codigo) not null,
IDGama int foreign key references tblGama(Codigo) not null,
IDColor int foreign key references tblColor(Codigo) not null,
Precio int not null,
IDTipoVehiculo int foreign key references tblTipoVehiculo(Codigo) not null
)

insert into tblVehiculo values('ZTE235', 'BEAT', 'DISPONIBLE', 1, 2, 1, 1, 60000, 1),
                              ('KGT569', 'CAMARO 6.2 Ss', 'DISPONIBLE', 1, 2, 3, 1, 120000, 1),
                              ('CRH354', 'FIESTA 1.6', 'DISPONIBLE', 1, 1, 1, 4, 60000, 1),
							  ('JHU128', 'EXPLORER 2.3', 'DISPONIBLE', 1, 1, 2, 3, 90000, 3),
							  ('VGR645', 'DUSTER 2.0', 'DISPONIBLE', 1, 3, 2, 2, 90000, 3),
							  ('LID987', 'LOGAN 1.6', 'DISPONIBLE', 1, 3, 1, 1, 60000, 1),
							  ('YDF456', 'PRADO VX BLINDADA', 'DISPONIBLE', 1, 4, 3, 5, 120000, 3),
							  ('YFR258', 'COROLLA 1.8', 'DISPONIBLE', 1, 4, 2, 2, 90000, 1),
							  ('NGB159', 'CX-5 2.5', 'DISPONIBLE', 1, 5, 2, 4, 90000, 1),
							  ('XSD951', '2 GRAND TOURING', 'DISPONIBLE', 1, 5, 2, 1, 90000, 3),
							  ('POU357', 'GOLF 1.4', 'DISPONIBLE', 1, 6, 1, 4, 60000, 1),
							  ('TGD458', 'T-CROSS 1.6', 'DISPONIBLE', 1, 6, 2, 3, 90000, 3),
							  ('KIF478', 'SPORTAGE 2.0', 'DISPONIBLE', 1, 7, 2, 1, 60000, 3),
							  ('XSA263', 'SPRINTER PANEL', 'DISPONIBLE', 1, 8, 1, 1, 60000, 5),
							  ('DER251', 'A5 1.5 CONVERTIBLE', 'DISPONIBLE', 1, 9, 3, 1, 120000, 4),
							  ('HUF897', 'CONTINENTAL GT SPEED', 'DISPONIBLE', 1, 10, 3, 1, 200000, 1)


create table tblCargoEmpleado
(
Codigo int primary key identity (1, 1) not null,
Nombre varchar(20)
)

insert into tblCargoEmpleado values ( 'ADMINISTRADOR' ),
                                    ( 'ASESOR ')

create table tblEmpleado
(
Documento varchar(20) primary key not null,
Nombres   varchar(50) not null,
Apellidos varchar(50) not null,
IDCargoEmpleado int foreign key references tblCargoEmpleado(Codigo) not null
)

insert into tblEmpleado values ('1023525415', 'Juan Pablo', 'Martinez Gomez', 2),
							   ('1256425588', 'Pedro', 'Gonzalez Perez', 1)



create table tblAlquiler
(
Codigo int primary key not null,
CedulaCliente varchar(20) foreign key references tblCliente(Documento) not null,
IDEmpleado varchar(20) foreign key references tblEmpleado(Documento)not null,
PlacaVehiculo varchar(6) foreign key references tblVehiculo(Placa) not null,
EstadoAlquiler varchar(20) not null,
FechaInicio datetime not null,
FechaFin datetime not null
)

create table tblDevolucion
(
Codigo int primary key not null,
CodigoAlquiler int foreign key references tblAlquiler(Codigo) not null,
IDEmpleadoRecibe varchar(20) foreign key references tblEmpleado(Documento)not null,
FechaDevolucion datetime not null,
TotalPagar int not null
)
