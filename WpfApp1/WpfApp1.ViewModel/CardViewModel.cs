using System;
using WpfApp1.Helpers;
using WpfApp1.Model.Models;

namespace WpfApp1.ViewModel
{
    public class CardViewModel : BaseViewModel
    {

        private string text;
        private string imagePath;
        private string name;

        public string Text
        {
            get => this.text;
            set
            {
                this.text = value;
                OnPropertyChanged(nameof(Text));
            }
        }

        public string ImagePath
        {
            get => this.imagePath;
            set
            {
                this.imagePath = value;
                OnPropertyChanged(nameof(ImagePath));
            }
        }

        public string Name
        {
            get => this.name;
            set
            {
                this.name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public Action<ContextViewModel> OnLeft { get; set; }

        public Action<ContextViewModel> OnRight { get; set; }

        public CardViewModel(CharacterModel character, TaskModel task)
        {
            this.Text = task.Text;
            this.ImagePath = CharacterHelper.GetPictureByType(character.CharType);
            this.Name = character.Name;
        }
    }
}
