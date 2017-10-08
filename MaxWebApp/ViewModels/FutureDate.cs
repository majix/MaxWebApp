using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace MaxWebApp.ViewModels
{
    public class FutureDate : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime datetime;
            var isValid = DateTime.TryParseExact(Convert.ToString(value),
                "d MMM YYYY",
                CultureInfo.CurrentCulture,
                DateTimeStyles.None, out datetime);
            return (isValid && datetime > DateTime.Now);
        }
    }
}