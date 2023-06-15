using ShopyList.DataAccess.CQRS.Queries;

namespace ShopyList.DataAccess.CQRS
{
    public interface IQueryExecutor
    {
        Task<TResult> Execute<TResult>(QueryBase<TResult> query);
    }
}