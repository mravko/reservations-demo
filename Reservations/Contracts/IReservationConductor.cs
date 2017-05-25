using System;

namespace Reservations.Contracts
{
    public interface IReservationConductor
    {
        void MakeReservationFor(DateTime date);
    }
}