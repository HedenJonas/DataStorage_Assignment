using Business.Dtos;
using Business.Models;
using Data.Entites;

namespace Business.Interfaces;

public interface IStatusTypeService
{
    Task<StatusTypeEntity> CreateStatusTypeAsync(ProjectRegistrationForm form);
}
