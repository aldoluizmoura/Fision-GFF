CREATE VIEW View_Detalhamento_OutrosMovimentos AS
SELECT Descricao 'Descri�ao',
CASE WHEN TIPO = 1 THEN 'RECEITA' ELSE 'DESPESA' END 'Tipo',
Competencia 'Compet�ncia', Valor
FROM MovimentosOutros
