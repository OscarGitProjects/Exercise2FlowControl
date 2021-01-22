using System;

namespace Exercise2FlowControl
{
    /// <summary>
    /// Klass med olika hjälp metoder
    /// </summary>
    public class Helpers
    {
        /// <summary>
        /// Metoden returnerar priset på en biljett. Priset beror på åldern
        /// </summary>
        /// <param name="iAge">Kundens ålder</param>
        /// <returns>Priset på en biljett för sökt ålder</returns>
        public static int GetTicketPrice(int iAge)
        {
            int iTicketPrice = 0;

            switch (iAge)
            {
                case int age when age < 5:
                    iTicketPrice = 0;
                    break;
                case int age when age < 20:
                    iTicketPrice = 80;
                    break;
                case int age when age > 100:
                    iTicketPrice = 0;
                    break;
                case int age when age > 64:
                    iTicketPrice = 90;
                    break;
                default:
                    iTicketPrice = 120;
                    break;
            }

            return iTicketPrice;
        }

        /// <summary>
        /// Metoden hanterar inmatning av en text från användaren
        /// </summary>
        /// <param name="prompt">Text som skall skrivas ut i kosolen</param>
        /// <returns>Texten som har skrivits in av användaren</returns>
        public static string GetTextInput(string prompt)
        {
            string strInput = String.Empty;
            bool bRun = true;
            do
            {
                Console.WriteLine(prompt);
                strInput = Console.ReadLine();

                if (String.IsNullOrWhiteSpace(strInput))
                {
                    Console.Clear();
                    Console.WriteLine("Felaktig indata!");
                }
                else
                {
                    bRun = false;
                }

            } while (bRun);

            return strInput;
        }
    }
}
