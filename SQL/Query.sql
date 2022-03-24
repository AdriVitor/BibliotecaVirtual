CREATE DATABASE [Biblioteca];

CREATE TABLE Livros
(
    [Id] INT NOT NULL IDENTITY(1, 1),
    [Titulo] NVARCHAR(60) NOT NULL,
    [Genero] NVARCHAR(40) NOT NULL,
    [Dt_Lancamento] DATE,

    CONSTRAINT [Pk_Livros] PRIMARY KEY ([Id])
);