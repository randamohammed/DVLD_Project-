using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DVLDSluotion
{
    public class clsVildation
    {
        public static bool ValidateEmail(string emailAddress)
        {
            var pattern = @"^[a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";

            var regex = new Regex(pattern);

            return regex.IsMatch(emailAddress);
        }

        private static bool ValidateInteger(string number)
        {
            var Petten = @"^[0-9]*$";

            var regex = new Regex(Petten);
            return regex.IsMatch(number);
        }

        private static bool ValidateFloat(string number)
        {
            var Petten = @"^[0-9]*(?:\.[0-9]*)?$";

            var regex = new Regex(Petten);
            return regex.IsMatch(number);
        }
        public static bool ISNumber(string number)
        {
            return ValidateInteger(number) || ValidateFloat(number);
        }
    }
}
