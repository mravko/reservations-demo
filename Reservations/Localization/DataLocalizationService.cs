using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;
using Reservations.Resources;

namespace Reservations.Localization
{
    public interface ILocalizationService
    {
        void SetupLocalization(HttpContext context);
        string TranslateSystemKey(string key);
        string TranslateDataKey(string key);
    }

    public class DataLocalizationService : ILocalizationService
    {
        private readonly IStringLocalizer<SharedResources> _localizer;
        public DataLocalizationService(IStringLocalizer<SharedResources> localizer)
        {
            _localizer = localizer;
        }   

        public void SetupLocalization(HttpContext context)
        {
            //called from middleware
            //nothing for now
        }

        public string TranslateSystemKey(string key)
        {
            return _localizer[key].Value;
        }

        public string TranslateDataKey(string key)
        {
            return "data_" + key;
        }
    }
}
