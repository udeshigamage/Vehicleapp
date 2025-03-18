using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Manufacture
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ManufactureId { get; set; }

        public string manufacturere_name{ get; set; }

        public virtual ICollection<Vehicle?> Vehicles { get; set; }
    }
}
