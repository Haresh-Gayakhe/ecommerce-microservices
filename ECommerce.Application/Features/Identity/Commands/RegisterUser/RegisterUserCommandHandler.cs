using ECommerce.Application.Interfaces;
using ECommerce.Domain.Constants;
using ECommerce.Domain.Entities;
using MediatR;

namespace ECommerce.Application.Features.Identity.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Guid>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBackgroundJobService _backgroundJobService;

        public RegisterUserCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher, 
            IUnitOfWork unitOfWork, IEmailService emailService, IBackgroundJobService backgroundJobService)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _unitOfWork = unitOfWork;
            _backgroundJobService = backgroundJobService;
        }

        public async Task<Guid> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userRepository.GetByEmailAsync(request.Email);

            if(existingUser != null)
            {
                throw new Exception("Email already exists.");
            }

            var user = new ApplicationUser
            {
                Id = Guid.NewGuid(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PasswordHash = _passwordHasher.Hash(request.Password),
                Role = Roles.Customer,
                CreatedOn = DateTime.UtcNow
            };

            await _userRepository.AddAsync(user);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            _backgroundJobService.EnqueueWelcomeEmail(user.Email, user.FirstName);

            return user.Id;
        }
    }
}
