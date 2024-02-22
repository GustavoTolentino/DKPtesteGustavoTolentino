CREATE DATABASE BancoGustavoTolentinoDKP

USE BancoGustavoTolentinoDKP

CREATE TABLE Cliente(
    id INT IDENTITY(1,1) PRIMARY KEY,
    nome VARCHAR(250),
    idade INT
);
GO

CREATE TABLE Pedido(
	id INT IDENTITY(1,1) PRIMARY KEY,
	idCliente INT FOREIGN KEY REFERENCES Cliente(id),
	nome VARCHAR(250),
	valor NUMERIC(10,2),
);
GO

INSERT cliente(nome, idade)
VALUES ('Joao', 33)
GO

INSERT pedido(idCliente, nome, valor) 
VALUES (1, 'Fone sem fio', 30.2)
GO

SELECT * FROM cliente
SELECT * FROM pedido
