using AuthService.Repositories;
using Contracts;
using MassTransit;

namespace Consumers
{
    public class UserRoleChangedConsumer(IUserRepository userRepository) : IConsumer<UserRoleChanged>
    {
        public async Task Consume(ConsumeContext<UserRoleChanged> context)
        {
            var message = context.Message;

            await userRepository.UpdateUserRoleAsync(message.UserId, message.NewRole);
        }
    }
}
