﻿using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entites;
using Data.Interfaces;
using System.Linq.Expressions;

namespace Business.Services;
public class ProjectService(IProjectRepository projectRepository, 
                            ICustomerService customerService,
                            IStatusTypeService statusTypeService,
                            IUserService userService,
                            IProductService productService,
                            ICustomerRepository customerRepository,
                            IProductRepository productRepository,
                            IStatusTypeRepository statusTypeRepository,
                            IUserRepository userRepository) : IProjectService
{
    private readonly IProjectRepository _projectRepository = projectRepository;
    private readonly ICustomerService _customerService = customerService;
    private readonly IStatusTypeService _statusTypeService = statusTypeService;
    private readonly IUserService _userService = userService;
    private readonly IProductService _productService = productService;
    private readonly ICustomerRepository _customerRepository = customerRepository;
    private readonly IProductRepository _productRepository = productRepository;
    private readonly IStatusTypeRepository _statusTypeRepository = statusTypeRepository;
    private readonly IUserRepository _userRepository = userRepository;


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
        if(entity != null)
        {
            var project = ProjectFactory.Create(entity);
            return project;
        }
        
        return null!;
    }

    public async Task<Project> UpdateProjectAsync(ProjectUpdateForm form)
    {
        var entity = await _projectRepository.GetAsync(x => x.ProjectNumber == form.ProjectNumber);
        var project = ProjectFactory.Create(entity);

        var customerEntity = CustomerFactory.Create(form);
        customerEntity.Id = entity.CustomerId;
        var updatedCustomer = await _customerRepository.UpdateAsync(x => x.Email == project.Email, customerEntity);

        var productEntity = ProductFactory.Create(form);
        productEntity.Id = entity.ProductId;
        var updatedProduct = await _productRepository.UpdateAsync(x => x.ProductName == project.ProductName, productEntity);

        var statusTypeEntity = StatusTypeFactory.Create(form);
        statusTypeEntity.Id = entity.StatusID;
        var updatedStatusType = _statusTypeRepository.UpdateAsync(x => x.StatusName == project.StatusName, statusTypeEntity);

        var userEntity = UserFactory.Create(form);
        userEntity.Id = entity.StatusID;
        await _userRepository.UpdateAsync(x => x.UserName == project.UserName, userEntity);

        entity.Title = form.Title;
        entity.Description = form.Description;
        entity.StartDate = form.StartDate;
        entity.EndDate = form.EndDate;
        
        var updatedEntity = await _projectRepository.UpdateAsync(p => p.ProjectNumber == form.ProjectNumber, entity);
        var updatedProject = ProjectFactory.CreateUpdate(updatedEntity);
        return updatedProject ?? null!;
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
