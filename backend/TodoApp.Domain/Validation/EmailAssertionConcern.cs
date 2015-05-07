using System;
using System.Text.RegularExpressions;

namespace TodoApp.Domain.Validation
{
    public class EmailAssertionConcern
    {
        public static void AssertIsValid(string email, string param)
        {
            if (!Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
                throw new ArgumentException("E-mail inválido.", param);
        }
    }
}
