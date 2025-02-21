﻿using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entites;
using Data.Interfaces;
using Data.Repositories;

namespace Business.Services;

public class UserService(IUserRepository userRepository) : IUserService
{
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<UserEntity> CreateUserAsync(ProjectRegistrationForm form)
    {
        var entity = await _userRepository.GetAsync(x => x.UserName == form.UserName);

        return entity ??= await _userRepository.CreateAsync(UserFactory.Create(form));

    }
}
