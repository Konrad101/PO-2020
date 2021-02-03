using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PO_implementacja_StudiaPodyplomowe.Models.Validators
{
    public class DataValidator
    {
        static readonly int MIN_VALID_YEAR = 1900;
        static readonly int MAX_VALID_YEAR = DateTime.Now.Year + 1;

        public static bool DateIsValid(string strDate)
        {
            bool isValid = true;
            if (strDate.Length != 10)
            {
                isValid = false;
            } else 
            {
                strDate = strDate.Replace("-", ".");
                DateTime time = new DateTime();
                if (!DateTime.TryParse(strDate, out time))
                {
                    isValid = false;
                } else if (time.Year < MIN_VALID_YEAR || time.Year > MAX_VALID_YEAR)
                {
                    isValid = false;
                }
            }

            return isValid;
        }

        public static bool FieldContentIsValid(string fieldContent, int?maxLength=null)
        {
            if (maxLength < 1) throw new ArgumentException();
            string fieldContentWithoutSpaces = RemoveWhiteSpaces(fieldContent);
            if(fieldContent.Length > maxLength)
            {
                return false;
            }
            return fieldContentWithoutSpaces.Length != 0 ? true : false;
        }

        public static bool NumberIsValid(string strNumber, int? minRange=null, int?maxRange=null)
        {
            if(minRange != null && maxRange != null)
            {
                throw new ArgumentException("Min range must be smaller than max range");
            }

            strNumber = RemoveWhiteSpaces(strNumber);
            bool isValid = strNumber.Length > 0;
            int number;
            if(isValid && int.TryParse(strNumber, out number))
            {
                if(minRange != null && number < minRange)
                {
                    isValid = false;
                } else if(maxRange != null && number > maxRange)
                {
                    isValid = false;
                }
            } else
            {
                isValid = false;
            }

            return isValid;
        }

        private static string RemoveWhiteSpaces(string str)
        {
            return Regex.Replace(str, @"\s+", "");
        }
    }
}
