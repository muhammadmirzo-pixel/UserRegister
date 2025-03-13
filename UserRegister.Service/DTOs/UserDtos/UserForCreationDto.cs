﻿using System.ComponentModel.DataAnnotations;

namespace UserRegister.Service.DTOs.UserDtos;

public class UserForCreationDto
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}
