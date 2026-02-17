using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.VewModels
{
    public class MedicineDetailsViewModel
    {
        public string Name { get; set; } = null!;

        public DateTime ExperationDate { get; set; }

        public double Price { get; set; }

        public string Description { get; set; } = null!;

        public string? ImageURL { get; set; }

        public string TypeName { get; set; } = null!;
    }
}
