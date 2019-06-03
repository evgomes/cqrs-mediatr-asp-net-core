using System.Threading;
using System.Threading.Tasks;
using CQRSMediatR.Domain.Models;
using CQRSMediatR.Domain.Repositories;
using MediatR;

namespace CQRSMediatR.Domain.Commands.Users
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Name = request.Name,
                Age = request.Age,
            };

            await _userRepository.AddAsync(user);
            await _unitOfWork.CompleteAsync();

            return user;
        }
    }
}