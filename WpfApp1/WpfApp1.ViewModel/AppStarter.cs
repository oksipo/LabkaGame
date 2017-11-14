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

        private static CharacterModel butcher;

        private static CharacterModel storyteller;

        public static CardViewModel WinCard { get; set; }

        public static CardViewModel NoMoneyCard { get; set; }

        public static List<CardViewModel> TooMuchMoneyCards { get; set; }

        public static CardViewModel TooMuchPeopleCard { get; set; }

        public static CardViewModel NoPeopleCard { get; set; }

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

            butcher = new CharacterModel()
            {
                CharType = CharacterTypes.Butcher,
                Name = CharacterHelper.GetNameByType(CharacterTypes.Butcher)
            };

            storyteller = new CharacterModel()
            {
                CharType = CharacterTypes.Storyteller
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

        private static IEnumerable<CardViewModel> GenerateKnightTasks()
        {
            yield return new CardViewModel(knight)
            {
                Id= 2,
                Text = SirHelper.GetBeginning() + "західні королівства набирають силу! Послати проти них армію?",
                YesText = "Крові кривавому богу!",
                NoText = "Ні, давайте жити дружно",
                YesHighlight = ResourceTypes.People | ResourceTypes.Army,
                NoHighlight = ResourceTypes.Army,
                OnLeft = model =>
                {
                    model.Army += 100;
                    model.People -= 100;
                    model.RemoveCard(2);
                },
                OnRight = model =>
                {
                    model.Army -= 100;
                    model.RemoveCard(2);
                }
            };
        }

        private static IEnumerable<CardViewModel> GenerateTraderTasks()
        {
            yield return new CardViewModel(trader)
            {
                Id=3,
                Text = SirHelper.GetBeginning() + "ми знайшли шахту повну золота.Продовжувати копати?",
                YesText = "Так",
                NoText = "Хай шахтарі відпочинуть",
                YesHighlight = ResourceTypes.Money | ResourceTypes.People,
                NoHighlight =  ResourceTypes.People,
                OnLeft = model =>
                {
                    model.Money += 100;
                    model.People -= 100;
                    model.RemoveCard(3);
                },
                OnRight = model =>
                {
                    model.People += 100;
                    model.RemoveCard(3);
                }
            };
        }

        private static IEnumerable<CardViewModel> GenerateButcherTasks()
        {
            yield return new CardViewModel(butcher)
            {
                Id = 4,
                Text = SirHelper.GetBeginning() + "надто багатьох треба стратити. Мені потрібна допомога армії",
                YesText = "Від них і так нема користі",
                NoText = "Сам справишся",
                YesHighlight = ResourceTypes.Army | ResourceTypes.People,
                NoHighlight = ResourceTypes.People,
                OnLeft = model =>
                {
                    model.Army -= 100;
                    model.People -= 200;
                    model.RemoveCard(4);
                },
                OnRight = model =>
                {
                    model.People -= 100;
                    model.RemoveCard(4);
                }
            };
        }

        private static void GenerateEndings()
        {
            WinCard = new CardViewModel(storyteller)
            {
                Id = 100,
                ImagePath = "Resources/Endings/victory.jpg",
                Text = "Вітаю ,мілорд! Ви перемогли!",
                Name = "",
            };

            NoMoneyCard = new CardViewModel(storyteller)
            {
                Id = 100,
                ImagePath = "Resources/Endings/NoMoney.jpg",
                Text = "Грошей нема, замок розвалився, люди втекли. Зате Ви можете правити голубами",
                Name = ""
            };

            TooMuchMoneyCards = new List<CardViewModel>
            {
                new CardViewModel(storyteller)
                {
                    Id=100,
                    Text = "Владу захопила олігархія та відправила вас у вигнання на човні. Без весла. І без дна.",
                    ImagePath = "Resources/Endings/TooMuchMoney1.jpg"
                },
                new CardViewModel(storyteller)
                {
                    Id=100,
                    Text = "На бенкеті з приводу визнання вашого королівства найбагатшим в світі ви перепили. До смерті.",
                    ImagePath = "Resources/Endings/TooMuchMoney2.jpg"
                },
                new CardViewModel(storyteller)
                {
                Id=100,
                Text = "Нова олігархія змусила вас робити лаби з КПЗ.",
                ImagePath = "Resources/Endings/TooMuchMoney3.jpg"
            }
            };

            TooMuchPeopleCard = new CardViewModel(storyteller)
            {
                Id = 100,
                Text = "Народ захоплює владу, але вас ніхто не рухає. Згодом вас починають згадувати як хорошого короля.",
                ImagePath = "Resources/Endings/TooMuchPeople.jpg"
            };

            NoPeopleCard = new CardViewModel(storyteller)
            {
                Id = 100,
                Text = "Країною шириться чума. Ви вмираєте одним із перших.",
                ImagePath = "Resources/Endings/NoPeople.jpg"
            };
        }

        public static MainViewModel GetMainView()
        {
            GenerateCharacters();
            GenerateEndings();
            var priestTasks = GeneratePriestTasks().ToList();
            var knightTasks = GenerateKnightTasks().ToList();
            var traderTasks = GenerateTraderTasks().ToList();
            var butcherTasks = GenerateButcherTasks().ToList();
            var context = new GameContext();
            var contextModel = new ContextViewModel(context)
            {
                Deck = new ObservableCollection<CardViewModel>(
                 priestTasks
                .Union(knightTasks)
                .Union(traderTasks)
                .Union(butcherTasks))
            };

            var mainModel = new MainViewModel
            {
                Context = contextModel,
                TaskCard = contextModel.GetNextCard()
            };
            return mainModel;
        }
    }
}
