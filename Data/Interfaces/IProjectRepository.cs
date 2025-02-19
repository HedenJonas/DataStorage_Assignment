using Data.Entites;
using System.Linq.Expressions;

namespace Data.Interfaces;

public interface IProjectRepository
{
    Task<ProjectEntity> CreateAsync(ProjectEntity entity);
    Task<IEnumerable<ProjectEntity>> GetAllAsync();
    Task<ProjectEntity> GetAsync(Expression<Func<ProjectEntity, bool>> expression);
    Task<ProjectEntity> UpdateAsync(ProjectEntity entity);
    Task<bool> DeleteAsync(Expression<Func<ProjectEntity, bool>> expression);
    Task<bool> ExistsAsync(Expression<Func<ProjectEntity, bool>> expression);
}
