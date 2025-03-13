using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UserRegister.Data.IRepositories;
using UserRegister.Domain.Entities;
using UserRegister.Service.DTOs.UserDtos;
using UserRegister.Service.Exceptions;
using UserRegister.Service.Interfaces;

namespace UserRegister.Service.Services;

public class UserService : IUserService
{
    private readonly IRepository<User> repository;
    private readonly IMapper mapper;

    public UserService(IRepository<User> repository, IMapper mapper)
    {
        this.mapper = mapper;
        this.repository = repository;
    }
    public async Task<UserForResultDto> CreateAsync(UserForCreationDto dto)
    {
        var user = await this.repository.SelectAll().
            FirstOrDefaultAsync(u => u.Email.Equals(dto.Email));
        if (user is not null) throw new CustomException(409, "User already exits"); 

        User mappedUser = this.mapper.Map<User>(dto);

        var result = await this.repository.InsertAsync(mappedUser);
        await this.repository.SaveChangeAsync();


        return this.mapper.Map<UserForResultDto>(result);
    }   

    public async Task<bool> DeleteAsync(long id)
    {
        var user = await this.repository.SelectByIdAsync(id);
        if (user is null) throw new CustomException(404, "User is not found");

        await this.repository.DeleteAsync(id);

        return await this.repository.SaveChangeAsync();
    }

    public async Task<IEnumerable<UserForResultDto>> GetAllAsync()
    {
        var users = await this.repository.SelectAll()
            .AsNoTracking()
            .OrderBy(u => u.Id)
            .ToListAsync();

        return this.mapper.Map<IEnumerable<UserForResultDto>>(users);
    }

    public async Task<UserForResultDto> GetByIdAsync(long id)
    {
        var user = await this.repository.SelectAll()
            .Where(u => u.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (user is null) throw new CustomException(404, "User is not found");

        return this.mapper.Map<UserForResultDto>(user);
    }

    public async Task<UserForResultDto> UpdateAsync(long id, UserForUpdateDto dto)
    {
        var user = await this.repository.SelectAll()
            .Where(u => u.Id == id)
            .FirstOrDefaultAsync();
        if (user is null) throw new CustomException(404, "User is not found");

        var mappedUser = this.mapper.Map(dto, user);
        await this.repository.SaveChangeAsync();

        return this.mapper.Map<UserForResultDto>(mappedUser);
    }

    public Task<UserForResultDto> UpdateAsync(long id)
    {
        throw new NotImplementedException();
    }
}
