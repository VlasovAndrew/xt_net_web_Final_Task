using Dadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epam.FinalTask.WebPL.Helpers
{
    public static class AddressChecker
    {
        private static string key = "c93071bc407fc9429203292cea1fba8328c2a7d6";
        private static SuggestClient api = new SuggestClient(key);

        public static bool CheckAddress(string city, string street, string house) {
            if (city == "" || city == null) {
                return false;
            }
            if (street == "" || street == null) {
                return false;
            }
            if (house == "" || house == null) {
                return false;
            }

            var response = api.SuggestAddress($"{city} {street} {house}");
            if (response.suggestions.Count != 0)
            {
                var suggestion = response.suggestions[0];
                return suggestion.data.city == city && suggestion.data.street.Contains(street) && suggestion.data.house == house;
            }
            else 
            {
                return false;
            }
        }
    }
}