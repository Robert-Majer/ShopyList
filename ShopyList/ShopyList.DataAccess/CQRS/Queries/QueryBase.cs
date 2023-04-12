namespace ShopyList.DataAccess.CQRS.Queries
{
    public abstract class QueryBase<TResult>
    {
        public abstract Task<TResult> Execute(ShopyListStorageContext context);
    }
}