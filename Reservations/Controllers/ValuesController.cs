using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Reservations.Localization;
using Reservations.Business.Contracts;
using Reservations.DTOs;

namespace Reservations.Controllers
{
    [Route("api/[controller]")]
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
        [HttpGet]
        public JsonResult Get()
        {
            var data = _context.ReservationDetails.Find(1);

            var reservationDetailsDto = new ReservationDetailsDto(data);

            var reservation = _reservationConductor.MakeReservationFor(DateTime.Today, "some title");
            
            return new JsonResult(reservation);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
