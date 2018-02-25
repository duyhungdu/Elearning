using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LiteSchool.Entities;
using System.Linq.Expressions;
using LiteSchool.Core.Queries;
using LiteSchool.Core.Messages;

namespace LiteSchool.Core.IRepository
{
    public interface IRepository<TId, TEntity, TDto>
    {
        TEntity Add(TEntity entity);
        void Delete(TId id);
        void Delete(List<TId> ids);
        void Edit(TEntity entity);

        IList<TEntity> FindAll();
        TEntity FindById(TId id);
        IList<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
    }
}
