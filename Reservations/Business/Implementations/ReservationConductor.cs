using Reservations.Business.Contracts;
using Reservations.Database.Entities;
using Reservations.DTOs;
using Reservations.Exceptions;
using Reservations.Localization;
using System;

namespace Reservations.Implementations.Business
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

        public ReservationDetailsDto MakeReservationFor(DateTime date, string title)
        {
            if (string.IsNullOrEmpty(title))
                throw new ReservationException(_localizationService.TranslateSystemKey("TITLE_REQUIRED_FIELD"));

            using(var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var toSave = new ReservationDetails(date, title);
                    _context.ReservationDetails.Add(toSave);                    
                    _context.SaveChanges();
                    transaction.Commit();
                    return new ReservationDetailsDto(toSave);
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
