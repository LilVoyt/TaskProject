namespace AuthService.Services.Interfaces
{
    public interface IRegisterUser
    {
        Task<string> Handle(RegisterUser.Request request);
    }
}