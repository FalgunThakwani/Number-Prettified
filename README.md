# Number-Prettified
A console application for formatting numbers greater than 6 digits into "prettified" representations, supporting millions, billions, and trillions.
**Framework - .NET 6**
**Language - C# 12**
**Test Framework - Nunit**
# Approach
To solve this problem, my first step was to analyze the requirements and consider all possible edge cases. Once I had a clear understanding, I created a pseudo-code outline to structure the application. Initially, my approach relied heavily on traditional if-else statements to handle different scenarios. My plan involved converting the number into a string representation and extracting the digits before the decimal point. I tested my pseudo-code with both boundary cases and typical scenarios. After that when I was working to refactor the code, I observed a pattern in the code, which would optimize the code further. This optimization reduced the repetition of code blocks and made the solution more concise. For testing, I chose to use the NUnit testing framework. I crafted a variety of test cases to validate the algorithm's behavior under different conditions. Additionally, I commented within the code for better understanding of the algorithm.
# Assumptions:
In developing this program, I made the following two assumptions:
1) Only numbers greater than 6 digits are prettified. No "K" or "thousand" representation is used for smaller numbers.
2) Decimal points are not rounded off, and exact floating-point values are displayed. 
# Design Decisions
For simplicity, I opted for a console application architecture. I structured the application into three files:
1) Program.cs: This file serves as the entry point to the application.
2) Service.cs: Here, I implemented service methods for different functionalities.
3) Test.cs: This file contains test cases to ensure the correctness of the implemented functionalities.
I chose to use static methods in the service class to avoid unnecessary object instantiation.
# Requiment Questions
1) Should numbers less than 6 digits be converted? For example, should 1500 be prettified as 1.5K?
2) Was there a requirement to use a testing framework?

# Algorithm

The algorithm implementation can be found in the `Service.cs` file. 


        public static string NumberPrettified(Double number)
        {
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



