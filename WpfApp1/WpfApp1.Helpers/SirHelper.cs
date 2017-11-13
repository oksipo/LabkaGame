using System.Collections.Generic;

namespace WpfApp1.Helpers
{
    public static class SirHelper
    {
        private static List<string> namings = new List<string>
        {
            "Сір, ",
            "Мілорд, ",
            "Володарю, ",
            "Королю, ",
            "Ваша величносте, ",
            "Ваша світлосте, ",
            "Імператоре, ",
            "",
            "",
            "",
            "",
        };

        public static string GetBeginning()
        {
            return namings.GetRandom();
        }
    }
}
