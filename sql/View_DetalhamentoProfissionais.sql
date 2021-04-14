--CREATE VIEW View_Detalhamento_Receita_Profissionais AS
SELECT Profissional.Nome 'Profissional', 
	(ContratoFinanceiroProfissional.ValorUnitario * ContratoFinanceiroProfissional.QuantidadeAlunos)  'Valor total Mensal', 
	convert(varchar(10),ContratoFinanceiroProfissional.MargemLucro)+' %' 'Margem de Lucro', 
    MovimentoProfissional.ValorPago 'Valor Pago', 
	CASE WHEN MovimentoProfissional.Situacao = 1 THEN 'Quitado' ELSE 'Em Aberto' END 'Situação',
	MovimentoProfissional.Competencia
	  
	FROM Profissional

INNER JOIN ContratoFinanceiroProfissional ON ContratoFinanceiroProfissional.ProfissionalId = Profissional.Id
INNER JOIN MovimentoProfissional ON MovimentoProfissional.ProfissionalId = Profissional.Id
