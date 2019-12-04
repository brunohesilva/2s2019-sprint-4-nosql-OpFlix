

USE M_OpFlix;

SELECT * FROM Usuarios ORDER BY IdUsuario;
SELECT * FROM Categorias ORDER BY IdCategoria;
SELECT * FROM PlataformasMidias ORDER BY IdPlataformaMidia;
SELECT * FROM Lancamentos ORDER BY IdLancamento;
SELECT * FROM OndeLanca;
SELECT * FROM Favoritos;


CREATE PROCEDURE BuscaLinhas
@QuantidadesTuplas VARCHAR(200)
AS 
SELECT COUNT(*)
FROM Lancamentos
WHERE IdLancamento >= 1

EXECUTE BuscaLinhas '1';
DROP PROCEDURE BuscaLinhas;

SELECT L.*, C.*
	FROM Lancamentos L
	JOIN Categorias C
	ON L.IdCategoria = C.IdCategoria;

SELECT DATEDIFF(DAY , GETDATE(), '15/08/2077');

CREATE PROCEDURE BuscaCategorias
@QuantidadesTuplas VARCHAR(200)
AS 
SELECT COUNT(*)
FROM Lancamentos
WHERE IdCategoria >= 1

EXECUTE BuscaCategorias'1';
DROP PROCEDURE BuscaCategorias;