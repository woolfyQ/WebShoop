//using Application.Interfaces;
//using Core.Entities;


//namespace Application.Service
//{
//    public class UserService : IUserService<User>
//    {
//        private readonly IUserService<User> _userRepository;
//        public UserService(IUserService<User> userRepository)
//        {
//            _userRepository = userRepository;
//        }
//        public async Task<User> CreateUser(User user, CancellationToken cancellationToken)
//        {
//            if (user == null)
//            {
//                throw new ArgumentNullException(nameof(user));
//            }
//            if (user.Email == null) 
//            {
//                throw new ArgumentException("Email is null",nameof(user.Email));
//            }
//            var existingUser = await _userRepository.GetByEmail(user.Email, cancellationToken) ?? throw new ArgumentException("Email has already been registered");
//            await _userRepository.CreateUser(user, cancellationToken);
//            return user;
//        }
//        public async Task<User> DeleteUser(User user, CancellationToken cancellationToken)
//        {
//            if (user == null)
//            {
//                throw new ArgumentException("User not found");
//            }
//            await _userRepository.DeleteUser(user,cancellationToken);
//            return user;
//        }
//        public async Task<User> UpdateUser(User user, CancellationToken cancellationToken)
//        {
//            if (user == null)
//            {
//                throw new ArgumentNullException(nameof(user));
//            }
//            await _userRepository.UpdateUser(user,cancellationToken);
//            return user;
//        }
//        public async Task <User> GetByEmail (string email, CancellationToken cancellationToken)
//        {
//            if (string.IsNullOrWhiteSpace(email))
//            {
//                throw new ArgumentException("Email cannot be null or empty", nameof(email));
//            }
//            var user = await _userRepository.GetByEmail(email, cancellationToken);
//            return user;
//        }
            
//    }
//}
