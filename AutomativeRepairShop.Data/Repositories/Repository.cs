using AutomativeRepairShop.Core.Models;
using AutomativeRepairShop.Core.Repositories;
using AutomativeRepairShop.Data.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AutomativeRepairShop.Data.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private readonly DbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(ArsDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public TEntity Add(TEntity entity)
        {
            entity.CreateDate = DateTime.Now;
            _dbSet.Add(entity);
            return entity;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.Where(x=>x.DeleteDate==null).ToList();
        }

        public IEnumerable<TEntity> GetAll(string include)
        {
            return _dbSet.Where(x => x.DeleteDate == null).Include(include).ToList();
        }

        public IEnumerable<TEntity> GetAll(string includeOne, string includeTwo)
        {
            return _dbSet.Where(x => x.DeleteDate == null).Include(includeOne).Include(includeTwo).ToList();
        }
        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> expression)
        {
            return _dbSet.Where(expression).ToList();
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            entity.DeleteDate = DateTime.Now;
            Update(entity);
        }
        public void DeleteAllEntities(IEnumerable<TEntity> entities)
        {
            foreach (var item in entities)
            {
                Delete(item.Id);
            }
        }

        public void DeleteAllEntities(Expression<Func<TEntity, bool>> expression)
        {
            _dbSet.Where(expression).ForEachAsync(x => x.DeleteDate = DateTime.Now);
        }

        public TEntity Update(TEntity entity)
        {
            var temp = GetById(entity.Id);
            entity.UpdateDate = DateTime.Now;
            _context.Entry(temp).CurrentValues.SetValues(entity);
            return temp;
        }

        public TEntity GetById(int id)
        {
            return FirstOrDefault(x => x.Id == id);
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> expression)
        {
            return _dbSet.FirstOrDefault(expression);
        }

    }
}
