using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IWareHouse<TEntity, TDto>
    {
        Task<TEntity> Create(TDto Tdto);
        Task<TEntity> Update(Guid Id, TDto Tdto);
        Task<TEntity> Delete(Guid Id);
        Task<TEntity> AddProduct(TDto ProductDTO, int Amount);


    }
}
