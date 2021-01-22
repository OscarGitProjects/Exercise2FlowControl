using System;
using System.Text;

namespace Exercise2FlowControl
{
    enum MainAction
    {
        CLEAR_WINDOW_NO = 0,
        CLEAR_WINDOW_YES = 1,
        QUIT = 2
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Run();

            //Console.ReadLine();
        }

        private void Run()
        {
            bool bRun = true;
            MainAction mainAction = MainAction.CLEAR_WINDOW_YES;

            do
            {
                if(mainAction == MainAction.CLEAR_WINDOW_YES)
                    Console.Clear();

                ShowMainMenu();
                mainAction = HandleMainMenuChoice();

                if (mainAction == MainAction.QUIT)
                    bRun = false;
            } 
            while (bRun);
        }

        /// <summary>
        /// Metoden hanterar huvudmenyn och action från användaren
        /// </summary>
        /// <returns>Enum som talar om vi skall avsluta programmet, radera fönstret och visa menyn igen eller inte radera fönstret och visa menyn</returns>
        private MainAction HandleMainMenuChoice()
        {
            MainAction action = MainAction.CLEAR_WINDOW_YES;

            string strAction = Console.ReadLine();

            if(strAction?.Length > 0)
            {
                strAction = strAction.ToLower();
                strAction = strAction.Trim();

                switch (strAction)
                {
                    case "0":   // Avbryt
                        action = MainAction.QUIT;
                        break;
                    case "q":   // Avbryt
                        action = MainAction.QUIT;
                        break;
                    case "1":   // Visa meny för bio. Fråga efter åldern
                        Console.Clear();
                        ShowCinemaMenuAskForAge();
                        break;
                    case "2":   // Visa meny för bio där man kan boka flera biljetter
                        Console.Clear();
                        ShowCinemaMenuForAParty();
                        break;
                    case "3":   // Visa meny där användaren skall mata in en text. Texten upprepas 10 gånger
                        Console.Clear();
                        ShowMenuWhereUserTypesInText();
                        break;
                    default:    // Indata är felaktig
                        Console.Clear();
                        Console.WriteLine("Felaktig indata!");
                        break;
                }
            }
            else
            {// Indata är felaktig
                Console.Clear();
                Console.WriteLine("Felaktig indata!");
            }

            return action;
        }


        /// <summary>
        /// Metoden hanterar inmatning av en text från en användare.
        /// Texte visas 10 gånger på en och samma rad
        /// </summary>
        private void ShowMenuWhereUserTypesInText()
        {
            StringBuilder strBuilder = new StringBuilder();
            bool bRun = true;

            do
            {
                // Visa texten för menyn
                Console.WriteLine(Menus.GetMenuForTextInput());

                string strText = Console.ReadLine();

                if(!String.IsNullOrWhiteSpace(strText))
                {
                    strText = strText.Trim();

                    for (int i = 0; i < 10; i++)
                    {
                        if (i != 0)
                            strBuilder.Append(", ");
                        strBuilder.Append(strText);
                    }

                    bRun = false;
                    Console.Clear();
                    Console.WriteLine(strBuilder.ToString());
                    Console.WriteLine("Return för att avsluta");
                    Console.ReadLine();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Felaktig indata!");
                }

            } while (bRun);
        }


        /// <summary>
        /// Metoden hantera inmatning av antalet personer och ålder per person i ett sällskap
        /// Visar information om antal personer och totala biljett priset
        /// </summary>
        private void ShowCinemaMenuForAParty()
        {
            bool bRun = true;
            int iTotalTicketSum = 0;

            do
            {
                // Visa texten för menyn
                Console.WriteLine(Menus.GetShowCinemaMenuForAParty());

                string strNumberOfPersons = Console.ReadLine();

                if(!String.IsNullOrWhiteSpace(strNumberOfPersons))
                {
                    strNumberOfPersons = strNumberOfPersons.ToLower();
                    strNumberOfPersons = strNumberOfPersons.Trim();

                    if (strNumberOfPersons.CompareTo("q") == 0)
                    {
                        bRun = false;
                    }
                    else
                    {
                        try
                        {
                            int iNumberOfPersons = Int32.Parse(strNumberOfPersons);

                            if(iNumberOfPersons > 0)
                            {
                                int iAge = 0;
                                int iTicketPrice = 0;

                                // Nu vill jag häma ålder för varje person. Ålder bestämemr också priset för en biljett
                                // Summerar biljett priserna
                                for (int i = 1; i <= iNumberOfPersons; i++)
                                {
                                    // Hämta ålder för en person från ui
                                    iAge = GetAgeFromUI(i);

                                    if (iAge > 0)
                                    {
                                        // Hämta priset på en biljett och summera totala summan
                                        iTicketPrice = GetTicketPrice(iAge);
                                        iTotalTicketSum += iTicketPrice;
                                    }
                                    else if(iAge == -123)
                                    {// Användaren har valt att avbryta. Återgå till huvudmenyn
                                        return;
                                    }
                                }

                                // Vi har data om antal personer och priset för biljetterna
                                string strPerson = "personer";
                                if (iNumberOfPersons == 1)
                                    strPerson = "person";

                                bRun = false;
                                Console.Clear();
                                Console.WriteLine($"Biljetterna för {iNumberOfPersons} {strPerson} kostar {iTotalTicketSum}");
                                Console.WriteLine("Return för att avsluta");
                                Console.ReadLine();
                            }
                        }
                        catch (Exception)
                        {// Vill fånga alla undantag
                            Console.Clear();
                            Console.WriteLine("Felaktig indata!");
                        }
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Felaktig indata!");
                }

            } while (bRun);

        }


        /// <summary>
        /// Metoden hanterar inmatning av ålder för en person
        /// </summary>
        /// <param name="iPerson">Ett index för personen</param>
        /// <returns>Personens ålder. Om åldern är -123 har användaren valt att avbryta inmatningen</returns>
        private int GetAgeFromUI(int iPerson)
        {
            int iAge = -1;
            bool bRun = true;

            do
            {
                // Visa texten för menyn
                Console.WriteLine(Menus.GetCinemaMenuAskForAge(iPerson));

                string strAge = Console.ReadLine();

                if (!String.IsNullOrWhiteSpace(strAge))
                {
                    strAge = strAge.Trim();

                    if (strAge.ToLower().CompareTo("q") == 0)
                    {// Användaren har valt att avluta
                        iAge = -123;
                        bRun = false;
                    }
                    else
                    {
                        try
                        {
                            iAge = Int32.Parse(strAge);
                            if (iAge > 0)
                            {
                                bRun = false;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Felaktig indata!");
                            }
                        }
                        catch (Exception)
                        {
                            Console.Clear();
                            Console.WriteLine("Felaktig indata!");
                        }
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Felaktig indata!");
                }

            } while (bRun);

            return iAge;
        }


        /// <summary>
        /// Metoden returnerar priset på en biljett. Priset beror på åldern
        /// </summary>
        /// <param name="iAge">Kundens ålder</param>
        /// <returns>Priset på en biljett för sökt ålder</returns>
        private int GetTicketPrice(int iAge)
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
        /// Metoden anropas när användaren har valt bio alternativet
        /// Visar menyn för bion samt hanterar logiken när användaren skall ange sin ålder
        /// </summary>
        private void ShowCinemaMenuAskForAge()
        {
            bool bRun = true;
            
            do
            {
                // Visa texten för menyn
                Console.WriteLine(Menus.GetCinemaMenuAskForAge());

                string strAge = Console.ReadLine();

                if (!String.IsNullOrWhiteSpace(strAge))
                {
                    strAge = strAge.Trim();

                    if (strAge.ToLower().CompareTo("q") == 0)
                    {                        
                        bRun = false;
                    }
                    else
                    {
                        try
                        {
                            int iAge = Int32.Parse(strAge);

                            switch (iAge)
                            {
                                case int age when age <= 0:
                                    Console.Clear();
                                    Console.WriteLine("Felaktig indata!");
                                    break;
                                case int age when age < 5:
                                    Console.Clear();
                                    Console.WriteLine("Barn pris: 0 kr");

                                    Console.WriteLine("Return för att avsluta");
                                    Console.ReadLine();
                                    bRun = false;
                                    break;
                                case int age when age < 20:
                                    Console.Clear();
                                    Console.WriteLine("Ungdomspris: 80 kr");

                                    Console.WriteLine("Return för att avsluta");
                                    Console.ReadLine();
                                    bRun = false;
                                    break;
                                case int age when age > 100:
                                    Console.Clear();
                                    Console.WriteLine("Pensionärspris över 100 år fyllda: 0 kr");

                                    Console.WriteLine("Return för att avsluta");
                                    Console.ReadLine();
                                    bRun = false;
                                    break;
                                case int age when age > 64:
                                    Console.Clear();
                                    Console.WriteLine("Pensionärspris: 90 kr");

                                    Console.WriteLine("Return för att avsluta");
                                    Console.ReadLine();
                                    bRun = false;
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("Standardpris: 120 kr");

                                    Console.WriteLine("Return för att avsluta");
                                    Console.ReadLine();
                                    bRun = false;
                                    break;
                            }
                        }
                        catch (Exception)
                        {// Jag vill fånga alla undantag
                            Console.Clear();
                            Console.WriteLine("Felaktig indata!");
                        }
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Felaktig indata!");
                }

            } while (bRun);
        }


        /// <summary>
        /// Metoden visar huvudmenyn
        /// </summary>
        private void ShowMainMenu()
        {
            Console.WriteLine(Menus.GetMainMenu());
        }
    }
}
