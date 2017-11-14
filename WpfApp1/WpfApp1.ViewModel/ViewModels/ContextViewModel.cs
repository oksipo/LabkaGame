using System;
using System.Collections.ObjectModel;
using System.Linq;
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

        public CardViewModel GetNextCard()
        {
            if (Deck.Count == 0)
            {
                Next = AppStarter.WinCard;
            }
            if (Money <= 0)
            {
                Next = AppStarter.NoMoneyCard;
            }

            if (Money >= 1000)
            {
                Next = AppStarter.TooMuchMoneyCards.GetRandom();
            }

            if (People >= 1000)
            {
                Next = AppStarter.TooMuchPeopleCard;
            }

            if (People <= 0)
            {
                Next = AppStarter.NoPeopleCard;
            }

            if (Religion >= 1000)
            {
                Next = AppStarter.TooMuchReligionCard;
            }

            if (Religion <= 0)
            {
                Next = AppStarter.NoReligionCards.GetRandom();
            }

            var temp = Next;
            Next = null;
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

        public ContextViewModel(GameContext context)
        {
            this.Context = context;
        }
    }
}
