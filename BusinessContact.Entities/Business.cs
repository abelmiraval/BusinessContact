
using System.ComponentModel.DataAnnotations;

namespace BusinessContact.Entities
{
    public class Business : EntityBase
    {
        [Required]
        [StringLength(11)]
        public string Number { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int DistrictId { get; set; }
        public virtual District District { get; set; }

    }
}
