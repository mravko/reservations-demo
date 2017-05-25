using Microsoft.EntityFrameworkCore;
using Reservations.Database.Entities;
using System.Reflection;
using System;
using System.Linq;
using Reservations.Database;

namespace Reservations
{
    public class ReservationsContext : DbContext
    {
        public ReservationsContext(DbContextOptions<ReservationsContext> options)
            : base(options)
        {
            
        }

        public DbSet<ReservationDetails> ReservationDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var types = Assembly.GetEntryAssembly().DefinedTypes.Where(x => x.Namespace == "Reservations.Database.Mappers"
                        && x.ImplementedInterfaces.Any(y => y == typeof(IMapper))
            );

            foreach (var mapper in types)
            {
                IMapper instanceOfMapper = (IMapper)Activator.CreateInstance(mapper.AsType());
                instanceOfMapper.Map(modelBuilder);
            }
        }
    }
}