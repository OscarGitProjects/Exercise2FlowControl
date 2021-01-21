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
            //Console.WriteLine("Run program!");
            bool bRun = true;

            do
            {
                ShowMainMenu();
                bRun = HandleMainMenuChoice();
            } 
            while (bRun);
        }

        private bool HandleMainMenuChoice()
        {
            bool bRun = true;

            string strAction = Console.ReadLine();

            if(strAction?.Length > 0)
            {               
                switch (strAction)
                {
                    case "0":
                        bRun = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Felaktig indata!");
                        break;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Felaktig indata!");
            }

            return bRun;
        }

        private void ShowMainMenu()
        {
            Console.WriteLine(Menus.GetMainMenu());
        }
    }
}
