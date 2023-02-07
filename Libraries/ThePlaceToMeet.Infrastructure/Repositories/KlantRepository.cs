using Microsoft.EntityFrameworkCore;
using ThePlaceToMeet.Contracts.Interfaces;
using ThePlaceToMeet.Infrastructure;

namespace ThePlaceToMeet.Infrastructure.Repositories
{
    public class KlantRepository: ICustomerRepository
    {
        private readonly RepositoryDbContext _context;
        private readonly DbSet<Contracts.DTO.Customer> _klanten;

        public KlantRepository(RepositoryDbContext context)
        {
            _context = context;
            _klanten = _context.Klanten;
        }

        public List<Contracts.DTO.Customer> GetAll()
        {
            return _klanten.ToList();
        }

        public void Add(Contracts.DTO.Customer klant)
        {
            _klanten.Add(klant);
        }

        public Contracts.DTO.Customer GetByEmail(string email)
        {
            return _klanten.Include(t => t.Reservations).ThenInclude(t => t.Catering).Include(t => t.Reservations).ThenInclude(t => t.MeetingRoom).FirstOrDefault(t => t.Email == email);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
