namespace dCaf.Core
{
    public interface IExecuteDataRequest<TInput, TOutput>
    {
        TOutput Execute(TInput input);
    }

    public interface IExecuteDataRequest<TInput1, TInput2, TOutput>
    {
        TOutput Execute(TInput1 input1, TInput2 input2);
    }
}
