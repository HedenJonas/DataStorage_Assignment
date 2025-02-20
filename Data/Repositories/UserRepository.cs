using Data.Context;
using Data.Entites;
using Data.Interfaces;

namespace Data.Repositories;

public class UserRepository(DataContext context) : BaseRepository<UserEntity>(context) , IUserRepository
{
    private readonly DataContext _context = context;
}