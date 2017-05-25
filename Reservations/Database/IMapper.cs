using Microsoft.EntityFrameworkCore;

namespace Reservations.Database
{
    public interface IMapper
    {
        void Map(ModelBuilder modelBuilder);
    }
}
