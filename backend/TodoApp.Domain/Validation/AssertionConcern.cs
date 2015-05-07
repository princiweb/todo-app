using System;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace TodoApp.Domain.Validation
{
    public class AssertionConcern
    {
        public static void AssertArgumentEquals(object object1, object object2, string message, string param)
        {
            if (!object1.Equals(object2))
            {
                throw new ArgumentException(message, param);
            }
        }

        public static void AssertArgumentFalse(bool boolValue, string message, string param)
        {
            if (boolValue)
            {
                throw new ArgumentException(message, param);
            }
        }

        public static void AssertArgumentTrue(bool boolValue, string message, string param)
        {
            if (!boolValue)
            {
                throw new ArgumentException(message, param);
            }
        }

        public static void AssertArgumentLength(string stringValue, int maximum, string message, string param)
        {
            var length = stringValue.Trim().Length;

            if (length > maximum)
            {
                throw new ArgumentOutOfRangeException(param, message);
            }
        }

        public static void AssertArgumentLength(string stringValue, int minimum, int maximum, string message, string param)
        {
            if (String.IsNullOrEmpty(stringValue))
                stringValue = String.Empty;

            var length = stringValue.Trim().Length;

            if (length < minimum || length > maximum)
            {
                throw new ArgumentOutOfRangeException(param, message);
            }
        }

        public static void AssertArgumentMatches(string pattern, string stringValue, string message, string param)
        {
            var regex = new Regex(pattern);

            if (!regex.IsMatch(stringValue))
            {
                throw new ArgumentException(message, param);
            }
        }

        public static void AssertArgumentNotEmpty(string stringValue, string message, string param)
        {
            if (stringValue == null || stringValue.Trim().Length == 0)
            {
                throw new ArgumentNullException(param, message);
            }
        }

        public static void AssertArgumentNotEquals(object object1, object object2, string message, string param)
        {
            if (object1.Equals(object2))
            {
                throw new ArgumentException(message, param);
            }
        }

        public static void AssertArgumentNotNull(object object1, string message, string param)
        {
            if (object1 == null)
            {
                throw new ArgumentNullException(param, message);
            }
        }

        public static void AssertArgumentRange(double value, double minimum, double maximum, string message, string param)
        {
            if (value < minimum || value > maximum)
            {
                throw new ArgumentOutOfRangeException(param, message);
            }
        }

        public static void AssertArgumentRange(float value, float minimum, float maximum, string message, string param)
        {
            if (value < minimum || value > maximum)
            {
                throw new ArgumentOutOfRangeException(param, message);
            }
        }

        public static void AssertArgumentRange(int value, int minimum, int maximum, string message, string param)
        {
            if (value < minimum || value > maximum)
            {
                throw new ArgumentOutOfRangeException(param, message);
            }
        }

        public static void AssertArgumentRange(long value, long minimum, long maximum, string message, string param)
        {
            if (value < minimum || value > maximum)
            {
                throw new ArgumentOutOfRangeException(param, message);
            }
        }
    }
}
