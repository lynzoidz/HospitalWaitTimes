using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HospitalWaitTimes.Helpers
{
    public static class Helper
    {
        public static string StripInvalidCharacters(string inputString)
        {
            try
            {
                return Regex.Replace(inputString, @"[^0-9A-Za-z ]", "", RegexOptions.None, TimeSpan.FromSeconds(1.5));
            }
            catch (RegexMatchTimeoutException)
            {
                return String.Empty;
            }
        }
    }
}
