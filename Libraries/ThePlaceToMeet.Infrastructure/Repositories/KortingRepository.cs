﻿using ThePlaceToMeet.Contracts.DTO;
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

        public void Add(Discount discount)
        {
            _context.Add(discount);
            _context.SaveChanges();
        }

        public IEnumerable<Contracts.DTO.Discount> GetAll()
        {
            return _context.Kortingen.OrderBy(t=>t.MinimumReservationsInAYear).ToList();
        }

        public Contracts.DTO.Discount? GetById(int id)
        {
            return _context.Kortingen
                .SingleOrDefault(vr => vr.Id == id);
        }

        public void SaveChanges()
        {
            var saveCount = _context.SaveChanges();
        }
    }
}
