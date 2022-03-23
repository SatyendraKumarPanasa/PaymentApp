using System.Threading.Tasks;

namespace dCaf.Core
{
    public interface IExecuteDataRequestAsync<TInput1, TInput2, TOutput>
    {
        Task<TOutput> ExecuteAsync(TInput1 input1, TInput2 input2);
    }

    public interface IExecuteDataRequestAsync<TInput, TOutput>
    {
        Task<TOutput> ExecuteAsync(TInput input);
    }

    public interface IExecuteDataRequestAsync<TOutput>
    {
        Task<TOutput> ExecuteAsync();
    }
}
