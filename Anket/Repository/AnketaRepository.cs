using Anket.Common;
using Anket.Models;
using Anket.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Anket.Repository
{
    public class AnketaRepository : GenericRepository<Anketa>, IAnketRepository
    {
        public AnketaRepository(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
