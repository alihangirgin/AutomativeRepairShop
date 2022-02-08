using AutomativeRepairShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AutomativeRepairShop.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Add(TEntity entity);
        IEnumerable<TEntity> GetAll();
        void Delete(int id);
        TEntity Update(TEntity entity);
        TEntity GetById(int id);
    }
}
