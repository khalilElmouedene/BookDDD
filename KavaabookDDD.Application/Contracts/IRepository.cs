﻿using Ardalis.Specification;
using BookDDD.Application.Wrapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookDDD.Core.Base;

namespace BookDDD.Application.Contracts
{
    public interface IRepository<T> : IRepositoryBase<T> where T : class, IAggregateRoot
  {
        Task<PaginatedResult<T>> GetPagedResponseAsync(int pageNumber, int pageSize);
  }

  // You can add your own interface or extend the one provided in Ardalis.Specification, which is designed
  // to work with specifications
  //
  //public interface IRepository
  //{
  //  Task<T> GetByIdAsync<T, TId>(TId id) where T : BaseEntity<TId>, IAggregateRoot;
  //  Task<T> GetAsync<T, TId>(ISpecification<T> spec) where T : BaseEntity<TId>, IAggregateRoot;

  //  Task<List<T>> ListAsync<T, TId>() where T : BaseEntity<TId>, IAggregateRoot;
  //  Task<List<T>> ListAsync<T, TId>(ISpecification<T> spec) where T : BaseEntity<TId>, IAggregateRoot;

  //  Task<int> CountAsync<T, TId>(ISpecification<T> spec) where T : BaseEntity<TId>, IAggregateRoot;

  //  Task<T> AddAsync<T, TId>(T entity) where T : BaseEntity<TId>, IAggregateRoot;
  //  Task UpdateAsync<T, TId>(T entity) where T : BaseEntity<TId>, IAggregateRoot;
  //  Task DeleteAsync<T, TId>(T entity) where T : BaseEntity<TId>, IAggregateRoot;
  //}
}
