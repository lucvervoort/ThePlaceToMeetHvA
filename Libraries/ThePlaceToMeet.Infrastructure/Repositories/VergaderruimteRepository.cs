using Microsoft.EntityFrameworkCore;
using ThePlaceToMeet.Contracts.DTO;
using ThePlaceToMeet.Contracts.Interfaces;

namespace ThePlaceToMeet.Infrastructure.Repositories
{
    public class VergaderruimteRepository : IMeetingRoomRepository 
    {
        private readonly RepositoryDbContext _context;
        private readonly DbSet<Contracts.DTO.MeetingRoom> _vergaderruimtes;

        public VergaderruimteRepository(RepositoryDbContext context) {
            _context = context;
            _vergaderruimtes = _context.Vergaderruimtes;
        }

        public IEnumerable<Contracts.DTO.MeetingRoom> GetAll() {
            return _vergaderruimtes
                .OrderBy(vr => vr.Naam)
                .ThenBy(vr => vr.MaximumAantalPersonen)
                .AsNoTracking()
                .ToList();
        }

        public Task<List<MeetingRoom>> GetAllAsync()
        {
            return _vergaderruimtes
                            .OrderBy(vr => vr.Naam)
                            .ThenBy(vr => vr.MaximumAantalPersonen)
                            .AsNoTracking()
                            .ToListAsync();
        }

        public Contracts.DTO.MeetingRoom? GetById(int id) {
            return _vergaderruimtes
                .Include(vr => vr.Reservaties)
                .SingleOrDefault(vr => vr.Id == id);
        }

        public Task<MeetingRoom?> GetByIdAsync(int id)
        {
            return _vergaderruimtes
                .Include(vr => vr.Reservaties)
                .SingleOrDefaultAsync(vr => vr.Id == id);
        }

        public IEnumerable<Contracts.DTO.MeetingRoom> GetByMaxAantalPersonen(int maxAantalPersonen) {
            return _vergaderruimtes
                .Where(vr => vr.MaximumAantalPersonen >= maxAantalPersonen)
                .OrderBy(vr => vr.Naam)
                .ThenBy(vr => vr.MaximumAantalPersonen)
                .ToList();
        }

        public Task<List<MeetingRoom>> GetByMaxAantalPersonenAsync(int maxAantalPersonen)
        {
            return _vergaderruimtes
                .Where(vr => vr.MaximumAantalPersonen >= maxAantalPersonen)
                .OrderBy(vr => vr.Naam)
                .ThenBy(vr => vr.MaximumAantalPersonen)
                .ToListAsync();
        }

        public void SaveChanges() {
            _context.SaveChanges();
        }
    }
}
