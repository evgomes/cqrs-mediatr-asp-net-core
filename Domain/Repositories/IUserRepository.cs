using System.Collections.Generic;
using System.Threading.Tasks;
using CQRSMediatR.Domain.Models;

namespace CQRSMediatR.Domain.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
    }
}