using Microsoft.AspNetCore.Mvc;
using Reservation.Server.Services;
using Reservation.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Reservation.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]    
    public class ContactTypeController : ControllerBase
    {
        private readonly ReservationService ReservationService;
        public ContactTypeController(ReservationService _ReservationService)
        {
            ReservationService = _ReservationService;
        }
        // GET: api/<ContactController>
        [HttpGet]
        public async Task<ActionResult> GetContactTypes()
        {
            try
            {
                return Ok(await ReservationService.GetContactTypes());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("byId")]
        public async Task<ActionResult> GetContactTypesById(string Id)
        {
            try
            {
                return Ok(await ReservationService.GetContactTypeById(Guid.Parse(Id)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }        

        // POST api/<ContactController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ContactType contacttype)
        {
            try
            {
                await ReservationService.AddItem(contacttype);
                return Ok("Saved successfully!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ContactController>/5
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] ContactType contacttype)
        {
            try
            {
                await ReservationService.UpdateItem(contacttype);
                return Ok("Updated successfully!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ContactController>/5
        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] ContactType contacttype)
        {
            try
            {
                await ReservationService.RemoveItem(contacttype);
                return Ok("Removed successfully!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
