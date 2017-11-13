namespace WpfApp1.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private CardViewModel taskCard;
        public CardViewModel TaskCard
        {
            get => this.taskCard;
            set
            {
                this.taskCard = value;
                OnPropertyChanged(nameof(TaskCard));
            }
        }
    }
}
