using System.Collections.Generic;

namespace WpfApp1.Helpers
{
    public  class helper : Ihelper
    {
        private  List<string> namings = new List<string>
        {
            "Сір, ",
            "Мілорд, ",
            "Володарю, ",
            "Королю, ",
            "Ваша величносте, ",
            "Ваша світлосте, ",
            "Імператоре, "
        };

        public  string GetBeginning()
        {
            return namings.GetRandom();
        }
    }
}
