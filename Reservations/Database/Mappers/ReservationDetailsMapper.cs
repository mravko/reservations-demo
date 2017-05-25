﻿
using Microsoft.EntityFrameworkCore;
using Reservations.Database.Entities;

namespace Reservations.Database.Mappers
{
    public class ReservationDetailsMapper : IMapper
    {
        public void Map(ModelBuilder modelBuilder)
        {            
            modelBuilder.Entity<ReservationDetails>().ToTable("ReservationDetails");
        }
    }
}
