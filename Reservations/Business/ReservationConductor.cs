using Reservations.Contracts;
using Reservations.Database.Entities;
using System;

namespace Reservations.Business
{
    public class ReservationConductor : IReservationConductor
    {
        private readonly ReservationsContext _context;

        public ReservationConductor(ReservationsContext context)
        {
            _context = context;
        }

        public void MakeReservationFor(DateTime date)
        {
            using(var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Add(new ReservationDetails(date));
                    _context.SaveChanges();
                    transaction.Commit();
                }
                catch(Exception ex)
                {
                    transaction.Rollback();
                }
            }
        }
    }
}
