using System.Threading.Tasks;

namespace dCaf.Core
{
    public interface IHandleCommandAsync<TInput, TCommand, TResponse>
    {
        Task<TResponse> ExecuteAsync(TInput input, TCommand command);
    }

    public interface IHandleCommandAsync<TCommand, TResponse>
    {
        Task<TResponse> ExecuteAsync(TCommand command);
    }

    public interface IHandleCommandAsync<TCommand>
    {
        Task ExecuteAsync(TCommand command);
    }
}
