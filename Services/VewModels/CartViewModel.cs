using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.VewModels
{
    public class CartViewModel
    {
        [Required]
        public int MedicineId { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public DateTime ExperationDate { get; set; }

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        public string TypeName { get; set; } = null!;

        public string? ImageURL { get; set; }
    }
}
