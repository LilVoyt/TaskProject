using AuthService.Repositories;
using Contracts;
using MassTransit;

namespace AuthService.Consumers
{
    public class UserExistingCheckConsumer(IUserRepository userRepository) : IConsumer<UserExistingCheck>
    {
        public async Task Consume(ConsumeContext<UserExistingCheck> context)
        {
            var message = context.Message;

            var res = await userRepository.IsUserIdExistAsync(message.Id);

            await context.RespondAsync(new UserExistingCheckResponse(res));

        }
    }
}
