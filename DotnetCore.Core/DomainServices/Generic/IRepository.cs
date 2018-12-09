﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCore.Core.DomainServices.Generic
{
    public interface IRepository<T> where T : class
    {
       // T GetById(int id);
       // T GetSingleBySpec(ISpecification<T> spec);
        IEnumerable<T> ListAll();
      //  IEnumerable<T> List(ISpecification<T> spec);
        T Create(T entity);
      //  void Update(T entity);
      //  void Delete(T entity);
       // int Count(ISpecification<T> spec);
    }
}
