using Ardalis.Specification;
using BookDDD.Core.Base;

namespace BookDDD.Application.Contracts
{
    public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot
  {

  }
}
