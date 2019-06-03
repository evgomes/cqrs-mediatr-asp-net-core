using System.Threading;
using System.Threading.Tasks;

namespace CQRSMediatR.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
        Task CompleteAsync(CancellationToken token);
    }
}