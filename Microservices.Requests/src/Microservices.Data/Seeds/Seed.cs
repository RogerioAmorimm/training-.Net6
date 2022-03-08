using Microservices.Data.Contexts;
using System.Threading.Tasks;

namespace Microservices.Infrastructure
{
    public class Seed
    {
        private IUnityOfWork _context;

        public Seed(IUnityOfWork context)
        {
            _context = context;
        }

        public void Execute() => Task.WaitAll(ExecuteAsync());

        private Task ExecuteAsync() =>
            Task.CompletedTask;
    }
}