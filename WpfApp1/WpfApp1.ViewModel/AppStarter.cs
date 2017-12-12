using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Enums;
using Ninject;
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

        public static CardViewModel TooMuchReligionCard { get; set; }

        public static List<CardViewModel> NoReligionCards { get; set; }

        public static CardViewModel NoArmyCard { get; set; }

        public static CardViewModel TooMuchArmyCard { get; set; }

        public static CardViewModel PriestDeadCard { get; set; }

        private static void GenerateCharacters(List<CharacterTypes> types)
        {
            if (types.Contains(CharacterTypes.Priest))
            {
                priest = new CharacterModel
                {
                    CharType = CharacterTypes.Priest,
                    Name = CharacterHelper.GetNameByType(CharacterTypes.Priest)
                };
            }

            if (types.Contains(CharacterTypes.Trader))
            {
                trader = new CharacterModel
                {
                    CharType = CharacterTypes.Trader,
                    Name = CharacterHelper.GetNameByType(CharacterTypes.Trader)
                };
            }
            if (types.Contains(CharacterTypes.Knight))
            {

                knight = new CharacterModel
                {

                    CharType = CharacterTypes.Knight,
                    Name = CharacterHelper.GetNameByType(CharacterTypes.Knight)
                };
            }

            if (types.Contains(CharacterTypes.Butcher))
            {
                butcher = new CharacterModel()
                {
                    CharType = CharacterTypes.Butcher,
                    Name = CharacterHelper.GetNameByType(CharacterTypes.Butcher)
                };
            }
            storyteller = new CharacterModel()
            {
                CharType = CharacterTypes.Storyteller
            };
        }

        private static IEnumerable<CardViewModel> GeneratePriestTasks()
        {
            IKernel kernel = new StandardKernel(new Bindings());
            var helper = kernel.Get<Ihelper>();


            yield return new CardViewModel(priest)
            {
                Id = 1,
                Text = helper.GetBeginning() + "треба збудувати новий монастир",
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
                },
                Tags = CardTags.Priest
            };

            yield return new CardViewModel(priest)
            {
                Id = 2,
                Text = helper.GetBeginning() + "давайте почнемо нови хрестовий похід?",
                YesText = "Бий невірних!",
                NoText = "Придумай щось нове",
                YesHighlight = ResourceTypes.Religion | ResourceTypes.Army,
                NoHighlight = ResourceTypes.Religion,
                OnLeft = model =>
                {
                    model.Religion += 100;
                    model.Army += 100;
                    model.RemoveCard(2);
                },
                OnRight = model =>
                {
                    model.Religion -= 150;
                    model.RemoveCard(2);
                },
                Tags = CardTags.Priest
            };

            yield return new CardViewModel(priest)
            {
                Id = 3,
                Text = helper.GetBeginning() + "дозвольте Папі допомогти державі",
                YesText = "Так, давайте гроші",
                NoText = "Самі розберемось",
                YesHighlight = ResourceTypes.Religion | ResourceTypes.Money,
                NoHighlight = ResourceTypes.Religion,
                OnLeft = model =>
                {
                    model.Religion += 100;
                    model.Money += 100;
                    model.RemoveCard(3);
                },
                OnRight = model =>
                {
                    model.Religion -= 50;
                    model.RemoveCard(3);
                },
                Tags = CardTags.Priest
            };

            yield return new CardViewModel(priest)
            {
                Id = 4,
                Text = helper.GetBeginning() + "солдати не поважають церкву.Розберетесь?",
                YesText = "Так, звісно",
                NoText = "Їх і так забагато",
                YesHighlight = ResourceTypes.Religion | ResourceTypes.Army,
                NoHighlight = ResourceTypes.Religion | ResourceTypes.Army,
                OnLeft = model =>
                {
                    model.Religion += 100;
                    model.Army -= 100;
                    model.RemoveCard(4);
                },
                OnRight = model =>
                {
                    model.Religion -= 100;
                    model.Army += 100;
                    model.RemoveCard(4);
                },
                Tags = CardTags.Priest
            };

            yield return new CardViewModel(priest)
            {
                Id = 5,
                Text = helper.GetBeginning() + "це ж не проблема, що деякі браття виють на місяць?",
                YesText = "Це ваші проблеми",
                NoText = "Генерал!",
                YesHighlight = ResourceTypes.Religion,
                NoHighlight = ResourceTypes.Religion | ResourceTypes.Army,
                OnLeft = model =>
                {
                    model.Religion += 100;
                    model.RemoveCard(5);
                },
                OnRight = model =>
                {
                    model.Religion -= 100;
                    model.Army += 100;
                    model.RemoveCard(5);
                },
                Tags = CardTags.Priest
            };

            yield return new CardViewModel(priest)
            {
                Id = 6,
                Text = helper.GetBeginning() + "а що як ми зробимо відвідування церкви обов'язковим?",
                YesText ="Ваші справи",
                NoText = "Дайте людям волю!",
                YesHighlight = ResourceTypes.Religion | ResourceTypes.People,
                NoHighlight = ResourceTypes.Religion | ResourceTypes.People,
                OnLeft = model =>
                {
                    model.Religion += 200;
                    model.People -= 200;
                    model.RemoveCard(6);
                },
                OnRight = model =>
                {
                    model.Religion -= 100;
                    model.People += 200;
                    model.RemoveCard(6);
                },
                Tags = CardTags.Priest
            };

            yield return new CardViewModel(priest)
            {
                Id = 7,
                Text = helper.GetBeginning() + "забороніть ліки, вони від лукавого",
                YesText = "Ваші справи",
                NoText = "Дайте людям волю!",
                YesHighlight = ResourceTypes.Religion | ResourceTypes.People,
                NoHighlight = ResourceTypes.Religion | ResourceTypes.People,
                OnLeft = model =>
                {
                    model.Religion += 200;
                    model.People -= 200;
                    model.RemoveCard(7);
                },
                OnRight = model =>
                {
                    model.Religion -= 100;
                    model.People += 200;
                    model.RemoveCard(7);
                },
                Tags = CardTags.Priest
            };

            yield return new CardViewModel(priest)
            {
                Id = 8,
                Text = helper.GetBeginning() + "дозвольте оголосити нас теологічною державою!",
                YesText = "Ваші справи",
                NoText = "Дайте людям волю!",
                YesHighlight = ResourceTypes.Religion | ResourceTypes.People | ResourceTypes.Army | ResourceTypes.Money,
                NoHighlight = ResourceTypes.Religion | ResourceTypes.People,
                OnLeft = model =>
                {
                    model.Religion += 300;
                    model.People -= 200;
                    model.Army -= 200;
                    model.Money -= 200;
                    model.RemoveCard(8);
                },
                OnRight = model =>
                {
                    model.Religion -= 100;
                    model.People += 200;
                    model.RemoveCard(8);
                },
                Tags = CardTags.Priest
            };
        }

        private static IEnumerable<CardViewModel> GenerateKnightTasks()
        {
            IKernel kernel = new StandardKernel(new Bindings());
            var helper = kernel.Get<Ihelper>();

            yield return new CardViewModel(knight)
            {
                Id= 9,
                Text = helper.GetBeginning() + "західні королівства набирають силу! Послати проти них армію?",
                YesText = "Крові кривавому богу!",
                NoText = "Ні, давайте жити дружно",
                YesHighlight = ResourceTypes.People | ResourceTypes.Army,
                NoHighlight = ResourceTypes.Army,
                OnLeft = model =>
                {
                    model.Army += 100;
                    model.People -= 100;
                    model.RemoveCard(9);
                },
                OnRight = model =>
                {
                    model.Army -= 100;
                    model.RemoveCard(9);
                },
                Tags = CardTags.Knight
            };

            yield return new CardViewModel(knight)
            {
                Id = 10,
                Text = helper.GetBeginning() + "на сході люди бунтують і вимагають їжі.",
                YesText = "Нагодуйте їх своїми мечами",
                NoText = "Виділіть їм їжу",
                YesHighlight = ResourceTypes.People | ResourceTypes.Army,
                NoHighlight = ResourceTypes.People,
                OnLeft = model =>
                {
                    model.Army -= 100;
                    model.People -= 100;
                    model.RemoveCard(10);
                },
                OnRight = model =>
                {
                    model.People += 100;
                    model.RemoveCard(10);
                },
                Tags = CardTags.Knight
            };

            yield return new CardViewModel(knight)
            {
                Id = 11,
                Text = helper.GetBeginning() + "давайте збільшимо податок на армію",
                YesText = "Чудова ідея!",
                NoText = "Вам і так досить",
                YesHighlight = ResourceTypes.People | ResourceTypes.Army | ResourceTypes.Money,
                NoHighlight = ResourceTypes.People | ResourceTypes.Army | ResourceTypes.Money,
                OnLeft = model =>
                {
                    model.Army += 100;
                    model.Money += 100;
                    model.People -= 100;
                    model.RemoveCard(11);
                },
                OnRight = model =>
                {
                    model.People += 100;
                    model.Army -= 200;
                    model.Money -= 100;
                    model.RemoveCard(11);
                },
                Tags = CardTags.Knight
            };

            yield return new CardViewModel(knight)
            {
                Id = 12,
                Text = helper.GetBeginning() + "було б непогано організувати загальний призов",
                YesText = "Не служив - не мужик",
                NoText = "Ця ідея непрогресивна.",
                YesHighlight = ResourceTypes.People | ResourceTypes.Army,
                NoHighlight = ResourceTypes.People | ResourceTypes.Army,
                OnLeft = model =>
                {
                    model.Army += 300;
                    model.People -= 300;
                    model.RemoveCard(12);
                },
                OnRight = model =>
                {
                    model.People += 100;
                    model.Army -= 200;
                    model.RemoveCard(12);
                },
                Tags = CardTags.Knight
            };

            yield return new CardViewModel(knight)
            {
                Id = 13,
                Text = helper.GetBeginning() + "дозволите нам пограбувати декілька чужих міст?",
                YesText = "Але зробіть вигляд що я нічого не знаю",
                NoText = "Не рухайте чуже",
                YesHighlight = ResourceTypes.Money | ResourceTypes.Army,
                NoHighlight =  ResourceTypes.Army,
                OnLeft = model =>
                {
                    model.Army += 100;
                    model.Money += 300;
                    model.RemoveCard(13);
                },
                OnRight = model =>
                {
                    model.Army -= 100;
                    model.RemoveCard(13);
                },
                Tags = CardTags.Knight
            };

            yield return new CardViewModel(knight)
            {
                Id = 14,
                Text = helper.GetBeginning() + "треба побудувати велику стіну навколо країни",
                YesText = "Я за!",
                NoText = "Дурниці, ніхто так не робить",
                YesHighlight = ResourceTypes.Money | ResourceTypes.Army,
                NoHighlight = ResourceTypes.Army | ResourceTypes.Money,
                OnLeft = model =>
                {
                    model.Army += 100;
                    model.Money -= 300;
                    model.RemoveCard(14);
                },
                OnRight = model =>
                {
                    model.Army -= 100;
                    model.Money += 50;
                    model.RemoveCard(14);
                },
                Tags = CardTags.Knight
            };

            yield return new CardViewModel(knight)
            {
                Id = 15,
                Text = helper.GetBeginning() + "палац горить! Що рятувати?",
                YesText = "Гарнізон!!!",
                NoText = "Скарбницю!!!",
                YesHighlight = ResourceTypes.Money | ResourceTypes.Army,
                NoHighlight = ResourceTypes.Army | ResourceTypes.Money,
                OnLeft = model =>
                {
                    model.Army += 100;
                    model.Money -= 300;
                    model.RemoveCard(15);
                },
                OnRight = model =>
                {
                    model.Army -= 100;
                    model.Money += 200;
                    model.RemoveCard(15);
                },
                Tags = CardTags.Knight
            };

            yield return new CardViewModel(knight)
            {
                Id = 16,
                Text = helper.GetBeginning() + "кругом зрада! Монахи зводять на вас наклепи",
                YesText = "Ганьба!",
                NoText = "Це перемога",
                YesHighlight = ResourceTypes.Religion | ResourceTypes.Army,
                NoHighlight = ResourceTypes.Army | ResourceTypes.Religion,
                OnLeft = model =>
                {
                    model.Army += 150;
                    model.Religion -= 150;
                    model.RemoveCard(16);
                },
                OnRight = model =>
                {
                    model.Army -= 100;
                    model.Religion += 100;
                    model.RemoveCard(16);
                },
                Tags = CardTags.Knight
            };
        }

        private static IEnumerable<CardViewModel> GenerateTraderTasks()
        {
            IKernel kernel = new StandardKernel(new Bindings());
            var helper = kernel.Get<Ihelper>();

            yield return new CardViewModel(trader)
            {
                Id=17,
                Text = helper.GetBeginning() + "ми знайшли шахту повну золота.Продовжувати копати?",
                YesText = "Так",
                NoText = "Хай шахтарі відпочинуть",
                YesHighlight = ResourceTypes.Money | ResourceTypes.People,
                NoHighlight =  ResourceTypes.People,
                OnLeft = model =>
                {
                    model.Money += 100;
                    model.People -= 100;
                    model.RemoveCard(17);
                },
                OnRight = model =>
                {
                    model.People += 100;
                    model.RemoveCard(17);
                },
                Tags = CardTags.Trader
            };

            yield return new CardViewModel(trader)
            {
                Id = 18,
                Text = helper.GetBeginning() + "давайте прокладемо новий торговий шлях на схід?",
                YesText = "Хай гроші течуть рікою!",
                NoText = "Церва буде проти",
                YesHighlight = ResourceTypes.Money | ResourceTypes.Religion,
                NoHighlight = ResourceTypes.Money | ResourceTypes.Religion,
                OnLeft = model =>
                {
                    model.Money += 200;
                    model.Religion -= 100;
                    model.RemoveCard(18);
                },
                OnRight = model =>
                {
                    model.Religion += 100;
                    model.Money -= 50;
                    model.RemoveCard(18);
                },
                Tags = CardTags.Trader
            };

            yield return new CardViewModel(trader)
            {
                Id = 19,
                Text = helper.GetBeginning() + "якщо ми зменшимо витрати, мизможемо отримати величезний прибуток",
                YesText = "Доведеться затягнути пасок",
                NoText = "Нам і так добре",
                YesHighlight = ResourceTypes.Money | ResourceTypes.Religion | ResourceTypes.Army | ResourceTypes.People,
                NoHighlight = ResourceTypes.Money,
                OnLeft = model =>
                {
                    model.Money += 360;
                    model.Religion -= 100;
                    model.Army -= 100;
                    model.People -= 100;
                    model.RemoveCard(19);
                },
                OnRight = model =>
                {
                    model.Money -= 20;
                    model.RemoveCard(19);
                },
                Tags = CardTags.Trader
            };

            yield return new CardViewModel(trader)
            {
                Id = 20,
                Text = helper.GetBeginning() + "якщо продати кілька кошиків монахів..",
                YesText = "Ні слова більше! Продавайте!",
                NoText = "А це не богохульство?",
                YesHighlight = ResourceTypes.Money | ResourceTypes.Religion,
                NoHighlight = ResourceTypes.Money | ResourceTypes.Religion,
                OnLeft = model =>
                {
                    model.Money += 200;
                    model.Religion -= 100;
                    model.RemoveCard(20);
                },
                OnRight = model =>
                {
                    model.Money -= 100;
                    model.Religion += 100;
                    model.RemoveCard(20);
                },
                Tags = CardTags.Trader
            };

            yield return new CardViewModel(trader)
            {
                Id = 21,
                Text = helper.GetBeginning() + "ми можемо продавати зброю сусідам..",
                YesText = "Тепер ми пацифісти",
                NoText = "Зрада? Ніколи!",
                YesHighlight = ResourceTypes.Money | ResourceTypes.Army,
                NoHighlight = ResourceTypes.Money | ResourceTypes.Army,
                OnLeft = model =>
                {
                    model.Money += 200;
                    model.Army -= 100;
                    model.RemoveCard(21);
                },
                OnRight = model =>
                {
                    model.Money -= 100;
                    model.Army += 100;
                    model.RemoveCard(21);
                },
                Tags = CardTags.Trader
            };

            yield return new CardViewModel(trader)
            {
                Id = 22,
                Text = helper.GetBeginning() + "може займемося алхімією?",
                YesText = "Звучить цікаво",
                NoText = "Це неправда",
                YesHighlight = ResourceTypes.Money | ResourceTypes.Religion,
                NoHighlight = ResourceTypes.Money | ResourceTypes.Religion,
                OnLeft = model =>
                {
                    model.Money += 200;
                    model.Religion -= 100;
                    model.RemoveCard(22);
                },
                OnRight = model =>
                {
                    model.Money -= 100;
                    model.Religion += 100;
                    model.RemoveCard(22);
                },
                Tags = CardTags.Trader
            };

            yield return new CardViewModel(trader)
            {
                Id = 23,
                Text = helper.GetBeginning() + "якщо ми не збудуємо міст,люди будуть далі витрачати роки на обхід",
                YesText = "Все для народу",
                NoText = "Роки чекали, ще почекають",
                YesHighlight = ResourceTypes.Money | ResourceTypes.People,
                NoHighlight = ResourceTypes.Money | ResourceTypes.People,
                OnLeft = model =>
                {
                    model.Money -= 200;
                    model.People += 300;
                    model.RemoveCard(23);
                },
                OnRight = model =>
                {
                    model.Money -= 100;
                    model.People -= 200;
                    model.RemoveCard(23);
                },
                Tags = CardTags.Trader
            };

            yield return new CardViewModel(trader)
            {
                Id = 24,
                Text = helper.GetBeginning() + "давайте продамо вашу корону на аукціоні?",
                YesText = "Я готовий",
                NoText = "Це вже занадто. Кат!",
                YesHighlight = ResourceTypes.Money | ResourceTypes.People,
                NoHighlight =  ResourceTypes.People,
                OnLeft = model =>
                {
                    model.Money += 200;
                    model.People -= 100;
                    model.RemoveCard(24);
                },
                OnRight = model =>
                {
                    model.People += 200;
                    model.Next = GenerateDeathCards().FirstOrDefault(x =>
                        x.Tags.HasFlag(CardTags.Trader) && x.Tags.HasFlag(CardTags.Death));
                    model.RemoveCard(24);
                },
                Tags = CardTags.Trader
            };
        }

        private static IEnumerable<CardViewModel> GenerateButcherTasks()
        {

            IKernel kernel = new StandardKernel(new Bindings());
            var helper = kernel.Get<Ihelper>();

            yield return new CardViewModel(butcher)
            {
                Id = 25,
                Text = helper.GetBeginning() + "надто багатьох треба стратити. Мені потрібна допомога армії",
                YesText = "Від них і так нема користі",
                NoText = "Сам справишся",
                YesHighlight = ResourceTypes.Army | ResourceTypes.People,
                NoHighlight = ResourceTypes.People,
                OnLeft = model =>
                {
                    model.Army -= 100;
                    model.People -= 200;
                    model.RemoveCard(25);
                },
                OnRight = model =>
                {
                    model.People -= 100;
                    model.RemoveCard(25);
                },
                Tags = CardTags.Butcher
            };

            yield return new CardViewModel(butcher)
            {
                Id = 26,
                Text = helper.GetBeginning() + "обнімашки?",
                YesText = "Ну давай",
                NoText = "Ти здурів?",
                OnLeft = model =>
                {
                    model.RemoveCard(26);
                },
                OnRight = model =>
                {
                    model.RemoveCard(26);
                },
                Tags = CardTags.Butcher
            };

            yield return new CardViewModel(butcher)
            {
                Id = 27,
                Text = helper.GetBeginning() + "не хочете спробувати грибів?",
                YesText = "Давай свою новинку",
                NoText = "Це ж мухомор!",
                OnLeft = model =>
                {
                    foreach (var card in model.Deck)
                    {
                        card.Text = new string(card.Text.ToCharArray().Reverse().ToArray());
                        card.YesText = new string(card.YesText.ToCharArray().Reverse().ToArray());
                        card.NoText = new string(card.NoText.ToCharArray().Reverse().ToArray());
                    }
                    model.RemoveCard(27);
                },
                OnRight = model =>
                {
                    model.RemoveCard(27);
                },
                Tags = CardTags.Butcher
            };

            yield return new CardViewModel(butcher)
            {
                Id = 28,
                Text = helper.GetBeginning() + "давайте створимо нове свято. Я в костюмі буду роздавати дітям подарунки!",
                YesText = "Чудова ідея",
                NoText = "Церква убде проти",
                YesHighlight = ResourceTypes.Religion | ResourceTypes.People,
                NoHighlight = ResourceTypes.People | ResourceTypes.Religion,
                OnLeft = model =>
                {
                    model.People += 100;
                    model.Religion -= 100;
                    model.RemoveCard(28);
                },
                OnRight = model =>
                {
                    model.People -= 100;
                    model.Religion += 100;
                    model.RemoveCard(28);
                },
                Tags = CardTags.Butcher
            };

            yield return new CardViewModel(butcher)
            {
                Id = 29,
                Text = helper.GetBeginning() + "я серійний вбивця",
                YesText = "Ніхто не ідеальний",
                NoText = "Припини це",
                YesHighlight = ResourceTypes.People,
                NoHighlight = ResourceTypes.People,
                OnLeft = model =>
                {
                    model.People -= 100;
                    model.RemoveCard(29);
                },
                OnRight = model =>
                {
                    model.People += 100;
                    model.RemoveCard(29);
                },
                Tags = CardTags.Butcher
            };

            yield return new CardViewModel(butcher)
            {
                Id = 30,
                Text = helper.GetBeginning() + "може одружитеся з моєю донькою?",
                YesText = "Чому б і ні?",
                NoText = "Не хочу",
                YesHighlight = ResourceTypes.People | ResourceTypes.Religion | ResourceTypes.Army | ResourceTypes.Money,
                OnLeft = model =>
                {
                    model.People += 100;
                    model.Religion += 100;
                    model.Army += 100;
                    model.Money += 100;
                    model.RemoveCard(30);
                },
                OnRight = model =>
                {
                    model.People += 100;
                    model.RemoveCard(30);
                },
                Tags = CardTags.Butcher
            };

            yield return new CardViewModel(butcher)
            {
                Id = 31,
                Text = helper.GetBeginning() + "довольте мені відкрити зоопарк",
                YesText = "Це буде весело",
                NoText = "А чим годуватимеш?",
                YesHighlight = ResourceTypes.People,
                NoHighlight = ResourceTypes.People,
                OnLeft = model =>
                {
                    model.People -= 200;
                    model.RemoveCard(31);
                },
                OnRight = model =>
                {
                    model.People += 100;
                    model.RemoveCard(31);
                },
                Tags = CardTags.Butcher
            };

            yield return new CardViewModel(butcher)
            {
                Id = 32,
                Text = helper.GetBeginning() + "насправді я жінка",
                YesText = "І?",
                NoText = "Я розкажу єпископу",
                NoHighlight = ResourceTypes.Religion,
                OnLeft = model =>
                {
                    model.RemoveCard(32);
                },
                OnRight = model =>
                {
                    model.Religion -= 100;
                    model.RemoveCard(32);
                },
                Tags = CardTags.Butcher
            };

        }

        private static IEnumerable<CardViewModel> GenerateDeathCards()
        {
            yield return new CardViewModel(priest)
            {
                Id = 101,
                Text = "Єпископ помер. Бажаєте назначити нового?",
                YesText = "Так, без нього ніяк",
                NoText = "Без нього веселіше!",
                NoHighlight = ResourceTypes.Religion,
                OnLeft = model =>
                {
                    GenerateCharacters(new List<CharacterTypes>
                    {
                        CharacterTypes.Priest
                    });
                    foreach (var card in model.GetCards(x => x.Tags.HasFlag(CardTags.Priest)))
                    {
                        card.Name = priest.Name;
                    }
                    model.RemoveCard(101);
                },
                OnRight = model =>
                {
                    model.Religion -= 50;
                    model.RemoveCards(x=>x.Tags.HasFlag(CardTags.Priest));
                },
                Tags = CardTags.Priest|CardTags.Death
            };

            yield return new CardViewModel(trader)
            {
                Id = 102,
                Text = "Купець помер. Бажаєте назначити нового?",
                YesText = "Так, без нього ніяк",
                NoText = "Самі справимось",
                OnLeft = model =>
                {
                    GenerateCharacters(new List<CharacterTypes>
                    {
                        CharacterTypes.Trader
                    });
                    foreach (var card in model.GetCards(x => x.Tags.HasFlag(CardTags.Trader)))
                    {
                        card.Name = trader.Name;
                    }
                    model.RemoveCard(102);
                },
                OnRight = model =>
                {
                    model.RemoveCards(x => x.Tags.HasFlag(CardTags.Trader));
                },
                Tags = CardTags.Trader | CardTags.Death
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

            TooMuchReligionCard = new CardViewModel(storyteller)
            {
                Id = 100,
                Text = "Церква захоплює владу в країні, а з вас виходить непоганий мученик.",
                ImagePath = "Resources/Endings/TooMuchReligion.jpg"
            };

            NoReligionCards = new List<CardViewModel>
            {
                new CardViewModel(storyteller)
                {
                    Id= 100,
                    Text = "Вітаю, ви єретик! Вас спалили, а ваше ім'я заборонено згадувати.",
                    ImagePath = "Resources/Endings/NoReligion1.png"
                },
                new CardViewModel(storyteller)
                {
                    Id= 100,
                    Text = "Погана новина: ви єретик і ваше тіло згодували собакам. Хороша новина: собачки такі милі.",
                    ImagePath = "Resources/Endings/NoReligion2.jpg"
                }
            };

            NoArmyCard = new CardViewModel(storyteller)
            {
                Id = 100,
                Text = "Армії більше нема, а з вас воїн так собі.",
                ImagePath = "Resources/Endings/noarmy.jpg"
            };

            TooMuchArmyCard = new CardViewModel(storyteller)
            {
                Id=100,
                Text = "Армія захоплює владу в країні, а вас просто закололи увісні.",
                ImagePath = "Resources/Endings/TooMuchArmy.jpg"
            };
        }

        public static MainViewModel GetMainView()
        {
            GenerateCharacters(new List<CharacterTypes>
            {
                CharacterTypes.Priest,
                CharacterTypes.Butcher,
                CharacterTypes.Knight,
                CharacterTypes.Trader,
                CharacterTypes.Storyteller
            });
            GenerateEndings();
            var priestTasks = GeneratePriestTasks().ToList();
            var knightTasks = GenerateKnightTasks().ToList();
            var traderTasks = GenerateTraderTasks().ToList();
            var butcherTasks = GenerateButcherTasks().ToList();
            var deathTasks = GenerateDeathCards().ToList();
            var context = new GameContext();
            var contextModel = new ContextViewModel(context)
            {
                Deck = new ObservableCollection<CardViewModel>(
                 priestTasks
                .Union(knightTasks)
                .Union(traderTasks)
                .Union(butcherTasks)
                .Union(deathTasks))
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
