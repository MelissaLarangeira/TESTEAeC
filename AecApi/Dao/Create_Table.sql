Create database EnderecosDb

CREATE TABLE Usuarios (
    Id INT PRIMARY KEY IDENTITY,
    Nome NVARCHAR(100),
    Usuario NVARCHAR(50),
    Senha NVARCHAR(100)
);

CREATE TABLE Enderecos (
    Id INT PRIMARY KEY IDENTITY,
    Cep NVARCHAR(8),
    Logradouro NVARCHAR(100),
    Complemento NVARCHAR(100) NULL,
    Bairro NVARCHAR(50),
    Cidade NVARCHAR(50),
    UF NVARCHAR(2),
    Numero NVARCHAR(10),
    UsuarioId INT,
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id)
);
