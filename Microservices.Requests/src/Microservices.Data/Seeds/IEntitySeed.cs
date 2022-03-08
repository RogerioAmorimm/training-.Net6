using System.Threading;
using System.Threading.Tasks;

namespace Microservices.Infrastructure
{
    public interface IEntitySeed
    {
        Task ExecuteAsync(CancellationToken cancellationToken);
    }
}