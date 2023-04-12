using ShopyList.DataAccess.CQRS.Queries;

namespace ShopyList.DataAccess.CQRS
{
    public interface IQueryExecutor
    {
        Task<TResult> Excecute<TResult>(QueryBase<TResult> query);
    }
}