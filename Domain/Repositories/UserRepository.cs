using System.Collections.Generic;
using System.Threading.Tasks;
using CQRSMediatR.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRSMediatR.Domain.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }
    }
}