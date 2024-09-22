using Core.DTO;
using Core.Entities;

namespace Application.Interfaces
{
    public interface IApplicationService<TEntity, TDto>
    {
        Task<TEntity> Create(TDto dto);
        Task<TEntity> Update(Guid Id, TDto dto);
        Task<TEntity> Delete(Guid Id);
    }
}
