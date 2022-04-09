using PatintIS.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PatintIS.Application.Contracts
{
    public interface IPatintRepository: IAsyncRepository<Patint>
    {
        Task<IReadOnlyList<Patint>> GetAllPatintsAsync();
        Task<Patint> GetPatintByIdAsync(Guid id);
    }
}
