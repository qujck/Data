namespace Qujck.Data.Commands
{
    public interface IDataCommandHandler<TCommand> where TCommand : IDataCommand
    {
        void Handle(TCommand command);
    }
}
