using System;

namespace Reservations.Database.Entities
{
    public class ReservationDetails
    {
        public ReservationDetails(DateTime date)
        {
            Date = date;
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
    }
}