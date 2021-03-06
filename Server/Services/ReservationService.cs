using Microsoft.EntityFrameworkCore;
using Reservation.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservation.Server.Services
{
    public class ReservationService
    {
        #region PROPS
        private readonly DbDataContext context;
        public ReservationService(DbDataContext _context)
        {
            context = _context;
            Task.Run(async () => await InitializeData()).Wait();
        }
        #endregion
        #region General Items Management
        public async Task AddItem(object item)
        {
            await context.AddAsync(item);
            await context.SaveChangesAsync();
        }
        public async Task UpdateItem(object item)
        {
            context.Entry(item).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
        public async Task RemoveItem(object item)
        {
            context.Remove(item);
            await context.SaveChangesAsync();
        }
        #endregion
        #region ContactTypes
        public async Task<List<ContactType>> GetContactTypes() => await context.ContactTypes.AsQueryable().AsNoTracking().ToListAsync();
        public async Task<ContactType> GetContactTypeById(Guid Id) => await context.ContactTypes.FirstOrDefaultAsync(p => p.Id == Id);
        #endregion
        #region Contacts
        public async Task<List<Contact>> GetContacts() => await context.Contacts.Include(p=>p.ContactType).AsQueryable().AsNoTracking().ToListAsync();
        public async Task<Contact> GetContactById(Guid Id) => await context.Contacts.Include(p=>p.ContactType).FirstOrDefaultAsync(p => p.Id == Id);
        #endregion
        #region Destinations
        public async Task<List<Destination>> GetDestinations() => await context.Destinations.AsQueryable().AsNoTracking().ToListAsync();
        public async Task<Destination> GetDestinationById(Guid Id) => await context.Destinations.FirstOrDefaultAsync(p => p.Id == Id);
        #endregion
        #region Reservations
        public async Task<List<Shared.Models.Reservation>> GetReservations(int Order)
        {
            switch (Order)
            {
                case 0:
                    return await context.Reservations.Include(p => p.Contact).Include(p => p.Destination).OrderBy(p=>p.Date).AsQueryable().AsNoTracking().ToListAsync();
                case 1:
                    return await context.Reservations.Include(p => p.Contact).Include(p => p.Destination).OrderByDescending(p => p.Date).AsQueryable().AsNoTracking().ToListAsync();
                case 2:
                    return await context.Reservations.Include(p => p.Contact).Include(p => p.Destination).OrderBy(p => p.Destination.Name).AsQueryable().AsNoTracking().ToListAsync();
                case 3:
                    return await context.Reservations.Include(p => p.Contact).Include(p => p.Destination).OrderByDescending(p => p.Destination.Name).AsQueryable().AsNoTracking().ToListAsync();
                case 4:
                    return await context.Reservations.Include(p => p.Contact).Include(p => p.Destination).OrderByDescending(p => p.Ranking).AsQueryable().AsNoTracking().ToListAsync();
                default:
                    return await context.Reservations.Include(p => p.Contact).Include(p => p.Destination).AsQueryable().AsNoTracking().ToListAsync();
            }            
        }
        public async Task<Shared.Models.Reservation> GetReservationById(Guid Id) => await context.Reservations.Include(p => p.Contact).ThenInclude(p=>p.ContactType).Include(p => p.Destination).FirstOrDefaultAsync(p => p.Id == Id);
        #endregion
        #region DATA GENERATOR
        private async Task InitializeData()
        {
            if (!(await context.ContactTypes.AnyAsync())) {
                await context.ContactTypes.AddRangeAsync(
                    new ContactType
                    {
                        Name = "Sales Manager",
                        Contacts = new List<Contact>() { new Contact { Name = "Linda May", BirthDate = new DateTime(1985, 1, 7), PhoneNumber = "22652012" } }
                    },
                    new ContactType
                    {
                        Name = "Trip coordinator",
                        Contacts = new List<Contact>() { new Contact { Name = "Joseph Ross", BirthDate = new DateTime(1985, 5, 8), PhoneNumber = "641660" } }
                    },
                    new ContactType
                    {
                        Name = "President",
                        Contacts = new List<Contact>() { new Contact { Name = "Frederick Hulsz", BirthDate = new DateTime(1985, 9, 1), PhoneNumber = "142068" } }
                    });
                }
            if (!(await context.Destinations.AnyAsync()))
            {
                await context.Destinations.AddRangeAsync(
                    new Destination
                    {
                        Name = "Punta Cana"
                    },
                    new Destination
                    {
                        Name = "Coral Sea"
                    },
                    new Destination
                    {
                        Name = "China Walls"
                    });
            }
            await context.SaveChangesAsync();
        }
        #endregion
    }
}
