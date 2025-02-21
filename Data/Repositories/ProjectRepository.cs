using Data.Context;
using Data.Entites;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class ProjectRepository(DataContext context) : BaseRepository<ProjectEntity>(context), IProjectRepository
{
    //private readonly DataContext _context = context;
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
}
