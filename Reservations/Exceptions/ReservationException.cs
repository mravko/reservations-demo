using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservations.Exceptions
{
    public class ReservationException : Exception
    {
        public List<string> UserMessages { get; set; } = new List<string>();

        public ReservationException(string message)
            : base(message)
        {
        }

        public ReservationException(List<string> userMessages)
            : base ()
        {
            UserMessages = userMessages;
        }
    }
}
