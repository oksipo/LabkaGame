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
            return this.Deck.GetRandom();
        }

        public void RemoveCard(int Id)
        {
            this.Deck.Remove(this.Deck.FirstOrDefault(x => x.Id == Id));
        }

        public ContextViewModel(GameContext context)
        {
            this.Context = context;
        }
    }
}
