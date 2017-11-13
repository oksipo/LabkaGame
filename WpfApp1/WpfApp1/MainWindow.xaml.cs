using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using Enums;
using WpfApp1.Helpers;
using WpfApp1.Model.Models;
using WpfApp1.ViewModel;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.MoneyBar.Foreground = new SolidColorBrush(Colors.LawnGreen);
            this.ArmyBar.Foreground = new SolidColorBrush(Colors.LawnGreen);
            this.PeopleBar.Foreground = new SolidColorBrush(Colors.LawnGreen);
            this.ReligionBar.Foreground = new SolidColorBrush(Colors.LawnGreen);
            var main = AppStarter.GetMainView();
            this.DataContext = main;
        }

        private void Left_Click(object sender, RoutedEventArgs e)
        {
            var main = this.DataContext as MainViewModel;
            main.TaskCard.OnLeft.Invoke(main.Context);
            main.TaskCard = main.Context.GetNextCard();
        }

        private void Right_Click(object sender, RoutedEventArgs e)
        {
            var main = this.DataContext as MainViewModel;
            main.TaskCard.OnRight.Invoke(main.Context);
            main.TaskCard = main.Context.GetNextCard();
        }

        private void Left_OnMouseEnter(object sender, MouseEventArgs e)
        {
            var main = this.DataContext as MainViewModel;
            if (main.TaskCard.YesHighlight.HasFlag(ResourceTypes.Money))
            {
                this.MoneyBar.Foreground = new SolidColorBrush(Colors.Gold);
            }

            if (main.TaskCard.YesHighlight.HasFlag(ResourceTypes.Army))
            {
                this.ArmyBar.Foreground = new SolidColorBrush(Colors.Gold);
            }

            if (main.TaskCard.YesHighlight.HasFlag(ResourceTypes.People))
            {
                this.PeopleBar.Foreground = new SolidColorBrush(Colors.Gold);
            }

            if (main.TaskCard.YesHighlight.HasFlag(ResourceTypes.Religion))
            {
                this.ReligionBar.Foreground = new SolidColorBrush(Colors.Gold);
            }
        }

        private void Left_OnMouseLeave(object sender, MouseEventArgs e)
        {
            this.MoneyBar.Foreground = new SolidColorBrush(Colors.LawnGreen);
            this.ArmyBar.Foreground = new SolidColorBrush(Colors.LawnGreen);
            this.PeopleBar.Foreground = new SolidColorBrush(Colors.LawnGreen);
            this.ReligionBar.Foreground = new SolidColorBrush(Colors.LawnGreen);
        }

        private void Right_OnMouseEnter(object sender, MouseEventArgs e)
        {
            var main = this.DataContext as MainViewModel;
            if (main.TaskCard.NoHighlight.HasFlag(ResourceTypes.Money))
            {
                this.MoneyBar.Foreground = new SolidColorBrush(Colors.Gold);
            }

            if (main.TaskCard.NoHighlight.HasFlag(ResourceTypes.Army))
            {
                this.ArmyBar.Foreground = new SolidColorBrush(Colors.Gold);
            }

            if (main.TaskCard.NoHighlight.HasFlag(ResourceTypes.People))
            {
                this.PeopleBar.Foreground = new SolidColorBrush(Colors.Gold);
            }

            if (main.TaskCard.NoHighlight.HasFlag(ResourceTypes.Religion))
            {
                this.ReligionBar.Foreground = new SolidColorBrush(Colors.Gold);
            }
        }

        private void Right_OnMouseLeave(object sender, MouseEventArgs e)
        {
            this.MoneyBar.Foreground = new SolidColorBrush(Colors.LawnGreen);
            this.ArmyBar.Foreground = new SolidColorBrush(Colors.LawnGreen);
            this.PeopleBar.Foreground = new SolidColorBrush(Colors.LawnGreen);
            this.ReligionBar.Foreground = new SolidColorBrush(Colors.LawnGreen);
        }
    }
}
