using System;

namespace Exercise2FlowControl
{
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

            do
            {
                Console.Clear();
                ShowMainMenu();
                bRun = HandleMainMenuChoice();
            } 
            while (bRun);
        }

        /// <summary>
        /// Metoden hanterar huvudmenyn och action från användaren
        /// </summary>
        /// <returns>true om vi skall fortsätta att köra programmet. Annars returneras false</returns>
        private bool HandleMainMenuChoice()
        {
            bool bRun = true;

            string strAction = Console.ReadLine();

            if(strAction?.Length > 0)
            {               
                switch (strAction)
                {
                    case "0":   // Avbryt
                        bRun = false;
                        break;
                    case "1":   // Visa meny för bio. Fråga efter åldern
                        Console.Clear();
                        ShowCinemaMenuAskForAge();
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

            return bRun;
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
                Console.WriteLine(Menus.GetCinemaMenuAskForAge());
                string strAge = Console.ReadLine();

                if (!String.IsNullOrWhiteSpace(strAge))
                {
                    if(strAge.ToLower().CompareTo("q") == 0)
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
                                case int age when age < 20:
                                    Console.Clear();
                                    Console.WriteLine("Ungdomspris: 80kr");
                                    break;
                                case int age when age > 64:
                                    Console.Clear();
                                    Console.WriteLine("Pensionärspris: 90 kr");
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("Standardpris: 120 kr");
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
            }
            while (bRun);
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
