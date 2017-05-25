using System;

namespace Reservations.Business.Contracts
{
    public interface IReservationConductor
    {
        void MakeReservationFor(DateTime date);
    }
}