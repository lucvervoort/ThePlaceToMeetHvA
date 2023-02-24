using Microsoft.EntityFrameworkCore;
using ThePlaceToMeet.Contracts.DTO;
using ThePlaceToMeet.Contracts.Interfaces;

namespace ThePlaceToMeet.Infrastructure.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly RepositoryDbContext _context;
        private readonly DbSet<Contracts.DTO.Reservation> _reservations;

        public ReservationRepository(RepositoryDbContext context)
        {
            _context = context;
            _reservations = _context.Reservaties;
        }

        public void Add(Reservation reservation)
        {
            _context.Add(reservation);
            _context.SaveChanges();
        }

        public IEnumerable<Contracts.DTO.Reservation> GetAll()
        {
            return _reservations
                .OrderBy(vr => vr.Dag)
                .ThenBy(vr => vr.BeginUur)
                .AsNoTracking()
                .ToList();
        }

        public Task<List<Reservation>> GetAllAsync()
        {
            return _reservations
                            .OrderBy(vr => vr.Dag)
                            .ThenBy(vr => vr.BeginUur)
                            .AsNoTracking()
                            .ToListAsync();
        }

        public Contracts.DTO.Reservation? GetById(int id)
        {
            return _reservations
                .SingleOrDefault(vr => vr.Id == id);
        }

        public Task<Reservation?> GetByIdAsync(int id)
        {
            return _reservations
                .SingleOrDefaultAsync(vr => vr.Id == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
