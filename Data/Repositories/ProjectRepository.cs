using Data.Context;
using Data.Entites;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Data.Repositories;

public class ProjectRepository(DataContext context) : IProjectRepository
{
    private readonly DataContext _context = context;

    public async Task<ProjectEntity> CreateAsync(ProjectEntity entity)
    {
        if (entity == null)
            return null!;

        try
        {
            await _context.Projects.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error creating Project entity :: {ex.Message}");
            return null!;
        }
    }

    public async Task<IEnumerable<ProjectEntity>> GetAllAsync()
    {
        return await _context.Projects.ToListAsync();
    }

    public async Task<ProjectEntity> GetAsync(Expression<Func<ProjectEntity, bool>> expression)
    {
        if (expression == null)
            return null!;

        return await _context.Projects.FirstOrDefaultAsync(expression) ?? null!;
    }

    public async Task<ProjectEntity> UpdateAsync(ProjectEntity updatedEntity)
    {
        if (updatedEntity == null)
            return null!;

        try
        {
            var existingEntity = await _context.Projects.FirstOrDefaultAsync(x => x.Id == updatedEntity.Id);
            if (existingEntity == null)
                return null!;

            _context.Entry(existingEntity).CurrentValues.SetValues(updatedEntity);
            await _context.SaveChangesAsync();
            return existingEntity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error updating Project entity :: {ex.Message}");
            return null!;
        }
    }

    public async Task<bool> DeleteAsync(Expression<Func<ProjectEntity, bool>> expression)
    {
        if ( expression == null )
            return false;

        try
        {
            var existingEntity = await GetAsync(expression);
            if (existingEntity == null)
                return false;

            _context.Projects.Remove(existingEntity);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error deleting Project entity :: {ex.Message}");
            return false;
        }
    }
}
