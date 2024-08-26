using Core.Entities;
namespace Application.Interfaces
{
    public interface IUserService
    {
        Task CreateUser(User user, CancellationToken cancellationToken);
        Task UpdateUser(User user, CancellationToken cancellationToken);
        Task DeleteUser(User user, CancellationToken cancellationToken);


    }
}
