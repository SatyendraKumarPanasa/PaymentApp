using System;
using System.Threading.Tasks;

namespace dCaf.Core
{
    public class CommandQueryService : ICommandQueryService
    {
        private readonly IServiceProvider serviceProvider;

        public CommandQueryService(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public async Task<TResponse> ExecuteCommandAsync<TInput, TCommand, TResponse>(TInput input, TCommand command)
        {
            var handler = ((IHandleCommandAsync<TInput, TCommand, TResponse>)serviceProvider.GetService(typeof(IHandleCommandAsync<TInput, TCommand, TResponse>)));
            return await handler.ExecuteAsync(input, command);
        }

        public async Task<TResponse> ExecuteCommandAsync<TCommand, TResponse>(TCommand command)
        {
            var handler = ((IHandleCommandAsync<TCommand, TResponse>)serviceProvider.GetService(typeof(IHandleCommandAsync<TCommand, TResponse>)));
            return await handler.ExecuteAsync(command);
        }

        public async Task ExecuteCommandAsync<TCommand>(TCommand command)
        {
            var handler = ((IHandleCommandAsync<TCommand>)serviceProvider.GetService(typeof(IHandleCommandAsync<TCommand>)));
            await handler.ExecuteAsync(command);
        }

        public TResponse ExecuteCommand<TCommand, TResponse>(TCommand command)
        {
            var handler = ((IHandleCommand<TCommand, TResponse>)serviceProvider.GetService(typeof(IHandleCommand<TCommand, TResponse>)));
            return handler.Execute(command);
        }

        public async Task<TResponse> ExecuteQueryAsync<TQuery, TResponse>(TQuery query)
        {
            var handler = ((IHandleQueryAsync<TQuery, TResponse>)serviceProvider.GetService(typeof(IHandleQueryAsync<TQuery, TResponse>)));
            return await handler.ExecuteAsync(query);
        }

        public async Task<TResponse> ExecuteQueryAsync<TResponse>()
        {
            var handler = ((IHandleQueryAsync<TResponse>)serviceProvider.GetService(typeof(IHandleQueryAsync<TResponse>)));
            return await handler.ExecuteAsync();
        }

        public TResponse ExecuteQuery<TQuery, TResponse>(TQuery query)
        {
            var handler = ((IHandleQuery<TQuery, TResponse>)serviceProvider.GetService(typeof(IHandleQuery<TQuery, TResponse>)));
            return handler.Execute(query);
        }
    }
}
