using System;
using System.Collections.Generic;

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
        /// <param name="prompt">Text som skall skrivas ut i konsolen</param>
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


        /// <summary>
        /// Metoden tar en mening. Delar meningen i ord vid mellanslagen. 
        /// Om ordet består av text kommer ordet att sparas i en lista. Listan returneras sedan av metoden
        /// </summary>
        /// <param name="strSentence">Mening som skall delas upp i en lista med ord</param>
        /// <returns>Lista med ord, null eller en tom lista</returns>
        public static List<string> GetWordsFromSentence(string strSentence)
        {
            List<string> lsWords = new List<string>();

            if (String.IsNullOrWhiteSpace(strSentence))
                return null;

            string[] arrTmpWords = strSentence.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if(arrTmpWords?.Length > 0)
            {
                foreach (string strWord in arrTmpWords)
                    lsWords.Add(strWord.Trim());
            }

            /* OLD
            string[] arrTmpWords = strSentence.Split(' ');
            if(arrTmpWords?.Length > 0)
            {// Vi har några ord. Nu vill jag se till att inte vissa ord bara är mellanslag
                // Vi sparar bara riktiga ord i listan som returneras
                foreach(string strWord in arrTmpWords)
                {
                    if(!String.IsNullOrWhiteSpace(strWord))
                        lsWords.Add(strWord.Trim());
                }
            }*/

            return lsWords;
        }
    }
}
