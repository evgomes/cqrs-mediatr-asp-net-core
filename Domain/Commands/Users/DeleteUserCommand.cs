using CQRSMediatR.Domain.Communication;
using CQRSMediatR.Domain.Models;
using MediatR;

namespace CQRSMediatR.Domain.Commands.Users
{
    public class DeleteUserCommand : IRequest<Response<User>>
    {
        public int Id { get; private set; }

        public DeleteUserCommand(int id)
        {
            this.Id = id;
        }
    }
}