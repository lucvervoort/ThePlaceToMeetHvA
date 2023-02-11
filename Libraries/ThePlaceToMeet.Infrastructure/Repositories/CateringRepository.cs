using Microsoft.EntityFrameworkCore;
using ThePlaceToMeet.Contracts.DTO;
using ThePlaceToMeet.Contracts.Interfaces;

namespace ThePlaceToMeet.Infrastructure.Repositories
{
    public class CateringRepository : ICateringRepository
    {
        private readonly RepositoryDbContext _context;
        private readonly DbSet<Contracts.DTO.Catering> _caterings;

        public CateringRepository(RepositoryDbContext context)
        {
            _context = context;
            _caterings = _context.Caterings;
        }

        public void Add(Catering catering)
        {
            _caterings.Add(catering);
            _context.SaveChanges();
        }

        public IEnumerable<Contracts.DTO.Catering> GetAll()
        {
            return _caterings.OrderBy(t => t.Titel).ToList();
        }

        public Contracts.DTO.Catering GetBy(int id)
        {
            return _caterings.SingleOrDefault(t => t.Id == id);
        }

        public void SaveChanges()
        {
            var saveCount = _context.SaveChanges();
        }
    }
}
