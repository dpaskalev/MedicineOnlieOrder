using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.VewModels
{
    public class PharmacyDetailsViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Location { get; set; } = null!;

        public List<PharmacyMedicineViewModel> Medicines { get; set; } = new List<PharmacyMedicineViewModel>();
    }
}
