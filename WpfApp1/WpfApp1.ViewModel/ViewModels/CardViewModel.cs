﻿using System;
using Enums;
using WpfApp1.Helpers;
using WpfApp1.Model.Models;

namespace WpfApp1.ViewModel
{
    public class CardViewModel : BaseViewModel
    {

        private string text;
        private string imagePath;
        private CharacterModel character;

        public int Id { get; set; }

        public string YesText { get; set; }

        public string NoText { get; set; }

        public ResourceTypes YesHighlight { get; set; }

        public ResourceTypes NoHighlight { get; set; }

        public CardTags Tags;

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
            get => this.character.Name;
            set
            {
                this.character.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public Action<ContextViewModel> OnLeft { get; set; }

        public Action<ContextViewModel> OnRight { get; set; }

        public CardViewModel(CharacterModel character)
        {
            this.ImagePath = CharacterHelper.GetPictureByType(character.CharType);
            this.character = character;
        }
    }
}
