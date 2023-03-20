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

        public IEnumerable<Contracts.DTO.Catering> GetAll()
        {
            return _context.Caterings.OrderBy(t => t.Titel).ToList();
        }

        public Contracts.DTO.Catering GetBy(int id)
        {
            return _context.Caterings.SingleOrDefault(t => t.Id == id);
        }
    }
}
