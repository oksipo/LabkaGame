﻿namespace WpfApp1.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private CardViewModel taskCard;

        private ContextViewModel contextModel;

        public CardViewModel TaskCard
        {
            get => this.taskCard;
            set
            {
                this.taskCard = value;
                OnPropertyChanged(nameof(TaskCard));
            }
        }

        public ContextViewModel Context
        {
            get => this.contextModel;
            set
            {
                this.contextModel = value;
                OnPropertyChanged(nameof(contextModel));
            }
        }
    }
}
