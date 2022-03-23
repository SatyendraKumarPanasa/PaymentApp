using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace dCaf.Core
{
    public interface ICommandQueryService
    {
        Task<TResponse> ExecuteCommandAsync<TInput, TCommand, TResponse>(TInput input, TCommand command);

        Task<TResponse> ExecuteCommandAsync<TCommand, TResponse>(TCommand command);

        Task ExecuteCommandAsync<TCommand>(TCommand command);

        TResponse ExecuteCommand<TCommand, TResponse>(TCommand command);

        Task<TResponse> ExecuteQueryAsync<TQuery, TResponse>(TQuery query);

        Task<TResponse> ExecuteQueryAsync<TResponse>();

        TResponse ExecuteQuery<TQuery, TResponse>(TQuery query);
    }
}
