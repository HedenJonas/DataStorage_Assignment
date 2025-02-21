using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Data.Entites;
using Data.Interfaces;

namespace Business.Services;

public class CustomerService(ICustomerRepository customerRepository) : ICustomerService
{
    private readonly ICustomerRepository _customerRepository = customerRepository;

    public async Task<CustomerEntity> CreateCustomerAsync(ProjectRegistrationForm form)
    {
        var entity = await _customerRepository.GetAsync(x => x.Email == form.Email);
        if (entity == null)
        {
            var customerEntity = CustomerFactory.Create(form);
            return customerEntity = await _customerRepository.CreateAsync(customerEntity);
        }
        else
            return entity;
    }
}
