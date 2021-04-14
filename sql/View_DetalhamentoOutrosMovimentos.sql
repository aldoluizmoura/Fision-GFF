CREATE VIEW View_Detalhamento_OutrosMovimentos AS
SELECT Descricao 'Descriçao',
CASE WHEN TIPO = 1 THEN 'RECEITA' ELSE 'DESPESA' END 'Tipo',
Competencia 'Competência', Valor
FROM MovimentosOutros
