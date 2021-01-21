using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise2FlowControl
{
    public class Menus
    {
        public static string GetMainMenu()
        {
            StringBuilder strBuilder = new StringBuilder("Huvudmeny");
            strBuilder.Append(System.Environment.NewLine);

            strBuilder.Append("(Navigera genom att ange siffra för önskat alternativ)");
            strBuilder.Append(System.Environment.NewLine);

            strBuilder.Append("0. Avsluta");
            //strBuilder.Append(System.Environment.NewLine);
            //strBuilder.Append(System.Environment.NewLine);

            return strBuilder.ToString();
        }
    }
}
