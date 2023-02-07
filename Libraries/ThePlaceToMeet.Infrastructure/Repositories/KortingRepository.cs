using ThePlaceToMeet.Contracts.Interfaces;

namespace ThePlaceToMeet.Infrastructure.Repositories
{
    public class KortingRepository : IDiscountRepository
    {
        private readonly RepositoryDbContext _context;

        public KortingRepository(RepositoryDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Contracts.DTO.Discount> GetAll()
        {
            return _context.Kortingen.OrderBy(t=>t.MinimumReservationsInAYear).ToList();
        }
    }
}
