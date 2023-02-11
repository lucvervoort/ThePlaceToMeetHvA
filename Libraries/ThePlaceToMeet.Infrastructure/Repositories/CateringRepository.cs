using ThePlaceToMeet.Contracts.DTO;
using ThePlaceToMeet.Contracts.Interfaces;

namespace ThePlaceToMeet.Infrastructure.Repositories
{
    public class CateringRepository : ICateringRepository
    {
        private readonly RepositoryDbContext _context;

        public CateringRepository(RepositoryDbContext context)
        {
            _context = context;
        }

        public void Add(Catering catering)
        {
            _context.Add(catering);
            _context.SaveChanges();
        }

        public IEnumerable<Contracts.DTO.Catering> GetAll()
        {
            return _context.Caterings.OrderBy(t => t.Titel).ToList();
        }

        public Contracts.DTO.Catering GetBy(int id)
        {
            return _context.Caterings.SingleOrDefault(t => t.Id == id);
        }

        public void SaveChanges()
        {
            var saveCount = _context.SaveChanges();
        }
    }
}
