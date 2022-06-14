using Kol2_example.DataAccess;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Kol2_example.Models.DTO;

namespace Kol2_example.Services
{
    public class DbService : IDbService
    {
        private readonly MainDbContext _dbContext;
        public DbService(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<object> GetMusician(int idMusician)
        {
            return await _dbContext.Musicians.Include(m => m.Musician_Tracks)
                                             .Where(e => e.IdMusician == idMusician)
                                             .Select(e => new SomeSortOfMusician
                                             {
                                                 IdMusician = e.IdMusician,
                                                 FirstName = e.FirstName,
                                                 LastName = e.LastName,
                                                 Nickname = e.Nickname,
                                                 Tracks = e.Musician_Tracks.Select(t => t.Track).ToList()
                                             }).OrderBy(e => e.Tracks.Select(x => x.Duration)).ToListAsync();
           
        }

        public async Task<bool> RemoveMusician(int idMusician)
        {
            var exists = await _dbContext.Musicians.AnyAsync(m => m.IdMusician == idMusician);
                          
            /*var mus = await _dbContext.Musicians.Where(e => e.Musician_Tracks.Where(x => x.IdTrack.))*/
                                       

            if (exists)
            {
                return false;
            }
            return true;
        }
    }
}
