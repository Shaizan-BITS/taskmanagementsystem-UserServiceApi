using Microsoft.EntityFrameworkCore;
using UserServiceApi.Database;
using UserServiceApi.Dto.Request;
using UserServiceApi.Models;

namespace UserServiceApi.Service
{
    public class UserService
    {
        private readonly UserServiceDbContext _context;

        public UserService(UserServiceDbContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUserAsync(UserRegistrationRequestDto registrationModel)
        {
            // Check if the email already exists in the database
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == registrationModel.Email);
            if (existingUser != null)
            {
                return null;
            }

            var newUser = new User
            {
                UserId = Guid.NewGuid(), // Generate a new unique identifier for the user
                Username = registrationModel.Username,
                Email = registrationModel.Email,
                Password = registrationModel.Password, 
                FirstName = registrationModel.FirstName,
                LastName = registrationModel.LastName
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return newUser;
        }

        public async Task<User> GetUserAsync(Guid userId)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);
        }
    }

}
