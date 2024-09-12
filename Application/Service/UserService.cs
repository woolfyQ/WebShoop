using Core;
using Core.DTO;
using Core.Entities;

namespace Application.Service
{
    public class UserService : IApplicationService<User, UserDTO>
    {
        private readonly IRepository<User> _userRepository;
        
        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Create(UserDTO userDTO)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = userDTO.Name,
                Email = userDTO.Email,
                Password = userDTO.Password,
            };
            await _userRepository.Create(user,CancellationToken.None);
            return user;
        }
        public async Task <User> Update(Guid Id, UserDTO userDTO)
        {
            var user = await _userRepository.GetByIdAsync(Id, CancellationToken.None);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            
            user.Name = userDTO.Name;
            user.Email = userDTO.Email;
            user.Password = userDTO.Password;

            await _userRepository.Update(user,CancellationToken.None);
            return user;
        }
        public async Task<User> Delete(Guid Id)
        {
            var user = await _userRepository.GetByIdAsync(Id, CancellationToken.None);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            await _userRepository.Delete(user,CancellationToken.None);  
            return user;
        }
        


    }
}