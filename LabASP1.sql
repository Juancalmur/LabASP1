use BD_B11291

create table Cliente (
	nombre		char(20),
	apellido1	char(20),
	apellido2	char(20),
	correo		char(50),
	direccion	char(100),
	cedula		char(20)		primary key
);

create table Telefono (
	numero		char(20),
	cedula		char(20),

	constraint telefonoPK primary key (numero, cedula),
	constraint telefonoFK foreign key (cedula) references Cliente (cedula)
);

create table Cuenta (
	numero		char(20),
	tipo		char(20),
	cedula		char(20),

	constraint cuentaPK primary key (numero, cedula),
	constraint cuentaFK foreign key (cedula) references Cliente (cedula)
);

insert into Cliente values ('Julian', 'Calvo', 'Murillo', 'bla@gmail.com', 'allapadentro', '123456');
INSERT INTO Telefono VALUES('165484', '123456');
INSERT INTO Cuenta VALUES('321685', 'ahorro', '123456');