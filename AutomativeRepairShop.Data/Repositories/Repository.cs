using AutomativeRepairShop.Core.Models;
using AutomativeRepairShop.Core.Repositories;
using AutomativeRepairShop.Data.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomativeRepairShop.Data.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;

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
            return _dbSet.Where(x=>x.DeleteDate !=null).ToList();
        }


    }
}
