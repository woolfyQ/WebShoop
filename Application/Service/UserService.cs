using Core;
using Core.Entities;


namespace Application.Service
{
    public class UserService 
    {
        private readonly IRepository<User> _userRepository;
        public UserService (IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        //public async Task<User> CreateUser(User user, CancellationToken cancellationToken)
        //{
        //    var user = _userRepository.Create(User, cancellationToken);
           
        //}
        


    }
}
