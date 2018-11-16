using System;
using System.Linq;
using CSharpFunctionalExtensions;

namespace L7.Domain
{
    public interface IReadRepository<T>
        where T : Entity
    {
        Maybe<T> GetById(Guid id);

        IQueryable<T> GetAll();
    }
}