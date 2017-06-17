using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Reservations.Localization;
using Reservations.Business.Contracts;
using Reservations.DTOs;

namespace Reservations.Controllers
{
    [Route("api/values", Name = "ValuesRoute")]
    public class ValuesController : Controller
    {
        private readonly ILocalizationService _localizationService;
        private readonly IReservationConductor _reservationConductor;
        private readonly ReservationsContext _context;

        public ValuesController(ILocalizationService localizationService, 
            ReservationsContext context, 
            IReservationConductor reservationConductor)
        {
            _context = context;
            _localizationService = localizationService;
            _reservationConductor = reservationConductor;
        }

        // GET api/values
        /// <summary>
        /// This is an xml comment from the code
        /// </summary>
        /// <remarks>
        /// This is a remark comment on the method
        ///  
        /// * Note something here for implementation purposes *    
        /// 
        /// </remarks>
        [HttpGet]
        [ProducesResponseType(typeof(ReservationDetailsDto), 200)]
        public IActionResult Get()
        {
            var data = _context.ReservationDetails.Find(1);

            var reservationDetailsDto = new ReservationDetailsDto(data);

            var reservation = _reservationConductor.MakeReservationFor(DateTime.Today, "some title");
            
            return Ok(reservation);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]string value)
        {
            //if(String.IsNullOrEmpty(value))
            //{
            //    return BadRequest();
            //}

            //this will return 201 that is created
            //and add a location header that will point to the newley created attribute
            return CreatedAtRoute("ValuesRoute", new { id = 1 }, new { value = "created: "  + value });
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]string value)
        {
            return new NoContentResult();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return new NoContentResult();
        }
    }
}
