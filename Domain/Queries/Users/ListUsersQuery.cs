using System.Collections.Generic;
using CQRSMediatR.Domain.Models;
using MediatR;

namespace CQRSMediatR.Domain.Queries.Users
{
    public class ListUsersQuery : IRequest<IEnumerable<User>>
    {
    }
}