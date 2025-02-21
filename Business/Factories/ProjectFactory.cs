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
        FirstName = entity.Customer.FirstName,
        LastName = entity.Customer.LastName,
        Email = entity.Customer.Email,
        Address = entity.Customer.Address,
        ProductName = entity.Product.ProductName,
        Rate = entity.Product.Rate,
        StatusName = entity.Status.StatusName,
        UserName = entity.User.UserName,
    };

    public static ProjectUpdateForm Create(Project project) => new()
    {
        Id = project.Id,
        ProjectNumber = project.ProjectNumber,
        Title = project.Title,
        Description = project.Description,
        StartDate = project.StartDate,
        EndDate = project.EndDate,
        FirstName = project.FirstName,
        LastName = project.LastName,
        Email = project.Email,
        Address = project.Address,
        ProductName = project.ProductName,
        Rate = project.Rate,
        StatusName = project.StatusName,
        UserName = project.UserName,
    };

    public static ProjectEntity Create(ProjectUpdateForm updateForm) => new()
    {
        Id = updateForm.Id,
        ProjectNumber = updateForm.ProjectNumber,
        Title = updateForm.Title,
        Description = updateForm.Description,
        StartDate = updateForm.StartDate,
        EndDate = updateForm.EndDate,
    };

    

    
    
    
}
