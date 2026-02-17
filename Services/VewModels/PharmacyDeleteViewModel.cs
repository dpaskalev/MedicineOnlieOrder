using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.VewModels
{
    public class PharmacyDeleteViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string PublisherId { get; set; } = null!;

        [Required]
        public string PublisherName { get; set; } = null!;
    }
}
