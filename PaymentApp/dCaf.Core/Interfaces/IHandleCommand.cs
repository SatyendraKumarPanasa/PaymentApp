namespace dCaf.Core
{
    public interface IHandleCommand<TCommand, TResponse>
    {
        TResponse Execute(TCommand command);
    }
}
