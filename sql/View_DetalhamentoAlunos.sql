--CREATE VIEW View_Detalhamento_Receita_Alunos AS
SELECT Alunos.Nome 'Aluno', 
	  ContratoFinanceiroAluno.Valor 'Mensalidade', 
	  convert(varchar(10),ContratoFinanceiroAluno.Desconto)+' %' 'Desconto', 
      MovimentoAluno.ValorPago 'Valor Pago', 
	  CASE WHEN MovimentoAluno.Situacao = 1 THEN 'Quitado' ELSE 'Em Aberto' END 'Situação',
	  MovimentoAluno.Competencia
	  
	  FROM Alunos

	INNER JOIN ContratoFinanceiroAluno ON ContratoFinanceiroAluno.AlunoId = Alunos.Id
	INNER JOIN MovimentoAluno ON MovimentoAluno.AlunoId = AlunoS.Id
	