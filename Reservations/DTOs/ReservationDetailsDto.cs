using Reservations.Database.Entities;
using Reservations.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservations.DTOs
{
    public class ReservationDetailsDto : LocalizationDto
    {
        public ReservationDetailsDto(ReservationDetails reservationDetails)
        {
            Title = reservationDetails.Title;
        }

        public string Title { get; set; }
    }
}
