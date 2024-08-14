CREATE TABLE CentroDeAtencion
(
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    Nombre NVARCHAR(255) NOT NULL,
    Activo BIT NOT NULL,
    FechaAlta DATETIME NOT NULL,
    UsuarioAlta NVARCHAR(255) NOT NULL,
    FechaModificacion DATETIME NULL,
    UsuarioModificacion NVARCHAR(255) NULL,
    FechaBaja DATETIME NULL,
    UsuarioBaja NVARCHAR(255) NULL,
    Direccion NVARCHAR(255) NULL,
    Telefono NVARCHAR(50) NULL,
    Email NVARCHAR(255) NULL
);

CREATE TABLE Medico
(
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    Nombre NVARCHAR(255) NOT NULL,
    Activo BIT NOT NULL,
    FechaAlta DATETIME NOT NULL,
    UsuarioAlta NVARCHAR(255) NOT NULL,
    FechaModificacion DATETIME NULL,
    UsuarioModificacion NVARCHAR(255) NULL,
    FechaBaja DATETIME NULL,
    UsuarioBaja NVARCHAR(255) NULL,
    Matricula NVARCHAR(50) NOT NULL,
    Email NVARCHAR(255) NULL,
    Telefono NVARCHAR(50) NULL,
    TieneLinked BIT NOT NULL,
    LinkedInURL NVARCHAR(255) NULL
);

CREATE TABLE Servicio
(
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    Nombre NVARCHAR(255) NOT NULL,
    Activo BIT NOT NULL,
    FechaAlta DATETIME NOT NULL,
    UsuarioAlta NVARCHAR(255) NOT NULL,
    FechaModificacion DATETIME NULL,
    UsuarioModificacion NVARCHAR(255) NULL,
    FechaBaja DATETIME NULL,
    UsuarioBaja NVARCHAR(255) NULL,
    Email NVARCHAR(255) NULL,
    Observaciones NVARCHAR(MAX) NULL
);
