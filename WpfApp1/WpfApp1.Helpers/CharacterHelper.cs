using System.Collections.Generic;
using Enums;

namespace WpfApp1.Helpers
{
    public static class CharacterHelper
    {
        static Dictionary<CharacterTypes, string> CharacterImages = new Dictionary<CharacterTypes, string>
        {
            {CharacterTypes.Priest, "Resources/Characters/priest.jpg" },
            {CharacterTypes.Knight, "Resources/Characters/knight.jpg" },
            {CharacterTypes.Trader, "Resources/Characters/trader.jpg" }
        };

        static Dictionary<CharacterTypes, string> CharacterNamings = new Dictionary<CharacterTypes, string>
        {
            {CharacterTypes.Priest, "Отець " },
            {CharacterTypes.Knight, "Сер " },
            {CharacterTypes.Trader, "" }
        };

        static Dictionary<CharacterTypes, List<string>> CharacterNames = new Dictionary<CharacterTypes, List<string>>
        {
            {CharacterTypes.Priest, new List<string>
            {
                "Криштобаль",
                "Себастьян",
                "Петер",
                "Мартін",
                "Джозеф",
                "Августин",
                "Бенедикт",
                "Ігнацій",
                "Вольфган",
                "Авраам",
            } },
            {CharacterTypes.Knight, new List<string>
            {
                "Гавейн",
                "Ланселот",
                "Галахад",
                "Персиваль",
                "Ламораак",
                "Борс",
                "Кей",
                "Мордред",
                "Гарет",
                "Уріенс",
                "Оуен",
                "Агравейн",
                "Артур",
            } },
            {CharacterTypes.Trader, new List<string>
            {
                "Марко",
                "Колумб"
            } }
        };

        public static string GetPictureByType(CharacterTypes type)
        {
            return CharacterImages[type];
        }

        public static string GetNameByType(CharacterTypes type)
        {
            return CharacterNamings[type] + CharacterNames[type].GetRandom();
        }
    }
}
