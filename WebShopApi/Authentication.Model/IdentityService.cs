namespace WebShop.API.Authentication.Model
{
    public interface IDentityService
    {
        Task<AuthenticationResult> Register(UserRequest request);
        Task<AuthenticationResult> SignIn(UserRequest request);





    }
}
