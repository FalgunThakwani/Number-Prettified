using Number_Prettifier;


class Program
{
    public static void Main(string[] args)
    {

        while (true)
        {
            Console.Write("Enter number from 1 to 1 Trillion to prettyfy (or 'q' to quit application): ");
            string inputParam = Console.ReadLine(); //Input parameter for reading user input


            //if 'q' break the loop and exit application
            if (inputParam.ToLower() == "q")
            {
                Console.WriteLine("Exiting the application...");
                break;
            }

            if (Double.TryParse(inputParam, out Double number) && number >= 0)
            {
                string prettyNumber = Service.NumberPrettified(number); //Calling the NumberPrettified method
                Console.WriteLine("Prettyfied Number: "+prettyNumber);
            }
            else
            {
                Console.WriteLine("Input invalid. Please enter a valid number between 1 and 1 Trillion.");
            }
        }
    }


}
