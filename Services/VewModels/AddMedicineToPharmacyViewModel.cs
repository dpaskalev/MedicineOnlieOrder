using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.VewModels
{
    public class AddMedicineToPharmacyViewModel
    {
        [Required]
        public int MedicineId { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public List<PharmacyCheckBox> Pharmacies { get; set; } = new List<PharmacyCheckBox>();
    }
}
