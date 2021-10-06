using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Shared.Models
{
    public partial class DbDataContext : DbContext
    {
        public DbDataContext()
        {

        }
        public DbDataContext(DbContextOptions<DbDataContext> options)
            : base(options)
        {
        }
        public virtual DbSet<ContactType> ContactTypes { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Destination> Destinations { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
    }
}