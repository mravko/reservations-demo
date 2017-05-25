using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Reservations.Resources;
using Reservations.Localization;
using Reservations.Contracts;

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
        public IEnumerable<string> Get()
        {
            //throw new ReservationException("AAA");
            //throw new System.Exception("M");
            
            var data = _context.ReservationDetails.Find(1);
            _reservationConductor.MakeReservationFor(new DateTime());

            var a = _localizationService.TranslateDataKey("value1");
            return new string[] { a };
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
