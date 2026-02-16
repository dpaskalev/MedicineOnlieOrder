using DataModels.Data;
using MedicineOnlieOrder.VewModels;
using Services.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.VewModels;
using DataModels.Data.DataModels;

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

        public async Task<MedicineViewModel> GetAddModelAsynk()
        {
            var medicineTypes = await _context.MedicineTypes
                .Select(t => new TypeVewModel
                {
                    Id = t.Id,
                    Name = t.MedicineTypeName
                }).ToListAsync();

            var model = new MedicineViewModel
            {
                MedicineTypes = medicineTypes
            };

            return model;
        }

        public async Task AddMedicineAsync(MedicineViewModel viewModel, string userId)
        {
            var medicine = new Medicine
            {
                MedicineName = viewModel.Name,
                ExperationDate = viewModel.ExperationDate,
                Price = viewModel.Price,
                Description = viewModel.Description,
                MedicineTypeId = viewModel.Type,
                ImageURL = viewModel.ImageURL,
                UserId = userId
            };

            await _context.Medicines.AddAsync(medicine);
            await _context.SaveChangesAsync();
        }

        public async Task<MedicineDetailsViewModel> GetDetails(int id)
        {
            var medicine = await _context.Medicines.FindAsync(id);

            if (medicine == null || medicine.IsDeleted == true)
            {
                return null;
            }

            return new MedicineDetailsViewModel
            {
                Name = medicine.MedicineName,
                ExperationDate = medicine.ExperationDate,
                Price = medicine.Price,
                Description = medicine.Description,
                ImageURL = medicine.ImageURL,
                TypeName = GetMedicineTypeName(medicine.MedicineTypeId)
            };

            string GetMedicineTypeName(int id)
            {
                switch (id)
                {
                    case 1:
                        return "Pill";
                    case 2:
                        return "Syringe";
                    case 3:
                        return "Syrup";
                    case 4:
                        return "Powder";
                    case 5:
                        return "Liquid";
                    default:
                        return "Error";
                }
            }
        }
    }
}
