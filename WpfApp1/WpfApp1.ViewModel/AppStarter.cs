using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using Enums;
using WpfApp1.Helpers;
using WpfApp1.Model.Models;

namespace WpfApp1.ViewModel
{
    public static class AppStarter
    {
        private static CharacterModel priest;

        private static CharacterModel trader;

        private static CharacterModel knight;

        private static void GenerateCharacters()
        {
            priest = new CharacterModel
            {
                CharType = CharacterTypes.Priest,
                Name = CharacterHelper.GetNameByType(CharacterTypes.Priest)
            };

            trader = new CharacterModel
            {
                CharType = CharacterTypes.Trader,
                Name = CharacterHelper.GetNameByType(CharacterTypes.Trader)
            };

            knight = new CharacterModel
            {

                CharType = CharacterTypes.Knight,
                Name = CharacterHelper.GetNameByType(CharacterTypes.Knight)
            };
        }

        private static IEnumerable<CardViewModel> GeneratePriestTasks()
        {
            yield return new CardViewModel(priest)
            {
                Id = 1,
                Text = SirHelper.GetBeginning() + "треба збудувати новий монастир",
                YesText = "Так, звісно",
                NoText = "Їх і так забагато",
                YesHighlight = ResourceTypes.Religion | ResourceTypes.Money,
                NoHighlight = ResourceTypes.Religion,
                OnLeft = model =>
                {
                    model.Religion += 100;
                    model.Money -= 100;
                    model.RemoveCard(1);
                },
                OnRight = model =>
                {
                    model.Religion -= 150;
                    model.RemoveCard(1);
                }
            };
        }


        public static MainViewModel GetMainView()
        {
            GenerateCharacters();
            var priestTasks = GeneratePriestTasks().ToList();
            var context = new GameContext();
            var contextModel = new ContextViewModel(context);
            contextModel.Deck = new ObservableCollection<CardViewModel>(priestTasks);
            var mainModel = new MainViewModel
            {
                Context = contextModel,
                TaskCard = contextModel.GetNextCard()
            };
            return mainModel;
        }
    }
}
