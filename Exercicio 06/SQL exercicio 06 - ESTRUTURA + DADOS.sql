use master
GO
IF EXISTS(select * from sys.databases where name='ProdutosMercado')
DROP DATABASE ProdutosMercado
GO 
CREATE DATABASE ProdutosMercado
GO
use ProdutosMercado
GO
create table Elemento_Estoque (
	id int not null PRIMARY KEY identity,
	preco decimal(5,2) not null,
	cnpj_fabricante varchar(50) not null,
	custo decimal(5,2) not null
)
GO
create table Estoque (
	id int not null PRIMARY KEY identity,
	quantidade int not null,
	id_elemento_estoque int not null,
	FOREIGN KEY (id_elemento_estoque) REFERENCES Elemento_Estoque(id)
)
GO
create table Alimento (
	id int not null PRIMARY KEY identity,
	data_validade datetime not null,
	nome varchar(200) not null,
	id_elemento_estoque int not null,
	peso decimal(5,2) not null,
	FOREIGN KEY (id_elemento_estoque) REFERENCES Elemento_Estoque(id)
)
GO
create table Produto_Limpesa (
	id int not null PRIMARY KEY identity,
	data_validade datetime not null,
	volume decimal(5,2) not null,
	id_elemento_estoque int not null,
	nome varchar(200) not null,
	FOREIGN KEY (id_elemento_estoque) REFERENCES Elemento_Estoque(id)
)
GO
create table Pesquisa_Mercado (
	id int not null PRIMARY KEY identity,
	satisfacao int not null,
	instituto_pesquisa varchar(200) not null,
	id_produto_limpesa int not null,
	FOREIGN KEY (id_produto_limpesa) REFERENCES Produto_Limpesa(id)
)

-- INSERTS DOS ALIMENTOS ------------------------

-- alimento (Pipoca) idElemento = 1
INSERT INTO Elemento_Estoque VALUES (5.99, '11.111.111/0001-11', 2.99)
INSERT INTO Alimento VALUES (CAST(N'2019-02-18 00:00:00.000' AS DateTime), 'Pipoca', 1, 0.50)  
INSERT INTO Estoque VALUES (1, 1)

-- alimento (Arroz) idElemento = 2
INSERT INTO Elemento_Estoque VALUES (7.50, '11.111.111/0001-11', 3.99)
INSERT INTO Alimento VALUES (CAST(N'2019-03-01 00:00:00.000' AS DateTime), 'Arroz', 2, 0.500)  
INSERT INTO Estoque VALUES (1, 2)

-- alimento (Feijão) idElemento = 3
INSERT INTO Elemento_Estoque VALUES (6.25, '11.111.111/0001-11', 3.50)
INSERT INTO Alimento VALUES (CAST(N'2019-03-11 00:00:00.000' AS DateTime), 'Feijão', 3, 0.500)  
INSERT INTO Estoque VALUES (1, 3)

-- alimento (Macarrão) idElemento = 4
INSERT INTO Elemento_Estoque VALUES (2.50, '11.111.111/0001-11', 1.10)
INSERT INTO Alimento VALUES (CAST(N'2019-02-19 00:00:00.000' AS DateTime), 'Macarrão', 4, 1.0)  
INSERT INTO Estoque VALUES (1, 4)

-- alimento (Banana) idElemento = 5
INSERT INTO Elemento_Estoque VALUES (2.80, '11.111.111/0001-11', 1.30)
INSERT INTO Alimento VALUES (CAST(N'2019-02-21 00:00:00.000' AS DateTime), 'Banana', 5, 1.0)  
INSERT INTO Estoque VALUES (1, 5)

-- alimento (Mamão) idElemento = 6
INSERT INTO Elemento_Estoque VALUES (2.75, '11.111.111/0001-11', 1.00)
INSERT INTO Alimento VALUES (CAST(N'2019-02-20 00:00:00.000' AS DateTime), 'Mamão', 6, 1.0)  
INSERT INTO Estoque VALUES (1, 6)

-- alimento (Leite) idElemento = 7
INSERT INTO Elemento_Estoque VALUES (3.49, '22.222.222/0001-22', 1.50)
INSERT INTO Alimento VALUES (CAST(N'2019-03-25 00:00:00.000' AS DateTime), 'Leite', 7, 1.0)  
INSERT INTO Estoque VALUES (1, 7)

-- alimento (Nescau) idElemento = 8
INSERT INTO Elemento_Estoque VALUES (2.99, '22.222.222/0001-22', 1.45)
INSERT INTO Alimento VALUES (CAST(N'2019-06-01 00:00:00.000' AS DateTime), 'Nescau', 8, 1.0)  
INSERT INTO Estoque VALUES (1, 8)

-- alimento (Cuzcuz) idElemento = 9
INSERT INTO Elemento_Estoque VALUES (6.45, '22.222.222/0001-22', 3.89)
INSERT INTO Alimento VALUES (CAST(N'2020-06-01 00:00:00.000' AS DateTime), 'Cuzcuz', 9, 1.0)  
INSERT INTO Estoque VALUES (1, 9)

-- alimento (Óleo) idElemento = 10
INSERT INTO Elemento_Estoque VALUES (2.99, '22.222.222/0001-22', 1.45)
INSERT INTO Alimento VALUES (CAST(N'2019-02-17 00:00:00.000' AS DateTime), 'Óleo', 10, 1.0)  
INSERT INTO Estoque VALUES (1, 10)


-- INSERTS DOS PRODUTOS DE LIMPESA  ------------------------

-- Produto de Limpesa (Detergente Ype) idElemento = 11
INSERT INTO Elemento_Estoque VALUES (2.44, '22.222.222/0001-22', 1.75)
INSERT INTO Produto_Limpesa VALUES (CAST(N'2019-02-22 00:00:00.000' AS DateTime), 1.5, 11, 'Detergente YPE')  
INSERT INTO Estoque VALUES (1, 11)
INSERT INTO Pesquisa_Mercado VALUES (8, 'Instituto A', 1)
INSERT INTO Pesquisa_Mercado VALUES (6, 'Instituto B', 1)
INSERT INTO Pesquisa_Mercado VALUES (4, 'Instituto C', 1)
INSERT INTO Pesquisa_Mercado VALUES (7, 'Instituto D', 1)
INSERT INTO Pesquisa_Mercado VALUES (9, 'Instituto E', 1) 


-- Produto de Limpesa (Sabão em Pó) idElemento = 12
INSERT INTO Elemento_Estoque VALUES (5.99, '22.222.222/0001-22', 3.00)
INSERT INTO Produto_Limpesa VALUES (CAST(N'2019-03-28 00:00:00.000' AS DateTime), 1.5, 12, 'Sabão em Pó')  
INSERT INTO Estoque VALUES (1, 12)
INSERT INTO Pesquisa_Mercado VALUES (2, 'Instituto A', 2)
INSERT INTO Pesquisa_Mercado VALUES (4, 'Instituto B', 2)
INSERT INTO Pesquisa_Mercado VALUES (5, 'Instituto C', 2)
INSERT INTO Pesquisa_Mercado VALUES (8, 'Instituto D', 2)
INSERT INTO Pesquisa_Mercado VALUES (3, 'Instituto E', 2) 


-- Produto de Limpesa (Desinfetante) idElemento = 13
INSERT INTO Elemento_Estoque VALUES (3.50, '22.222.222/0001-22', 1.99)
INSERT INTO Produto_Limpesa VALUES (CAST(N'2019-02-28 00:00:00.000' AS DateTime), 1.5, 13, 'Desinfetante')  
INSERT INTO Estoque VALUES (1, 11)
INSERT INTO Pesquisa_Mercado VALUES (8, 'Instituto A', 3)
INSERT INTO Pesquisa_Mercado VALUES (9, 'Instituto B', 3)
INSERT INTO Pesquisa_Mercado VALUES (8, 'Instituto C', 3)
INSERT INTO Pesquisa_Mercado VALUES (8, 'Instituto D', 3)
INSERT INTO Pesquisa_Mercado VALUES (6, 'Instituto E', 3) 


-- Produto de Limpesa (Confort) idElemento = 14
INSERT INTO Elemento_Estoque VALUES (2.75, '22.222.222/0001-22', 1.75)
INSERT INTO Produto_Limpesa VALUES (CAST(N'2019-02-21 00:00:00.000' AS DateTime), 1.5, 14, 'Confort')  
INSERT INTO Estoque VALUES (1, 14)
INSERT INTO Pesquisa_Mercado VALUES (4, 'Instituto A', 4)
INSERT INTO Pesquisa_Mercado VALUES (2, 'Instituto B', 4)
INSERT INTO Pesquisa_Mercado VALUES (6, 'Instituto C', 4)
INSERT INTO Pesquisa_Mercado VALUES (9, 'Instituto D', 4)
INSERT INTO Pesquisa_Mercado VALUES (8, 'Instituto E', 4) 


-- Produto de Limpesa (Bombril) idElemento = 15
INSERT INTO Elemento_Estoque VALUES (1.49, '22.222.222/0001-22', 0.50)
INSERT INTO Produto_Limpesa VALUES (CAST(N'2019-02-19 00:00:00.000' AS DateTime), 1.5, 15, 'Bombril')  
INSERT INTO Estoque VALUES (1, 15)
INSERT INTO Pesquisa_Mercado VALUES (1, 'Instituto A', 5)
INSERT INTO Pesquisa_Mercado VALUES (3, 'Instituto B', 5)
INSERT INTO Pesquisa_Mercado VALUES (4, 'Instituto C', 5)
INSERT INTO Pesquisa_Mercado VALUES (2, 'Instituto D', 5)
INSERT INTO Pesquisa_Mercado VALUES (1, 'Instituto E', 5) 


-- Produto de Limpesa (Pasta de Dente) idElemento = 16
INSERT INTO Elemento_Estoque VALUES (4.99, '22.222.222/0001-22', 2.50)
INSERT INTO Produto_Limpesa VALUES (CAST(N'2019-02-28 00:00:00.000' AS DateTime), 1.5, 16, 'Pasta de Dente')  
INSERT INTO Estoque VALUES (1, 16)
INSERT INTO Pesquisa_Mercado VALUES (8, 'Instituto A', 6)
INSERT INTO Pesquisa_Mercado VALUES (7, 'Instituto B', 6)
INSERT INTO Pesquisa_Mercado VALUES (9, 'Instituto C', 6)
INSERT INTO Pesquisa_Mercado VALUES (7, 'Instituto D', 6)
INSERT INTO Pesquisa_Mercado VALUES (5, 'Instituto E', 6)
 


-- Produto de Limpesa (Veja Multiuso) idElemento = 17
INSERT INTO Elemento_Estoque VALUES (2.49, '22.222.222/0001-22', 1.80)
INSERT INTO Produto_Limpesa VALUES (CAST(N'2019-02-20 00:00:00.000' AS DateTime), 1.5, 17, 'Veja Multiuso')  
INSERT INTO Estoque VALUES (1, 17)
INSERT INTO Pesquisa_Mercado VALUES (9, 'Instituto A', 7)
INSERT INTO Pesquisa_Mercado VALUES (8, 'Instituto B', 7)
INSERT INTO Pesquisa_Mercado VALUES (9, 'Instituto C', 7)
INSERT INTO Pesquisa_Mercado VALUES (7, 'Instituto D', 7)
INSERT INTO Pesquisa_Mercado VALUES (10, 'Instituto E', 7) 


-- Produto de Limpesa (Pano de Chão) idElemento = 18
INSERT INTO Elemento_Estoque VALUES (1.99, '22.222.222/0001-22', 0.89)
INSERT INTO Produto_Limpesa VALUES (CAST(N'2019-04-01 00:00:00.000' AS DateTime), 1.5, 18, 'Pano de Chão')  
INSERT INTO Estoque VALUES (1, 18)
INSERT INTO Pesquisa_Mercado VALUES (5, 'Instituto A', 8)
INSERT INTO Pesquisa_Mercado VALUES (7, 'Instituto B', 8)
INSERT INTO Pesquisa_Mercado VALUES (9, 'Instituto C', 8)
INSERT INTO Pesquisa_Mercado VALUES (8, 'Instituto D', 8)
INSERT INTO Pesquisa_Mercado VALUES (3, 'Instituto E', 8) 


-- Produto de Limpesa (Cloro) idElemento = 19
INSERT INTO Elemento_Estoque VALUES (2.25, '22.222.222/0001-22', 1.15)
INSERT INTO Produto_Limpesa VALUES (CAST(N'2019-03-28 00:00:00.000' AS DateTime), 1.5, 19, 'Cloro')  
INSERT INTO Estoque VALUES (1, 19)
INSERT INTO Pesquisa_Mercado VALUES (7, 'Instituto A', 9)
INSERT INTO Pesquisa_Mercado VALUES (6, 'Instituto B', 9)
INSERT INTO Pesquisa_Mercado VALUES (8, 'Instituto C', 9)
INSERT INTO Pesquisa_Mercado VALUES (9, 'Instituto D', 9)
INSERT INTO Pesquisa_Mercado VALUES (5, 'Instituto E', 9) 


-- Produto de Limpesa (Sabão Liguido) idElemento = 20
INSERT INTO Elemento_Estoque VALUES (3.25, '22.222.222/0001-22', 1.50)
INSERT INTO Produto_Limpesa VALUES (CAST(N'2019-02-21 00:00:00.000' AS DateTime), 1.5, 20, 'Sabão Liguido')  
INSERT INTO Estoque VALUES (1, 20)
INSERT INTO Pesquisa_Mercado VALUES (3, 'Instituto A', 10)
INSERT INTO Pesquisa_Mercado VALUES (9, 'Instituto B', 10)
INSERT INTO Pesquisa_Mercado VALUES (7, 'Instituto C', 10)
INSERT INTO Pesquisa_Mercado VALUES (5, 'Instituto D', 10)
INSERT INTO Pesquisa_Mercado VALUES (2, 'Instituto E', 10) 

