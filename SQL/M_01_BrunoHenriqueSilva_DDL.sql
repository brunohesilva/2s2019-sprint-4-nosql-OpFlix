CREATE DATABASE M_OpFlix;

USE M_OpFlix;

CREATE TABLE Usuarios(
	IdUsuario INT PRIMARY KEY IDENTITY NOT NULL
	,Nome VARCHAR(255) NOT NULL UNIQUE
	,Email VARCHAR(100) NOT NULL UNIQUE
	,Senha VARCHAR(255) NOT NULL
	,Permissao VARCHAR(255) 
);

CREATE TABLE Categorias(
	IdCategoria INT PRIMARY KEY IDENTITY NOT NULL 
	,Categoria VARCHAR(255) NOT NULL UNIQUE
);

CREATE TABLE PlataformasMidias(
	IdPlataformaMidia INT PRIMARY KEY IDENTITY NOT NULL
	,PlataformaMidia VARCHAR(255) NOT NULL UNIQUE
);


CREATE TABLE Lancamentos(
	IdLancamento INT PRIMARY KEY IDENTITY NOT NULL
	,Titulo VARCHAR(255) NOT NULL UNIQUE
	,Sinopse TEXT 
	,IdCategoria INT FOREIGN KEY REFERENCES Categorias(IdCategoria)
	,TempoDuracao VARCHAR(10) NOT NULL
	,FilmeSerie VARCHAR(255) 
	,DataLancamento DATE NOT NULL
);

CREATE TABLE OndeLanca(
	IdLancamento INT FOREIGN KEY REFERENCES Lancamentos(IdLancamento)	
	,IdPlataformaMidia INT FOREIGN KEY REFERENCES PlataformasMidias(IdPlataformaMidia)
);

ALTER TABLE Usuarios
  ADD CONSTRAINT Permissao
  DEFAULT ('CLIENTE') FOR Permissao;

CREATE TABLE Favoritos(
	IdUsuario INT FOREIGN KEY REFERENCES Usuarios (IdUsuario)
	,IdLancamento INT FOREIGN KEY REFERENCES Lancamentos (IdLancamento) 
)