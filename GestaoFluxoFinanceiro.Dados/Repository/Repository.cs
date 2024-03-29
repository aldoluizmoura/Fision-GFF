﻿using GestaoFluxoFinanceiro.Data.Contexto;
using GestaoFluxoFinanceiro.Negocio.Interfaces;
using GestaoFluxoFinanceiro.Negocio.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GestaoFluxoFinanceiro.Dados.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly ContextoBD Db;
        protected readonly DbSet<TEntity> Dbset;

        public Repository(ContextoBD contexto)
        {
            Db = contexto;
            Dbset = contexto.Set<TEntity>();
        }
        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await Dbset.AsNoTracking().Where(predicate).ToListAsync();
        }
        public async Task<TEntity> ObterPorId(Guid id)
        {
            return await Dbset.FindAsync(id);
        }
        public async Task<List<TEntity>> ObterTodos()
        {
            return await Dbset.ToListAsync();
        }
        public async Task Adicionar(TEntity entity)
        {
            Dbset.Add(entity);
            await SaveChanges();
        }

        public async Task Atualizar(TEntity entity)
        {
            Dbset.Update(entity);
            await SaveChanges();
        }
        public virtual async Task Remover(Guid id)
        {
            Dbset.Remove(new TEntity { Id = id });
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }
        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
