USE M_OpFlix;

INSERT INTO Usuarios (Nome, Email, Senha, Permissao)
VALUES ('Erik', 'erik@email.com', '123456', 'ADMINISTARDOR');

INSERT INTO Usuarios (Nome, Email, Senha, Permissao)
VALUES ('Cassiana', 'cassiana@email.com', '123456', 'ADMINISTARDOR');

INSERT INTO Usuarios (Nome, Email, Senha, Permissao)
VALUES ('Helena', 'helena@email.com', '123456', 'ADMINISTARDOR');

INSERT INTO Usuarios (Nome, Email, Senha, Permissao)
VALUES ('Roberto', 'rob@email.com', '3110', 'CLIENTE');

INSERT INTO Categorias(Categoria)
VALUES ('A��o'), ('Aventura'), ('Sci-Fi'), ('Fantasia'), ('Anima��es'), ('Anime'), ('Com�dia'), ('Drama'), ('Horror'), ('Romanticas');

INSERT INTO Categorias (Categoria)
VALUES ('Document�rio'), ('Fic��o Cient�fica');

INSERT INTO Categorias (Categoria)
VALUES ('Terror');

INSERT INTO PlataformasMidias(PlataformaMidia)
VALUES ('Netflix'), ('Cinema'), ('Amazon');

INSERT INTO PlataformasMidias (PlataformaMidia)
VALUES ('Telecine Play'), ('HBO GO'), ('Google Play Filmes'), ('iTunes'), ('Now'), ('Crackle');

INSERT INTO PlataformasMidias (PlataformaMidia)
VALUES ('VHS');

INSERT INTO Lancamentos(Titulo, Sinopse, IdCategoria, TempoDuracao, FilmeSerie, DataLancamento)
VALUES ('Homem-Aranha: Longe de Casa', 'Peter Parker est� em uma viagem de duas semanas pela Europa, ao lado de seus amigos de col�gio', 2, '129m', 'FILME', '04/06/2019');

INSERT INTO Lancamentos(Titulo, Sinopse, IdCategoria, TempoDuracao, FilmeSerie, DataLancamento)
VALUES ('Era uma Vez em... Hollywood', 'No final da d�cada de 1960, Hollywood come�a a se transformar e o astro de TV Rick Dalton e seu dubl� Cliff Booth tentam acompanhar as mudan�as.', 7, '165m', 'FILME', '15/08/2019');

INSERT INTO Lancamentos(Titulo, Sinopse, IdCategoria, TempoDuracao, FilmeSerie, DataLancamento)
VALUES ('Velozes e Furiosos: Hobbs & Shaw', 'O corpulento policial Luke Hobbs se junta ao fora da lei Deckard Shaw para combater um terrorista geneticamente melhorado que tem for�a sobre-humana.', 1, '136m', 'FILME', '01/08/2019');

INSERT INTO Lancamentos(Titulo, Sinopse, IdCategoria, TempoDuracao, FilmeSerie, DataLancamento)
VALUES ('O Rei Le�o', 'Este desenho animado da Disney mostra as aventuras de um le�o jovem de nome Simba', 5, '118m', 'FILME', '08/07/1994');

INSERT INTO Lancamentos(Titulo, Sinopse, IdCategoria, TempoDuracao, FilmeSerie, DataLancamento)
VALUES ('La Casa De Papel - 3� Temporada', 'La casa de papel � uma s�rie de televis�o espanhola do g�nero de filmes de assalto. ', 2, '3T', 'S�RIE', '02/04/2017');

INSERT INTO Lancamentos(Titulo, Sinopse, IdCategoria, TempoDuracao, FilmeSerie, DataLancamento)
VALUES ('Avengers EndGame', 'Ap�s Thanos eliminar metade das criaturas vivas', 2, '200', 'FILME', '25/04/2019');

INSERT INTO Lancamentos(Titulo, Sinopse, IdCategoria, TempoDuracao, FilmeSerie, DataLancamento)
VALUES ('Avatar', 'No exuberante mundo alien�gena de Pandora vivem os Navi', 3, '162', 'FILME', '18/12/2009');

INSERT INTO Lancamentos(Titulo, Sinopse, IdCategoria, TempoDuracao, FilmeSerie, DataLancamento)
VALUES ('The Walking Dead', 'The Walking Dead conta a hist�ria de um pequeno grupo de sobreviventes de um apocalipse de zumbis', 8, '9T', 'S�RIE', '31/10/2010');

INSERT INTO Lancamentos(Titulo, Sinopse, IdCategoria, TempoDuracao, FilmeSerie, DataLancamento)
VALUES ('Game of Thrones', 'A s�rie se inicia quando Ned Stark � convidado para se tornar o principal conselheiro', 1, '8T', 'S�RIE', '17/04/2011');

UPDATE Lancamentos
SET	TempoDuracao = '200m' 
WHERE IdLancamento = 6;

UPDATE Usuarios
SET	Permissao = 'ADMINISTRADOR' 
WHERE IdUsuario = 3;

Select * From Lancamentos;

Select * From PlataformasMidias;

INSERT INTO OndeLanca (IdLancamento, IdPlataformaMidia)
VALUES (9, 5);
Select * From OndeLanca;

UPDATE Usuarios
SET	Senha = '654321' 
WHERE IdUsuario = 4;

INSERT INTO Usuarios (Nome, Email, Senha)
VALUES ('Rafael', 'rafael@email.com', '123456');

DELETE FROM Usuarios
WHERE IdUsuario = '8';

	




		
		
