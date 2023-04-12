using ShopyList.DataAccess.CQRS.Commands;

namespace ShopyList.DataAccess.CQRS
{
    public class CommandExecutor : ICommandExecutor
    {
        private readonly ShopyListStorageContext context;

        public CommandExecutor(ShopyListStorageContext context)
        {
            this.context = context;
        }

        public Task<TResult> Execute<TParameters, TResult>(CommandBase<TParameters, TResult> command)
        {
            return command.Execute(this.context);
        }
    }
}