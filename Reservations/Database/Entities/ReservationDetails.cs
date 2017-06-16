using System;

namespace Reservations.Database.Entities
{
    public class ReservationDetails
    {
        protected ReservationDetails()
        {

        }

        public ReservationDetails(DateTime date, string title)
        {
            Date = date;
            Title = title;
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
    }
}