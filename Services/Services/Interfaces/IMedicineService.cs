using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicineOnlieOrder.VewModels;
using Services.VewModels;

namespace Services.Services.Interfaces
{
    public interface IMedicineService
    {
        public Task<IEnumerable<MedicineIndexViewModel>> GetIndex(string userId);

        public Task<MedicineViewModel> GetAddModelAsynk();

        public Task AddMedicineAsync(MedicineViewModel viewModel, string userId);

        public Task<MedicineDetailsViewModel> GetDetails(int id);

        public Task AssignMedicineAsync(AddMedicineToPharmacyViewModel model);

        public Task<AddMedicineToPharmacyViewModel> GetAddMedcineToPharmacyViewModelAsync(int id, string userId);
    }
}
