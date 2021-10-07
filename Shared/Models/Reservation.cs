using Reservation.Shared.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Shared.Models
{
    public partial class Reservation
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public DateTime Date { get; set; }
        [GuidAttribute (ErrorMessage ="Destination is required")]
        public Guid DestinationId { get; set; }
        [GuidAttribute (ErrorMessage ="Contact is required")]
        public Guid ContactId { get; set; }
        public int Ranking { get; set; }
        public bool Favorite { get; set; }

        public Destination Destination { get; set; }
        public Contact Contact { get; set; }
    }
}
