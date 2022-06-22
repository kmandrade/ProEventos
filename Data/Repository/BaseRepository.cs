using Data.Context;
using Data.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly EventoContext _context;
        protected readonly DbSet<T> _dbSet;
        

        public BaseRepository(EventoContext eventoContext)
        {
            _context=eventoContext;
            _dbSet=eventoContext.Set<T>();
        }

        public virtual async Task<T> Add(T entity)
        {
            try
            {
                _dbSet.Add(entity);
                await Save();
                return entity;
            }
            catch(Exception ex)
            {
                throw;
            }
            
        }
        public virtual async Task<T> Update(T entity)
        {
            try
            {

                var entry =  _context.Entry(entity);//acessa informacoes da entidade
                
                _dbSet.Attach(entity);//populando novamente o contexto
                                      //(a entidade é colocada novamente no contexto)
                entry.State =  EntityState.Modified;
                await Save();
                return entity;
            }
            catch(Exception ex)
            {
                throw;
            }
            
        }

        public virtual async Task DeleteById(int id)
        {

            try
            {
                var query = await _dbSet.FindAsync(new object[] { id });
                 _context.Remove(query);

            }
            catch(Exception ex)
            {
                throw;
            }

        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            try
            {
               
                return await _dbSet.ToListAsync();
              
            }catch(Exception ex)
            {
                throw;
            }

        }

        public virtual async Task<T> GetById(int id)
        {
            try
            {
                var query = await _dbSet.FindAsync(new object[] { id });
                return query;
            }
            catch(Exception ex)
            {
                throw;
            }
           
        }

        public virtual async Task<int> FindSQL(string query)
        {
            try
            {
                return await _context.Database.ExecuteSqlInterpolatedAsync($"{query}");
                //retornar todas as linhas do banco afetadas
            }catch(Exception ex)
            {
                throw;
            }
        }

        public async Task<int> Save()
        {
             return await _context.SaveChangesAsync();
        }

    }
}
