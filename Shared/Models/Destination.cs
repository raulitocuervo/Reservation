using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Reservation.Shared.Models
{
    public partial class Destination
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Name { get; set; }
        [JsonIgnore]
        public IEnumerable<Reservation> Reservations { get; set; }
    }
}
