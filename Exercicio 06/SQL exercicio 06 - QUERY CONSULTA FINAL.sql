use ProdutosMercado
GO
-- EXERCICIO 06
-- FUNÇÃO QUE CALCULA / MONTA KITS DE ALIMENTOS E PRODUTOS DE LIMPESA.
SELECT 
	Alimento.Alimento as 'Alimento',
	Limpesa.[produto_limpesa] as 'Produto de Limpesa',
	cast(((Limpesa.[preco_produto_limpesa] + Alimento.[preco_alimento]) - ((Limpesa.[preco_produto_limpesa] + Alimento.[preco_alimento]) * 15 / 100)) as decimal(10, 2)) as 'Preço do Kit (c/ desconto)',
	(cast(((Limpesa.[preco_produto_limpesa] + Alimento.[preco_alimento]) - ((Limpesa.[preco_produto_limpesa] + Alimento.[preco_alimento]) * 15 / 100)) as decimal(10, 2)) - (Limpesa.[custo_produto_limpesa] + Alimento.[custo_alimento]))   as 'Lucro do Kit',
	Alimento.data_validade_alimento as 'Validade do Alimento',
	Limpesa.data_validade_produto_limpesa as 'Validade do Produto de Limpesa'
FROM (
		SELECT 
			ALIM.id_elemento_estoque as 'id_alimento',
			nome as 'Alimento',
			ELEM_ESTQ.preco as 'preco_alimento',
			ELEM_ESTQ.custo AS 'custo_alimento',
			(ELEM_ESTQ.preco - ELEM_ESTQ.custo) as 'lucro_alimento',
			convert(varchar, data_validade, 103) as 'data_validade_alimento',
			(DATEDIFF(day, GETDATE(), ALIM.data_validade)) as 'Vence em (dias)',
			ROW_NUMBER() OVER (ORDER BY (ELEM_ESTQ.preco - ELEM_ESTQ.custo) desc) AS ordcol
			FROM Elemento_Estoque as ELEM_ESTQ 
			INNER JOIN Estoque as ESTQ on ESTQ.id_elemento_estoque = ELEM_ESTQ.id
			INNER JOIN Alimento as ALIM on ALIM.id_elemento_estoque = ELEM_ESTQ.id
			WHERE (DATEDIFF(day, GETDATE(), ALIM.data_validade)) <= 5
		) AS Alimento
FULL OUTER JOIN  (
			SELECT 
			PROD_LIMP.id_elemento_estoque as 'id_produto_limpesa',
			nome as 'produto_limpesa',
			 convert(varchar, PROD_LIMP.data_validade, 103) as 'data_validade_produto_limpesa',
			ELEM_ESTQ.preco as 'preco_produto_limpesa',
			ELEM_ESTQ.custo as 'custo_produto_limpesa',
			(ELEM_ESTQ.preco - ELEM_ESTQ.custo) as 'lucro_produto_limpesa',
			AVG(PESQ_MERC.satisfacao)  as 'Media Avaliação', 
			ROW_NUMBER() OVER (ORDER BY (ELEM_ESTQ.preco - ELEM_ESTQ.custo) desc) AS ordcol
			FROM Elemento_Estoque as ELEM_ESTQ 
			INNER JOIN Estoque as ESTQ on ESTQ.id_elemento_estoque = ELEM_ESTQ.id
			INNER JOIN Produto_Limpesa as PROD_LIMP on PROD_LIMP.id_elemento_estoque = ELEM_ESTQ.id
			INNER JOIN Pesquisa_Mercado as PESQ_MERC on PESQ_MERC.id_produto_limpesa = PROD_LIMP.id
			group by PROD_LIMP.nome, PROD_LIMP.data_validade, ELEM_ESTQ.preco, ELEM_ESTQ.custo, PROD_LIMP.id_elemento_estoque
			having AVG(PESQ_MERC.satisfacao) >= 7
		) AS Limpesa
ON Alimento.ordcol = Limpesa.ordcol
where ([id_produto_limpesa] is not null and [id_alimento] is not null)