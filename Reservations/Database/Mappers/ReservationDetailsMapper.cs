
using Microsoft.EntityFrameworkCore;
using Reservations.Database.Entities;

namespace Reservations.Database.Mappers
{
    public class ReservationDetailsMapper : IMapper
    {
        public void Map(ModelBuilder modelBuilder)
        {            
            modelBuilder.Entity<ReservationDetails>()
                .ToTable("ReservationDetails")
                .HasKey(x=>x.Id);

            modelBuilder.Entity<ReservationDetails>().Property(t => t.Date).IsRequired();
        }
    }
}
