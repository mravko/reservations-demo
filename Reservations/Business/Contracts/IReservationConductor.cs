using Reservations.DTOs;
using System;

namespace Reservations.Business.Contracts
{
    public interface IReservationConductor
    {
        ReservationDetailsDto MakeReservationFor(DateTime date, string title);
    }
}