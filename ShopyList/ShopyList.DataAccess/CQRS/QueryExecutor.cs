using ShopyList.DataAccess.CQRS.Queries;

namespace ShopyList.DataAccess.CQRS
{
    public class QueryExecutor : IQueryExecutor
    {
        private readonly ShopyListStorageContext context;

        public QueryExecutor(ShopyListStorageContext context)
        {
            this.context = context;
        }

        public Task<TResult> Execute<TResult>(QueryBase<TResult> query)
        {
            return query.Execute(this.context);
        }
    }
}