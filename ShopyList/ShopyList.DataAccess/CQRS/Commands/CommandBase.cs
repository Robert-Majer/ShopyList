namespace ShopyList.DataAccess.CQRS.Commands
{
    public abstract class CommandBase<TParametr, TResult>
    {
        public TParametr Parameter { get; set; }

        public abstract Task<TResult> Execute(ShopyListStorageContext context);
    }
}