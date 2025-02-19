using Business.Dtos;
using Business.Models;
using Data.Entites;

namespace Business.Factories;

public static class ProjectFactory
{
    public static ProjectRegistrationForm Create() => new();
    

    public static ProjectEntity Create(ProjectRegistrationForm form) => new()
    {
        ProjectNumber = form.ProjectNumber,
        Title = form.Title,
        Description = form.Description,
        StartDate = form.StartDate,
        EndDate = form.EndDate,
    };

    public static Project Create(ProjectEntity entity) => new()
    {
        Id = entity.Id,
        ProjectNumber = entity.ProjectNumber,
        Title = entity.Title,
        Description = entity.Description,
        StartDate = entity.StartDate,
        EndDate = entity.EndDate,
    };

    public static ProjectUpdateForm Create(Project project) => new()
    {
        Id = project.Id,
        ProjectNumber = project.ProjectNumber,
        Title = project.Title,
        Description = project.Description,
        StartDate = project.StartDate,
        EndDate = project.EndDate,
    };

    public static ProjectEntity Create(ProjectUpdateForm form) => new()
    {
        Id = form.Id,
        ProjectNumber = form.ProjectNumber,
        Title = form.Title,
        Description = form.Description,
        StartDate = form.StartDate,
        EndDate = form.EndDate,
    };
}
