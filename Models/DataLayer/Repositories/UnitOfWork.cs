﻿using QuarterlySalesApp.Models.DomainModels;
using System.Collections;

namespace QuarterlySalesApp.Models.DataLayer.Repositories
{
    public class UnitOfWork: IUnitOfWork 
    {
        private readonly QuarterlyEmployeeSalesDbContext _context;
        private Hashtable _repositories;

        public UnitOfWork(QuarterlyEmployeeSalesDbContext context)
        {
            _context = context;
        }
        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            if (_repositories == null) _repositories = new Hashtable();

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(Repository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);

                _repositories.Add(type, repositoryInstance);
            }

            return (IRepository<TEntity>)_repositories[type];
        }
    }
}

