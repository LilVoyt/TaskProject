namespace AuthService.Services.Interfaces
{
    public interface IRegisterUser
    {
        Task<string> Handle(RegisterRequest request);
    }
}