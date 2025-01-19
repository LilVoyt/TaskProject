namespace AuthService.Services.Interfaces
{
    public interface ILoginUser
    {
        Task<string> Handle(LoginUser.Request request);
    }
}