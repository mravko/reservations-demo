using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservations.Localization
{
    public abstract class LocalizationDto
    {
           
    }

    public static class LocalizationExtensions
    {
        public static string Translate<T>(this T localizedDto, Func<T, string> predicate, string[] arguments = []) where T : LocalizationDto
        {   
            return "test";
        }
    }
}
