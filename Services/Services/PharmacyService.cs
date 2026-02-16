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

        public async Task<PharmacyDetailsViewModel> GetDetailsAsync(int id, string UserId)
        {
            var pharmacy = await _context.Pharmacies
                .Include(p => p.PharmaciesMedicines)
                .ThenInclude(pm => pm.Medicine)
                .Where(m => m.IsDeleted == false)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (pharmacy == null)
            {
                return null;
            }

            var pharmacyDetailsViewModel = new PharmacyDetailsViewModel
            {
                Id = pharmacy.Id,
                Name = pharmacy.Name,
                Location = pharmacy.Loctaion,
                Medicines = pharmacy.PharmaciesMedicines
                .Where(m => m.Medicine.IsDeleted == false)
                .Select(pm => new PharmacyMedicineViewModel
                {
                    Id = pm.Medicine.Id,
                    PharmacyId = id,
                    Name = pm.Medicine.MedicineName,
                    IsPublisher = pharmacy.UserId == UserId
                }).ToList()
            };

            return pharmacyDetailsViewModel;
        }
    }
}
