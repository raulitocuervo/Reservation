using Newtonsoft.Json;
using Reservation.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Client.Services
{
    public class ReservationsService
    {
        private readonly HttpClient HttpClient;
        public ReservationsService(HttpClient _HttpClient)
        {
            HttpClient = _HttpClient;
        }
        #region CONTACT TYPES
        public async Task<(List<ContactType> contactTypes, string Message)> GetContactTypes()
        {
            var results = await HttpClient.GetAsync("/api/ContactType");
            return results.IsSuccessStatusCode ? (await results.Content.ReadFromJsonAsync<List<ContactType>>(), results.ReasonPhrase) : (null, results.ReasonPhrase);
        }
        public async Task<(ContactType contactTypes, string Message)> GetContactTypeById(Guid id)
        {
            var results = await HttpClient.GetAsync($"/api/ContactType/byId?Id={id}");
            return results.IsSuccessStatusCode ? (await results.Content.ReadFromJsonAsync<ContactType>(), results.ReasonPhrase) : (null, results.ReasonPhrase);
        }
        public async Task<(ContactType contactTypes, string Message)> SaveContactType(ContactType contactType)
        {
            var results = contactType.Id.ToString().Length == 0 ? await HttpClient.PostAsJsonAsync("/api/ContactType", contactType) : await HttpClient.PutAsJsonAsync($"/api/ContactType", contactType);
            return results.IsSuccessStatusCode ? (await results.Content.ReadFromJsonAsync<ContactType>(), results.ReasonPhrase) : (null, results.ReasonPhrase);
        }
        public async Task<string> DeleteContactType(ContactType contactType)
        {
            var results = await HttpClient.SendAsync(new HttpRequestMessage(HttpMethod.Delete, "/api/ContactType") { Content = new StringContent(JsonConvert.SerializeObject(contactType), Encoding.UTF8, "application/json") });
            return await Task.FromResult(results.ReasonPhrase);
        }
        #endregion
        #region CONTACTS
        public async Task<(List<Contact> contacts, string Message)> GetContacts()
        {
            var results = await HttpClient.GetAsync("/api/Contact");
            return results.IsSuccessStatusCode ? (await results.Content.ReadFromJsonAsync<List<Contact>>(), results.ReasonPhrase) : (null, results.ReasonPhrase);
        }
        public async Task<(Contact contact, string Message)> GetContactById(Guid id)
        {
            var results = await HttpClient.GetAsync($"/api/Contact/byId?Id={id}");
            return results.IsSuccessStatusCode ? (await results.Content.ReadFromJsonAsync<Contact>(), results.ReasonPhrase) : (null, results.ReasonPhrase);
        }
        public async Task<(Contact contact, string Message)> SaveContactType(Contact contact)
        {
            var results = contact.Id.ToString().Length == 0 ? await HttpClient.PostAsJsonAsync("/api/Contact", contact) : await HttpClient.PutAsJsonAsync($"/api/Contact", contact);
            return results.IsSuccessStatusCode ? (await results.Content.ReadFromJsonAsync<Contact>(), results.ReasonPhrase) : (null, results.ReasonPhrase);
        }
        public async Task<string> DeleteContact(Contact contact)
        {
            var results = await HttpClient.SendAsync(new HttpRequestMessage(HttpMethod.Delete, "/api/Contact") { Content = new StringContent(JsonConvert.SerializeObject(contact), Encoding.UTF8, "application/json") });
            return await Task.FromResult(results.ReasonPhrase);
        }
        #endregion
        #region DESTINATIONS
        public async Task<(List<Destination> destinations, string Message)> GetDestinations()
        {
            var results = await HttpClient.GetAsync("/api/Destination");
            return results.IsSuccessStatusCode ? (await results.Content.ReadFromJsonAsync<List<Destination>>(), results.ReasonPhrase) : (null, results.ReasonPhrase);
        }
        public async Task<(Destination destination, string Message)> GetDestinationId(Guid id)
        {
            var results = await HttpClient.GetAsync($"/api/Destination/byId?Id={id}");
            return results.IsSuccessStatusCode ? (await results.Content.ReadFromJsonAsync<Destination>(), results.ReasonPhrase) : (null, results.ReasonPhrase);
        }
        public async Task<(Destination destination, string Message)> SaveDestination(Destination destination)
        {
            var results = destination.Id.ToString().Length == 0 ? await HttpClient.PostAsJsonAsync("/api/Destination", destination) : await HttpClient.PutAsJsonAsync($"/api/Contact", destination);
            return results.IsSuccessStatusCode ? (await results.Content.ReadFromJsonAsync<Destination>(), results.ReasonPhrase) : (null, results.ReasonPhrase);
        }
        public async Task<string> DeleteDestination(Destination destination)
        {
            var results = await HttpClient.SendAsync(new HttpRequestMessage(HttpMethod.Delete, "/api/Destination") { Content = new StringContent(JsonConvert.SerializeObject(destination), Encoding.UTF8, "application/json") });
            return await Task.FromResult(results.ReasonPhrase);
        }
        #endregion
        #region RESERVATIONS
        public async Task<(List<Reservation.Shared.Models.Reservation> reservations, string Message)> GetReservations()
        {
            var results = await HttpClient.GetAsync("/api/Reservation");
            return results.IsSuccessStatusCode ? (await results.Content.ReadFromJsonAsync<List<Reservation.Shared.Models.Reservation>>(), results.ReasonPhrase) : (null, results.ReasonPhrase);
        }
        public async Task<(Reservation.Shared.Models.Reservation destination, string Message)> GetReservationId(Guid id)
        {
            var results = await HttpClient.GetAsync($"/api/Reservation/byId?Id={id}");
            return results.IsSuccessStatusCode ? (await results.Content.ReadFromJsonAsync<Reservation.Shared.Models.Reservation>(), results.ReasonPhrase) : (null, results.ReasonPhrase);
        }
        public async Task<(Reservation.Shared.Models.Reservation destination, string Message)> SaveReservation(Destination reservations)
        {
            var results = reservations.Id.ToString().Length == 0 ? await HttpClient.PostAsJsonAsync("/api/Reservation", reservations) : await HttpClient.PutAsJsonAsync($"/api/Reservation", reservations);
            return results.IsSuccessStatusCode ? (await results.Content.ReadFromJsonAsync<Reservation.Shared.Models.Reservation>(), results.ReasonPhrase) : (null, results.ReasonPhrase);
        }
        public async Task<string> DeleteDestination(Reservation.Shared.Models.Reservation reservations)
        {
            var results = await HttpClient.SendAsync(new HttpRequestMessage(HttpMethod.Delete, "/api/Reservation") { Content = new StringContent(JsonConvert.SerializeObject(reservations), Encoding.UTF8, "application/json") });
            return await Task.FromResult(results.ReasonPhrase);
        }
        #endregion
    }
}
