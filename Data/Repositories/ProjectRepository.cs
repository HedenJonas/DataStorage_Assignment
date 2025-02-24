using Data.Context;
using Data.Entites;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Data.Repositories;

public class ProjectRepository(DataContext context) : BaseRepository<ProjectEntity>(context), IProjectRepository
{
    public override async Task<IEnumerable<ProjectEntity>> GetAllAsync()
    {
        var entities = 
            await _context.Projects
            .Include(x => x.Customer)
            .Include(x => x.Product)
            .Include(x => x.Status)
            .Include(x => x.User)
            .ToListAsync();

        return entities;
    }

    public override async Task<ProjectEntity> GetAsync(Expression<Func<ProjectEntity, bool>> expression)
    {
        var entity = await _context.Projects
            .Include(p => p.Customer)
            .Include(p => p.Product)
            .Include(p => p.Status)
            .Include(p => p.User)
            .FirstOrDefaultAsync(expression);

        return entity ?? null!;
    }

    public override async Task<ProjectEntity> UpdateAsync(Expression<Func<ProjectEntity, bool>> expression, ProjectEntity updatedEntity)
    {
        if (updatedEntity == null)
            return null!;

        try
        {
            var existingEntity = await _context.Projects
            .Include(p => p.Customer)
            .Include(p => p.Product)
            .Include(p => p.Status)
            .Include(p => p.User)
            .FirstOrDefaultAsync(expression);

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

