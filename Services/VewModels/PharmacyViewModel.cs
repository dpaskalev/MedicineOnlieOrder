using DataModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.VewModels
{
    public class PharmacyViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Pharmacy name is reqired")]
        [StringLength(ValidationConstants.PharmacyNameMaxLebnght, ErrorMessage = "Pharmacy name is too long")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Pharmacy name is reqired")]
        [StringLength(ValidationConstants.PharmacyLocationMaxLenght, ErrorMessage = "Location name is too long")]
        public string Location { get; set; } = null!;

        [Required]
        public bool IsPublisher { get; set; }
    }
}
