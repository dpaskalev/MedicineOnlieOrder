using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.VewModels;

namespace Services.Services.Interfaces
{
    public interface IPharmacyService
    {
        public Task<IEnumerable<PharmacyViewModel>> GetPharmaciesAsynk(string userId);

        public PharmacyViewModel GetPharmacyViewModel();

        public Task AddPharamcyToDatabaseAsync(PharmacyViewModel model, string userId);

        public Task<PharmacyDetailsViewModel> GetDetailsAsync(int id, string UserId);

        public Task RemoveFromDetailsAsync(int medicineId, int pharmacyId, string userId);

        public Task<PharmacyDeleteViewModel> GetPharmacyDeleteViewModel(int id, string userId);

        public Task Delete(int id, string userId);
    }
}
