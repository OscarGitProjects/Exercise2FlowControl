using System.Text;

namespace Exercise2FlowControl
{
    /// <summary>
    /// Klass med metoder för att skapa menyer som skrivs ut i konsolen
    /// Menyerna returneras som en text som skrivs ut i konsolen
    /// </summary>
    public class Menus
    {
        /// <summary>
        /// Metoden returnerar texten för huvudmenyn
        /// </summary>
        /// <returns>String med texten till huvudmenyn</returns>
        public static string GetMainMenu()
        {
            StringBuilder strBuilder = new StringBuilder("Huvudmeny");
            strBuilder.Append(System.Environment.NewLine);

            strBuilder.Append("(Navigera genom att ange siffra för önskat alternativ)");
            strBuilder.Append(System.Environment.NewLine);

            strBuilder.Append("0. Avsluta");
            strBuilder.Append(System.Environment.NewLine);

            strBuilder.Append("1. Bio");
            strBuilder.Append(System.Environment.NewLine);

            strBuilder.Append("2. Bio för sällskap");
            strBuilder.Append(System.Environment.NewLine);

            strBuilder.Append("3. Upprepa inmatning från användare");

            return strBuilder.ToString();
        }


        /// <summary>
        /// Metoden returnerar texten för lokala bio menyn där användaren skall skriva in sin ålder
        /// </summary>
        /// <returns>String med texten till lokala bio menyn</returns>
        public static string GetCinemaMenuAskForAge()
        {
            StringBuilder strBuilder = new StringBuilder("Meny");
            strBuilder.Append(System.Environment.NewLine);

            strBuilder.Append("Lokala bion");
            strBuilder.Append(System.Environment.NewLine);

            strBuilder.Append("Ange er ålder (Ange q för att avbryta): ");
            return strBuilder.ToString();
        }


        /// <summary>
        /// Metoden returnerar texten för lokala bio menyn där användaren skall skriva in sin ålder
        /// </summary>
        /// <param name="iPerson">Personens nummer i listan</param>
        /// <returns>String med texten till lokala bio menyn</returns>
        public static string GetCinemaMenuAskForAge(int iPerson)
        {
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append($"Ange ålder för person {iPerson} (Ange q för att avbryta): ");
            return strBuilder.ToString();
        }


        /// <summary>
        /// Metoden returnerar texten för lokala bio menyn för sällskap
        /// Där skall användaren skriva in antalet bio besökare
        /// </summary>
        /// <returns>String med texten till lokala bio menyn för sällskap</returns>
        public static string GetShowCinemaMenuForAParty()
        {
            StringBuilder strBuilder = new StringBuilder("Meny");
            strBuilder.Append(System.Environment.NewLine);

            strBuilder.Append("Lokala bion för sällskap");
            strBuilder.Append(System.Environment.NewLine);

            strBuilder.Append("Ange antal personer (Ange q för att avbryta): ");
            return strBuilder.ToString();
        }


        /// <summary>
        /// Metoden returnerar texten som uppmanar en användare att mata in en text
        /// </summary>
        /// <returns>String med texten</returns>
        public static string GetMenuForTextInput()
        {
            return "Skriv in en text";
        }
    }
}