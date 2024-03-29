﻿using Project.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        void Add(TEntity entity);
        void Update(TEntity entity);    
        void Delete(TEntity entity);    
        TEntity GetById(int id);
        TEntity Get(Expression<Func<TEntity, bool>> predicate=null);
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>>predicate=null);
    }
}
