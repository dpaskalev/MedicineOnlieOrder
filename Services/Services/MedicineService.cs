using DataModels.Data;
using MedicineOnlieOrder.VewModels;
using Services.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class MedicineService : IMedicineService
    {
        private readonly ApplicationDbContext _context;

        public MedicineService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MedicineIndexViewModel>> GetIndex(string userId)
        {
            var Medicines = await _context.Medicines
                .Where(m => m.IsDeleted == false)
                .Select(m => new MedicineIndexViewModel
                {
                    Id = m.Id,
                    Name = m.MedicineName,
                    ExpeationDate = m.ExperationDate,
                    Price = m.Price,
                    Description = m.Description,
                    TypeName = m.MedicineType.MedicineTypeName,
                    ImageURL = m.ImageURL,
                    IsPublisher = m.UserId == userId,
                    HasBought = userId != null && _context.UsersMedicines.Any(um => um.MedicineId == m.Id && um.UserId == userId)
                })
                .ToListAsync();

            return Medicines;
        }
    }
}
