﻿using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using BookDDD.Application.Contracts;
using BookDDD.Application.Extension;
using BookDDD.Application.Wrapper;
using BookDDD.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BookDDD.Core.Base;

namespace BookDDD.Infrastructure
{
    public class EfRepository<T> : IRepository<T> where T : class, IAggregateRoot
    {
        private readonly KavaabookDataContext dbContext;
        private readonly ISpecificationEvaluator specificationEvaluator;
        public EfRepository(KavaabookDataContext dbContext) :
            this(dbContext, SpecificationEvaluator.Default)
        {

        }
        public EfRepository(KavaabookDataContext dbContext, ISpecificationEvaluator specificationEvaluator)
        {
            this.dbContext = dbContext;
            this.specificationEvaluator = specificationEvaluator;
        }

        /// <inheritdoc/>
        public virtual async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            dbContext.Set<T>().Add(entity);

            await SaveChangesAsync(cancellationToken);

            return entity;
        }

        public async Task<PaginatedResult<T>> GetPagedResponseAsync(int pageNumber, int pageSize)
        {
            return await dbContext
                .Set<T>()
                .ToPaginatedListAsync(pageNumber, pageSize);
        }
       
        /// <inheritdoc/>
        public virtual async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            dbContext.Entry(entity).State = EntityState.Modified;

            await SaveChangesAsync(cancellationToken);
        }
        /// <inheritdoc/>
        public virtual async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
            dbContext.Set<T>().Remove(entity);

            await SaveChangesAsync(cancellationToken);
        }
        /// <inheritdoc/>
        public virtual async Task DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            dbContext.Set<T>().RemoveRange(entities);

            await SaveChangesAsync(cancellationToken);
        }
        /// <inheritdoc/>
        public virtual async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await dbContext.SaveChangesAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public virtual async Task<T> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken = default)
        {
            return await dbContext.Set<T>().FindAsync(id);
        }
        /// <inheritdoc/>
        public virtual async Task<T> GetBySpecAsync<Spec>(Spec specification, CancellationToken cancellationToken = default) where Spec : ISpecification<T>, ISingleResultSpecification
        {
            return await ApplySpecification(specification).FirstOrDefaultAsync(cancellationToken);
        }
        /// <inheritdoc/>
        public virtual async Task<TResult> GetBySpecAsync<TResult>(ISpecification<T, TResult> specification, CancellationToken cancellationToken = default)
        {
            return await ApplySpecification(specification).FirstOrDefaultAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public virtual async Task<List<T>> ListAsync(CancellationToken cancellationToken = default)
        {
            return await dbContext.Set<T>().ToListAsync(cancellationToken);
        }
        /// <inheritdoc/>
        public virtual async Task<List<T>> ListAsync(ISpecification<T> specification, CancellationToken cancellationToken = default)
        {
            var queryResult = await ApplySpecification(specification).ToListAsync(cancellationToken);

            return specification.PostProcessingAction == null ? queryResult : specification.PostProcessingAction(queryResult).ToList();
        }
        /// <inheritdoc/>
        public virtual async Task<List<TResult>> ListAsync<TResult>(ISpecification<T, TResult> specification, CancellationToken cancellationToken = default)
        {
            var queryResult = await ApplySpecification(specification).ToListAsync(cancellationToken);

            return specification.PostProcessingAction == null ? queryResult : specification.PostProcessingAction(queryResult).ToList();
        }

        /// <inheritdoc/>
        public virtual async Task<int> CountAsync(ISpecification<T> specification, CancellationToken cancellationToken = default)
        {
            return await ApplySpecification(specification, true).CountAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public virtual async Task<int> CountAsync(CancellationToken cancellationToken = default)
        {
            return await dbContext.Set<T>().CountAsync(cancellationToken);
        }

        /// <summary>
        /// Filters the entities  of <typeparamref name="T"/>, to those that match the encapsulated query logic of the
        /// <paramref name="specification"/>.
        /// </summary>
        /// <param name="specification">The encapsulated query logic.</param>
        /// <returns>The filtered entities as an <see cref="IQueryable{T}"/>.</returns>
        protected virtual IQueryable<T> ApplySpecification(ISpecification<T> specification, bool evaluateCriteriaOnly = false)
        {
            return specificationEvaluator.GetQuery(dbContext.Set<T>().AsQueryable(), specification, evaluateCriteriaOnly);
        }
        /// <summary>
        /// Filters all entities of <typeparamref name="T" />, that matches the encapsulated query logic of the
        /// <paramref name="specification"/>, from the database.
        /// <para>
        /// Projects each entity into a new form, being <typeparamref name="TResult" />.
        /// </para>
        /// </summary>
        /// <typeparam name="TResult">The type of the value returned by the projection.</typeparam>
        /// <param name="specification">The encapsulated query logic.</param>
        /// <returns>The filtered projected entities as an <see cref="IQueryable{T}"/>.</returns>
        protected virtual IQueryable<TResult> ApplySpecification<TResult>(ISpecification<T, TResult> specification)
        {
            if (specification is null) throw new ArgumentNullException("Specification is required");
            if (specification.Selector is null) throw new SelectorNotFoundException();

            return specificationEvaluator.GetQuery(dbContext.Set<T>().AsQueryable(), specification);
        }
    }
}
