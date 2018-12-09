using DotnetCore.Core.DomainServices.Generic;
using DotnetCore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotnetCore.Infrastructure.Generic
{
    public class EFRepository<T> : IRepository<T> where T : class
    {

        #region PRIVATE MEMBERS
        protected readonly ApplicationDbContext _dbContext;
        #endregion

        #region CONSTRUCTOR
        public EFRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        #region PRIVATE: Apply Specification
        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>().AsQueryable(), spec);
        }
        #endregion

        #region GENERIC: Create
        public virtual T Create(T entity)
        {
            try
            {
                _dbContext.Set<T>().Add(entity);
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region GENERIC: Update
        public void Update(T entity)
        {
            try
            {
                _dbContext.Entry(entity).State = EntityState.Modified;
                //   _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region GENERIC: Delete
        public void Delete(T entity)
        {
            try
            {
                _dbContext.Set<T>().Remove(entity);
                // _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region GENERIC: List All
        public IEnumerable<T> ListAll()
        {
            try
            {
                return _dbContext.Set<T>().AsEnumerable();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region GENERIC: List All By Specification
        public IEnumerable<T> List(ISpecification<T> spec)
        {
            try
            {
                return ApplySpecification(spec).AsEnumerable();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region GENERIC: Get By Id
        public T GetById(int id)
        {
            try
            {
                return _dbContext.Set<T>().Find(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region GENERIC: Get Single By Specification
        public T GetSingleBySpec(ISpecification<T> spec)
        {
            try
            {
                return List(spec).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region GENERIC: Count
        public int Count(ISpecification<T> spec)
        {
            try
            {
                return ApplySpecification(spec).Count();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
