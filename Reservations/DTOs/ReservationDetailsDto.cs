using Reservations.Database.Entities;
using System;

namespace Reservations.DTOs
{
    public class ReservationDetailsDto
    {
        public ReservationDetailsDto(ReservationDetails reservationDetails)
        {
            Title = reservationDetails.Title;
            Date = reservationDetails.Date;
            Id = reservationDetails.Id;
        }

        public string Title { get; set; }
        public DateTime Date { get; set; }
        public int Id { get; set; }
    }
}
