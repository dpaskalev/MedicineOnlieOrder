using DataModels.Data;
using Microsoft.EntityFrameworkCore;
using Services.Services.Interfaces;
using Services.VewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class PharmacyService : IPharmacyService
    {
        private readonly ApplicationDbContext _context;

        public PharmacyService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PharmacyViewModel>> GetPharmaciesAsynk(string userId)
        {
            var modelsCollection = await _context.Pharmacies
                .Where(p => p.IsDeleted == false)
                .ToListAsync();

            var pharmacyViewModels = modelsCollection.Select(p => new PharmacyViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Location = p.Loctaion,
                IsPublisher = p.UserId == userId
            });

            return pharmacyViewModels;
        }
    }
}
