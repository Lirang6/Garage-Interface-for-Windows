using System;

namespace Ex03.ConsoleUI
{
    class UIService
    {
        public static string GetLine(string i_Message)
        {
            Console.WriteLine(i_Message);
            string input = Console.ReadLine();

            while (input.Equals(""))
            {
                Console.WriteLine("Empty answer is invalid.");
                Console.WriteLine(i_Message);
                input = Console.ReadLine();
            }

            return input;
        }

        public static float CheckFloatValue(float i_Maximum, string i_Type)
        {
            bool validtion = false;
            float current = 0;

            while (!validtion)
            {
                Console.WriteLine(string.Format("What is the current {0} level?", i_Type));
                string input = Console.ReadLine();
                validtion = float.TryParse(input, out current);
                if (!validtion || current < 0 || current > i_Maximum)
                {
                    Console.WriteLine("Your input is invalid, please try again");
                    validtion = false;
                }
            }

            return current;
        }

        public static int GetEnum(Type i_EnumType, string i_Message)
        {
            Console.WriteLine(i_Message);
            string[] values = Enum.GetNames(i_EnumType);

            for (int i = 1; i < values.Length + 1; i++)
            {
                Console.WriteLine(string.Format("{0}. {1}", i, values[i - 1]));
            }

            bool validtion = false;
            int enumIndex = 0;

            while (!validtion)
            {
                string input = Console.ReadLine();
                validtion = int.TryParse(input, out enumIndex);
                if (!validtion || enumIndex < 1 || enumIndex > values.Length)
                {
                    Console.WriteLine("Your input is invalid, please try again");
                    validtion = false;
                }
            }

            return enumIndex;
        }
    }
}
