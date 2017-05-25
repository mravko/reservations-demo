using Reservations.Business.Contracts;
using Reservations.Database.Entities;
using Reservations.Exceptions;
using Reservations.Localization;
using System;

namespace Reservations.Business
{
    public class ReservationConductor : IReservationConductor
    {
        private readonly ReservationsContext _context;
        private readonly ILocalizationService _localizationService;

        public ReservationConductor(ReservationsContext context, ILocalizationService localizationService)
        {
            _context = context;
            _localizationService = localizationService;
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
                    throw new ReservationException(
                        new System.Collections.Generic.List<string>() {
                        _localizationService.TranslateSystemKey("ERROR_WHILE_MAKING_RESERVATIONS")
                    });
                    
                }
            }
        }
    }
}
