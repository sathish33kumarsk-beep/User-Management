using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Runtime.InteropServices;
using User_Management.Data;
using User_Management.DTOs;
using User_Management.Models;

namespace User_Management.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly PasswordHasher<User> _passwordHasher
            = new PasswordHasher<User>();

        public UserService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<UserDto>> GetUserDtosAsync()
        {
            return await _context.Users
                .AsNoTracking()
                .Select(u => new UserDto
                {
                    UId = u.Uid,
                    Username = u.Username,
                    Firstname = u.Firstname,
                    Middlename = u.Middlename,
                    Lastname = u.Lastname,
                    EmailAddress = u.EmailAddress,
                    RoleID = u.RoleID,
                    RoleName = u.Role.RoleName,
                    UserStatus = u.UserStatus
                })
                .ToListAsync();
        }
        public async Task<UserDto?> GetUserByIdAsync(int id)
        {
            return await _context.Users
            .AsNoTracking()
            .Where(u => u.Uid == id)
            .Select(u => new UserDto
            {
                UId = u.Uid,
                Username = u.Username,
                Firstname = u.Firstname,
                Middlename = u.Middlename,
                Lastname = u.Lastname,
                EmailAddress = u.EmailAddress,
                RoleID = u.RoleID,
                RoleName = u.Role.RoleName,
                UserStatus = u.UserStatus
            })
         .FirstOrDefaultAsync();
        }
        public async Task<UserDto> CreateUserAsync(CreateUserDto dto)
        {
            var role = await _context.Roles
                .FirstOrDefaultAsync(r =>
                    r.RoleID == dto.RoleID && r.Active == 1);
            if (role == null)
            {
                throw new ArgumentException(
                    "Invalid or inactive RoleId.");
            }
            var user = new User
            {
                Username = dto.Username,
                Firstname = dto.Firstname,
                Middlename = dto.Middlename,
                Lastname = dto.Lastname,
                EmailAddress = dto.EmailAddress,
                RoleID = dto.RoleID,
                UserStatus = dto.UserStatus
            };
            user.Password = _passwordHasher
                .HashPassword(user, dto.Password);
            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            return new UserDto
            {
                UId = user.Uid,
                Username = user.Username,
                Firstname = user.Firstname,
                Middlename = user.Middlename,
                Lastname = user.Lastname,
                EmailAddress = user.EmailAddress,
                RoleID = user.RoleID,
                UserStatus = user.UserStatus
            };

        }
        public async Task<bool> UpdateUserAsync(
            int id, UserDto dto)
        {
            var user = await _context.Users.FindAsync(id);
            if(user == null)
            {
                return false;
            }
            var roleExists = await _context.Roles.AnyAsync( r => r.RoleID == dto.RoleID && r.Active == 1);
            if (!roleExists)
            {
                throw new ArgumentException(
                    "Invalid or inactive RoleID");
            }
            user.Username = dto.Username;
            user.Firstname = dto.Firstname;
            user.Middlename = dto.Middlename;
            user.Lastname = dto.Lastname;
            user.EmailAddress = dto.EmailAddress;
            user.RoleID = dto.RoleID;
            user.UserStatus = dto.UserStatus;

            await _context.SaveChangesAsync();
            return true;


        }
        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return false;
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;

        }

       /* public Task<List<UserDto>> GetUserDtosAsync()
        {
            throw new NotImplementedException();
        }*/

      
        /*public Task<bool> UpdateUserAsync(int id, UserDto dto)
        {
            throw new NotImplementedException();
        }*/
    }
}
