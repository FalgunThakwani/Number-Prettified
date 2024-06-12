using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Number_Prettifier
{
    internal class Service
    {

        // This method will Prettyfy numbers greater than 6 digits upto millions, 
        // billions and trillions. Currently it doesnot support "K" or thousand as
        // it was not clear in the requirements.
        // <return type=string/>
        // <input type=double/>
        public static string NumberPrettified(Double number)
        {

            //Caluculating the length of the number before decimal
            string beforeDecimal = number.ToString().Split(".")[0];
            int lengthOfBeforeDecimal = beforeDecimal.Length;

            //if Number greater then 16 digits or 999.99 Trillion return error message;
            if (lengthOfBeforeDecimal >= 16 || number > 999999999999999.999) {
                return "Error: The number is too large to be processed.";
            }


            //Calulating the suffix by the length of the number
            string[] end = { "", "", "M", "B", "T" };
            int endIndex = (lengthOfBeforeDecimal - 1) / 3;

            //if sufix is blank return number by formating it to 1 place after decimal
            if (endIndex <= 1) return (Math.Floor(number * 10) / 10).ToString();

            //Leading digits
            int digitCount = lengthOfBeforeDecimal % 3 == 0 ? 3 : lengthOfBeforeDecimal % 3;
            string starting = beforeDecimal.Substring(0, digitCount);

            //if the second digit is not 0 include the decimal point and the integer
            string middle = beforeDecimal[digitCount] == '0' ? "" : "." + beforeDecimal[digitCount];

            //combine all the parts
            string pretifiedVersion = starting + middle + end[endIndex];

            return pretifiedVersion;
        }

    }
}
