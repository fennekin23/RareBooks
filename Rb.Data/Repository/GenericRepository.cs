﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using Rb.Data.Entities;

namespace Rb.Data
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly RbDbContext m_dbContext;
        private readonly DbSet<T> m_table;

        public GenericRepository(RbDbContext dbContext)
        {

            m_dbContext = dbContext;
            m_table = m_dbContext.Set<T>();
        }

        public IQueryable<T> Items
        {
            get { return m_table; }
        }

        public void Add(T entity)
        {
            m_table.Add(entity);
            m_dbContext.SaveChanges();
        }

        public void Add(IEnumerable<T> entities)
        {
            m_table.AddRange(entities);
            m_dbContext.SaveChanges();
        }

        public T GetById(int id)
        {
            return m_table.Find(id);
        }

        public void Remove(T entity)
        {
            m_table.Remove(entity);
            m_dbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            m_table.AddOrUpdate(i => i.Id, entity);
            m_dbContext.SaveChanges();
        }
    }
}