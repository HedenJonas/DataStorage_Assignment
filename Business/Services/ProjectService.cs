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
    private readonly ICustomerService _customerService = null!;
    private readonly IStatusTypeService _statusTypeService = null!;
    private readonly IUserService _userService = null!;
    private readonly IProductService _productService = null!;


    public async Task<Project> CreateProjectAsync(ProjectRegistrationForm form)
    {
        var entity = await _projectRepository.GetAsync(x => x.ProjectNumber == form.ProjectNumber);
        if (entity == null)
        {
            entity = ProjectFactory.Create(form);

            var customer = await _customerService.CreateCustomerAsync(form);
            var statusType = await _statusTypeService.CreateStatusTypeAsync(form);
            var user = await _userService.CreateUserAsync(form);
            var product = await _productService.CreateProductAsync(form);
            entity.CustomerId = customer.Id;
            entity.StatusID = statusType.Id;
            entity.UserId = user.Id;
            entity.ProductId = product.Id;
            entity = await _projectRepository.CreateAsync(entity);

            return ProjectFactory.Create(entity);

            //entity.CustomerId = _customerService.CreateCustomerAsync();
            //var customer = _customerService.CreateAsync(form.Customer); //får tillbaka customerID
            // entity.Customer.FirstName = _customerService.CreateAsync(form.Customer);
            //
            // project.customerId = customer.customerId

        }
        else
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
        var projectNumber = form.ProjectNumber;
        var entity = await _projectRepository.UpdateAsync(p => p.ProjectNumber == projectNumber, ProjectFactory.Create(form));
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
