using User_Management.DTOs;

namespace User_Management.Services
{
    public interface IUserService
    {
        Task<List<UserDto>> GetUserDtosAsync();
        Task<UserDto> GetUserByIdAsync(int id);
        Task<UserDto> CreateUserAsync(CreateUserDto dto);
        Task<bool> UpdateUserAsync(int  id, UserDto dto);
        Task<bool> DeleteUserAsync(int id);
    }
}
