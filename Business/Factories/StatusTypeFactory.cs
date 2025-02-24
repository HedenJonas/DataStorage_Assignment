using Business.Dtos;
using Business.Models;
using Data.Entites;

namespace Business.Factories;

public static class StatusTypeFactory
{
    public static StatusTypeEntity Create(ProjectRegistrationForm form) => new()
    {
        StatusName = form.StatusName,
    };
    public static StatusType Create(StatusTypeEntity entity) => new()
    {
        Id = entity.Id,
        StatusName = entity.StatusName,
    };

    public static StatusTypeEntity Create(ProjectUpdateForm form) => new()
    {
        StatusName = form.StatusName
    };
}
