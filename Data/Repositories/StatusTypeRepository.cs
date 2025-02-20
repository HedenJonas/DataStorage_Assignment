using Data.Context;
using Data.Entites;
using Data.Interfaces;

namespace Data.Repositories;

public class StatusTypeRepository(DataContext context) : BaseRepository<StatusTypeEntity>(context), IStatusTypeRepository
{
    private readonly DataContext _context = context;
}
