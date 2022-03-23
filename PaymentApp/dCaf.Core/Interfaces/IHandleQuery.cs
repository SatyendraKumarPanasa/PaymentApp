using System.Threading.Tasks;

namespace dCaf.Core
{
    public interface IHandleQuery<TQuery, TResponse>
    {
        TResponse Execute(TQuery query);
    }
}
