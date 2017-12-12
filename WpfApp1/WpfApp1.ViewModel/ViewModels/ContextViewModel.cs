using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using WpfApp1.Helpers;
using WpfApp1.Model.Models;

namespace WpfApp1.ViewModel
{
    public class ContextViewModel : BaseViewModel
    {
        public GameContext Context;

        public ObservableCollection<CardViewModel> Deck { get; set; }

        public CardViewModel Next { get; set; }

        public int Religion
        {
            get => this.Context.Religion;
            set
            {
                this.Context.Religion = value;
                OnPropertyChanged(nameof(Religion));
            }
        }

        public int Money
        {
            get => this.Context.Money;
            set
            {
                this.Context.Money = value;
                OnPropertyChanged(nameof(Money));
            }
        }

        public int People
        {
            get => this.Context.People;
            set
            {
                this.Context.People = value;
                OnPropertyChanged(nameof(People));
            }
        }

        public int Army
        {
            get => this.Context.Army;
            set
            {
                this.Context.Army = value;
                OnPropertyChanged(nameof(Army));
            }
        }

        public int Years
        {
            get => this.Context.Years;
            set
            {
                this.Context.Years = value;
                OnPropertyChanged(nameof(YearsString));
            }
        }

        public string YearsString
        {
            get => $"Ви при владі {Years} років";
            set
            {
                this.YearsString = value;
                OnPropertyChanged(nameof(YearsString));
            }
        }

        public bool IsEnd { get; set; } = false;

        public CardViewModel GetNextCard()
        {
            if (Deck.Count == 0)
            {
                Next = AppStarter.WinCard;
                IsEnd = true;
            }
            if (Money <= 0)
            {
                Next = AppStarter.NoMoneyCard;
                IsEnd = true;
            }

            if (Money >= 1000)
            {
                Next = AppStarter.TooMuchMoneyCards.GetRandom();
                IsEnd = true;
            }

            if (People >= 1000)
            {
                Next = AppStarter.TooMuchPeopleCard;
                IsEnd = true;
            }

            if (People <= 0)
            {
                Next = AppStarter.NoPeopleCard;
                IsEnd = true;
            }

            if (Religion >= 1000)
            {
                Next = AppStarter.TooMuchReligionCard;
                IsEnd = true;
            }

            if (Religion <= 0)
            {
                Next = AppStarter.NoReligionCards.GetRandom();
                IsEnd = true;
            }

            if (Army <= 0)
            {
                Next = AppStarter.NoArmyCard;
                IsEnd = true;
            }

            if (Army >= 1000)
            {
                Next = AppStarter.TooMuchArmyCard;
                IsEnd = true;
            }

            var temp = Next;
            Next = null;
            Years++;
            return temp ?? this.Deck.GetRandom();
        }

        public void RemoveCard(int Id)
        {
            this.Deck.Remove(this.Deck.FirstOrDefault(x => x.Id == Id));
        }

        public void RemoveCards(Func<CardViewModel, bool> criteria)
        {
            this.Deck = new ObservableCollection<CardViewModel>(this.Deck.Except(this.Deck.Where(criteria)));
        }

        public IEnumerable<CardViewModel> GetCards(Func<CardViewModel, bool> criteria)
        {
            return this.Deck.Where(criteria);
        }

        public ContextViewModel(GameContext context)
        {
            this.Context = context;
        }

        public CardViewModel[] UnUsedMethodDeleteMe()
        {
            return Deck.OrderBy(x => x.Name).Select(x=> new 
            {
                x.Id,
                x.Name,
                x.ImagePath
            })
            .Select(x=> new CardViewModel(new CharacterModel())).ToArray();
        }
    }
}
