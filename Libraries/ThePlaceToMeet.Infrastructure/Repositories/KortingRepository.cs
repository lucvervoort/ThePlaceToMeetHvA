using Microsoft.EntityFrameworkCore;
using ThePlaceToMeet.Contracts.DTO;
using ThePlaceToMeet.Contracts.Interfaces;

namespace ThePlaceToMeet.Infrastructure.Repositories
{
    public class KortingRepository : IDiscountRepository
    {
        private readonly RepositoryDbContext _context;
        private readonly DbSet<Contracts.DTO.Discount> _discounts;

        public KortingRepository(RepositoryDbContext context)
        {
            _context = context;
            _discounts = _context.Kortingen;
        }

        public void Add(Discount discount)
        {
            _discounts.Add(discount);
            _context.SaveChanges();
        }

        public IEnumerable<Contracts.DTO.Discount> GetAll()
        {
            return _discounts.OrderBy(t => t.MinimumReservationsInAYear).ToList();
        }

        public Contracts.DTO.Discount? GetById(int id)
        {
            return _discounts
                .SingleOrDefault(vr => vr.Id == id);
        }

        public void SaveChanges()
        {
            var saveCount = _context.SaveChanges();
        }
    }
}
