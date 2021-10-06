using Microsoft.AspNetCore.Mvc;
using Reservation.Server.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Reservation.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]    
    public class ReservationController : ControllerBase
    {
        private readonly ReservationService ReservationService;
        public ReservationController(ReservationService _ReservationService)
        {
            ReservationService = _ReservationService;
        }
        // GET: api/<ContactController>
        [HttpGet]
        public async Task<ActionResult> GetReservations()
        {
            try
            {
                return Ok(await ReservationService.GetReservations());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("byId")]
        public async Task<ActionResult> GetReservationById(string Id)
        {
            try
            {
                return Ok(await ReservationService.GetReservationById(Guid.Parse(Id)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }        

        // POST api/<ContactController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Shared.Models.Reservation reservation)
        {
            try
            {
                await ReservationService.AddItem(reservation);
                return Ok("Saved successfully!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ContactController>/5
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] Shared.Models.Reservation reservation)
        {
            try
            {
                await ReservationService.UpdateItem(reservation);
                return Ok("Updated successfully!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ContactController>/5
        [HttpDelete]
        public async Task<ActionResult> Delete(Shared.Models.Reservation reservation)
        {
            try
            {
                await ReservationService.RemoveItem(reservation);
                return Ok("Removed successfully!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
