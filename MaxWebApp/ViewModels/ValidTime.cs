using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace MaxWebApp.ViewModels
{
    public class ValidTime : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime datetime;
            var isValid = DateTime.TryParseExact(Convert.ToString(value),
                "HH:MM",
                CultureInfo.CurrentCulture,
                DateTimeStyles.None, out datetime);
            return (isValid);
        }
    }
}