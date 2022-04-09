using Microsoft.EntityFrameworkCore;
using PatintIS.Application.Contracts;
using PatintIS.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PatintIS.Persistence.Repositories
{
    public class PatintRepository : BaseRepository<Patint>, IPatintRepository
    {
        private readonly PatintDbContext _dbContext;

        public PatintRepository(PatintDbContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<IReadOnlyList<Patint>> GetAllPatintsAsync()
        {
            List<Patint> allPosts = new List<Patint>();
            allPosts = await _dbContext.patints.ToListAsync(); 
            return allPosts;
        }

        public async Task<Patint> GetPatintByIdAsync(Guid id)
        {
            Patint patint = new Patint();
            patint = await _dbContext.patints.FirstOrDefaultAsync(x => x.Id == id);
            return patint;
        }
    }
}
