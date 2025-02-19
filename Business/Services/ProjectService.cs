using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entites;
using Data.Interfaces;
using System.Linq.Expressions;

namespace Business.Services;

public class ProjectService(IProjectRepository projectRepository) : IProjectService
{
    private readonly IProjectRepository _projectRepository = projectRepository;


    public async Task<Project> CreateProjectAsync(ProjectRegistrationForm form)
    {
        var entity = await _projectRepository.GetAsync(x => x.ProjectNumber == form.ProjectNumber);
        entity ??= await _projectRepository.CreateAsync(ProjectFactory.Create(form));

        return ProjectFactory.Create(entity);
    }

    public async Task<IEnumerable<Project>> GetAllProjectsAsync()
    {
        var entities = await _projectRepository.GetAllAsync();
        var projects = entities.Select(ProjectFactory.Create);
        return projects ?? [];
    }

    public async Task<Project> GetProjectAsync(Expression<Func<ProjectEntity, bool>> expression)
    {
        var entity = await _projectRepository.GetAsync(expression);
        var project = ProjectFactory.Create(entity);
        return project ?? null!;
    }

    public async Task<Project> UpdateProjectAsync(ProjectUpdateForm form)
    {
        var entity = await _projectRepository.UpdateAsync(ProjectFactory.Create(form));
        var project = ProjectFactory.Create(entity);
        return project ?? null!;
    }

    public async Task<bool> DeleteProjectAsync(Expression<Func<ProjectEntity, bool>> expression)
    {
        var result = await _projectRepository.DeleteAsync(expression);
        return result;
    }

    public async Task<bool> CheckIfProjectExistsAsync(Expression<Func<ProjectEntity, bool>> expression)
    {
        return await _projectRepository.ExistsAsync(expression);
    }
}
