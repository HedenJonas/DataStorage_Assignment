﻿using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Data.Entites;
using Data.Interfaces;

namespace Business.Services;

public class StatusTypeService(IStatusTypeRepository statusTypeRepository) : IStatusTypeService
{
    private readonly IStatusTypeRepository _statusTypeRepository = statusTypeRepository;

    public async Task<StatusTypeEntity> CreateStatusTypeAsync(ProjectRegistrationForm form)
    {
        var entity = await _statusTypeRepository.GetAsync(x => x.StatusName == form.StatusName);

        return entity ??= await _statusTypeRepository.CreateAsync(StatusTypeFactory.Create(form));

    }
}
