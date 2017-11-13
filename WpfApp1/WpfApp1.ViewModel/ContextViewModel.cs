using System.Runtime.CompilerServices;
using WpfApp1.Model.Models;

namespace WpfApp1.ViewModel
{
    public class ContextViewModel : BaseViewModel
    {
        public GameContext Context;

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

        public ContextViewModel(GameContext context)
        {
            this.Context = context;
        }
    }
}
