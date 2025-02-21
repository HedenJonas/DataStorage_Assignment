using Business.Dtos;
using Business.Models;
using Data.Entites;
using System.Linq.Expressions;

namespace Business.Interfaces;

public interface IProjectService
{
    Task<bool> CheckIfProjectExistsAsync(Expression<Func<ProjectEntity, bool>> expression);
    Task<Project> CreateProjectAsync(ProjectRegistrationForm form);
    Task<bool> DeleteProjectAsync(Expression<Func<ProjectEntity, bool>> expression);
    Task<IEnumerable<Project>> GetAllProjectsAsync();
    Task<Project> GetProjectAsync(Expression<Func<ProjectEntity, bool>> expression);
    Task<Project> UpdateProjectAsync(ProjectUpdateForm form);
}
