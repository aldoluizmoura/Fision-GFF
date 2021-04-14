﻿// <auto-generated />
using System;
using GestaoFluxoFinanceiro.Data.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GestaoFluxoFinanceiro.Dados.Migrations
{
    [DbContext(typeof(ContextoBD))]
    [Migration("20210212201953_AjusteContratoPro")]
    partial class AjusteContratoPro
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("GestaoFluxoFinanceiro.Negocio.Models.Alunos", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("varchar(11)");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataSaida")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Matricula")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Telefone")
                        .HasColumnType("varchar(100)");

                    b.Property<int>("TipoSexo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("GestaoFluxoFinanceiro.Negocio.Models.Caixa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Codigo")
                        .HasColumnType("int");

                    b.Property<string>("Competencia")
                        .HasColumnType("varchar(9)");

                    b.Property<DateTime>("DataCaixa")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Despesa")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Receita")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SaldoFinal")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Caixa");
                });

            modelBuilder.Entity("GestaoFluxoFinanceiro.Negocio.Models.ContratoFinanceiroAluno", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AlunoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<int>("Desconto")
                        .HasColumnType("int");

                    b.Property<string>("Observacao")
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Vencimento")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId")
                        .IsUnique();

                    b.ToTable("ContratoFinanceiroAluno");
                });

            modelBuilder.Entity("GestaoFluxoFinanceiro.Negocio.Models.ContratoFinanceiroProfissional", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<int>("MargemLucro")
                        .HasColumnType("int");

                    b.Property<string>("Observacao")
                        .HasColumnType("varchar(100)");

                    b.Property<Guid>("ProfissionalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("QuantidadeAlunos")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorUnitario")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ProfissionalId")
                        .IsUnique();

                    b.ToTable("ContratoFinanceiroProfissional");
                });

            modelBuilder.Entity("GestaoFluxoFinanceiro.Negocio.Models.Endereco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AlunoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("varchar(8)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Complemento")
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId")
                        .IsUnique()
                        .HasFilter("[AlunoId] IS NOT NULL");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("GestaoFluxoFinanceiro.Negocio.Models.EnderecoProfissional", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Bairro")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Cep")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Cidade")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Complemento")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Estado")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Logradouro")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Numero")
                        .HasColumnType("varchar(100)");

                    b.Property<Guid>("ProfissionalId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProfissionalId")
                        .IsUnique();

                    b.ToTable("EnderecoProf");
                });

            modelBuilder.Entity("GestaoFluxoFinanceiro.Negocio.Models.Especialidades", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Codigo")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Especialidades");
                });

            modelBuilder.Entity("GestaoFluxoFinanceiro.Negocio.Models.MovimentoAluno", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AlunoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Competencia")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("DataPagamento")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataVencimento")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Desconto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Observacao")
                        .HasColumnType("varchar(300)");

                    b.Property<int>("Situacao")
                        .HasColumnType("int");

                    b.Property<int>("TipoMovimento")
                        .HasColumnType("int");

                    b.Property<int>("TipoPagamento")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorMensalidade")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorPagar")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorPago")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId");

                    b.ToTable("MovimentoAluno");
                });

            modelBuilder.Entity("GestaoFluxoFinanceiro.Negocio.Models.MovimentoProfissional", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Competencia")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("DataPagamento")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataVencimento")
                        .HasColumnType("datetime2");

                    b.Property<int>("MargemLucro")
                        .HasColumnType("int");

                    b.Property<string>("Observacao")
                        .HasColumnType("varchar(300)");

                    b.Property<Guid>("ProfissionalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Situacao")
                        .HasColumnType("int");

                    b.Property<int>("TipoMovimento")
                        .HasColumnType("int");

                    b.Property<int>("TipoPagamento")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorMensal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorPagar")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ProfissionalId");

                    b.ToTable("MovimentoProfissional");
                });

            modelBuilder.Entity("GestaoFluxoFinanceiro.Negocio.Models.Profissional", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("CPF")
                        .HasColumnType("varchar(100)");

                    b.Property<Guid?>("CodigoEspecialidadeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataSaida")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(100)");

                    b.Property<Guid>("EspecialidadeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Matricula")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Telefone")
                        .HasColumnType("varchar(100)");

                    b.Property<int>("TipoSexo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CodigoEspecialidadeId");

                    b.ToTable("Profissional");
                });

            modelBuilder.Entity("GestaoFluxoFinanceiro.Negocio.Models.ContratoFinanceiroAluno", b =>
                {
                    b.HasOne("GestaoFluxoFinanceiro.Negocio.Models.Alunos", "aluno")
                        .WithOne("ContratoFinanceiroAluno")
                        .HasForeignKey("GestaoFluxoFinanceiro.Negocio.Models.ContratoFinanceiroAluno", "AlunoId")
                        .IsRequired();

                    b.Navigation("aluno");
                });

            modelBuilder.Entity("GestaoFluxoFinanceiro.Negocio.Models.ContratoFinanceiroProfissional", b =>
                {
                    b.HasOne("GestaoFluxoFinanceiro.Negocio.Models.Profissional", "Profissionais")
                        .WithOne("ContratoFinanceiroProfissional")
                        .HasForeignKey("GestaoFluxoFinanceiro.Negocio.Models.ContratoFinanceiroProfissional", "ProfissionalId")
                        .IsRequired();

                    b.Navigation("Profissionais");
                });

            modelBuilder.Entity("GestaoFluxoFinanceiro.Negocio.Models.Endereco", b =>
                {
                    b.HasOne("GestaoFluxoFinanceiro.Negocio.Models.Alunos", "Aluno")
                        .WithOne("Endereco")
                        .HasForeignKey("GestaoFluxoFinanceiro.Negocio.Models.Endereco", "AlunoId");

                    b.Navigation("Aluno");
                });

            modelBuilder.Entity("GestaoFluxoFinanceiro.Negocio.Models.EnderecoProfissional", b =>
                {
                    b.HasOne("GestaoFluxoFinanceiro.Negocio.Models.Profissional", "profissionais")
                        .WithOne("Endereco")
                        .HasForeignKey("GestaoFluxoFinanceiro.Negocio.Models.EnderecoProfissional", "ProfissionalId")
                        .IsRequired();

                    b.Navigation("profissionais");
                });

            modelBuilder.Entity("GestaoFluxoFinanceiro.Negocio.Models.MovimentoAluno", b =>
                {
                    b.HasOne("GestaoFluxoFinanceiro.Negocio.Models.Alunos", "Aluno")
                        .WithMany("MovimentoAluno")
                        .HasForeignKey("AlunoId")
                        .IsRequired();

                    b.Navigation("Aluno");
                });

            modelBuilder.Entity("GestaoFluxoFinanceiro.Negocio.Models.MovimentoProfissional", b =>
                {
                    b.HasOne("GestaoFluxoFinanceiro.Negocio.Models.Profissional", "Profissionais")
                        .WithMany("MovimentoProfissional")
                        .HasForeignKey("ProfissionalId")
                        .IsRequired();

                    b.Navigation("Profissionais");
                });

            modelBuilder.Entity("GestaoFluxoFinanceiro.Negocio.Models.Profissional", b =>
                {
                    b.HasOne("GestaoFluxoFinanceiro.Negocio.Models.Especialidades", "CodigoEspecialidade")
                        .WithMany("Profissionais")
                        .HasForeignKey("CodigoEspecialidadeId");

                    b.Navigation("CodigoEspecialidade");
                });

            modelBuilder.Entity("GestaoFluxoFinanceiro.Negocio.Models.Alunos", b =>
                {
                    b.Navigation("ContratoFinanceiroAluno");

                    b.Navigation("Endereco");

                    b.Navigation("MovimentoAluno");
                });

            modelBuilder.Entity("GestaoFluxoFinanceiro.Negocio.Models.Especialidades", b =>
                {
                    b.Navigation("Profissionais");
                });

            modelBuilder.Entity("GestaoFluxoFinanceiro.Negocio.Models.Profissional", b =>
                {
                    b.Navigation("ContratoFinanceiroProfissional");

                    b.Navigation("Endereco");

                    b.Navigation("MovimentoProfissional");
                });
#pragma warning restore 612, 618
        }
    }
}
