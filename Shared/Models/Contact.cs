using Reservation.Shared.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Reservation.Shared.Models
{
    public partial class Contact
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Name { get; set; }
        [GuidAttribute(ErrorMessage = "Contact Type is required")]
        public Guid ContactTypeID { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }        

        public ContactType ContactType { get; set; }
        [JsonIgnore]
        public IEnumerable<Reservation> Reservations { get; set; }
    }
}
