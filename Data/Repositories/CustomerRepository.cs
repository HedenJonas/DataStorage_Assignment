using Data.Context;
using Data.Entites;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Data.Repositories;

public class CustomerRepository(DataContext context) : BaseRepository<CustomerEntity>(context), ICustomerRepository
{
    private readonly DataContext _context = context;

    public override async Task<CustomerEntity> UpdateAsync(Expression<Func<CustomerEntity, bool>> expression, CustomerEntity updatedEntity)
    {
        if (updatedEntity == null)
            return null!;

        try
        {
            var existingEntity = await _context.Customers.FirstOrDefaultAsync(expression);

            //var existingEntity = await _dbSet.FirstOrDefaultAsync(expression) ?? null!;
            if (existingEntity == null)
                return null!;

            _context.Entry(existingEntity).CurrentValues.SetValues(updatedEntity);
            await _context.SaveChangesAsync();
            return existingEntity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error updating {nameof(ProjectEntity)} entity :: {ex.Message}");
            return null!;
        }
    }
}
