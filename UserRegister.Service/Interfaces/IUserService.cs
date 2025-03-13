using UserRegister.Service.DTOs.UserDtos;

namespace UserRegister.Service.Interfaces;

public interface IUserService
{
    Task<bool> DeleteAsync (long id);
    Task<UserForResultDto> GetByIdAsync(long id);
    Task<IEnumerable<UserForResultDto>> GetAllAsync();
    Task<UserForResultDto> UpdateAsync(long id, UserForUpdateDto dto); 
    Task<UserForResultDto> UpdateAsync(long id); 
    Task<UserForResultDto> CreateAsync(UserForCreationDto dto);
}
