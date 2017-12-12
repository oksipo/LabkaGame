using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using Enums;
using WpfApp1.Model.Models;
using WpfApp1.ViewModel;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public bool Lost { get; set; }
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
            main.TaskCard.OnLeft?.Invoke(main.Context);
            var storyboard = new Storyboard
            {
                Duration = new Duration(TimeSpan.FromSeconds(0.5))
            };
            var rotateAnimation = new DoubleAnimation()
            {
                From = 0,
                To = 360,
                Duration = storyboard.Duration
            };
            Storyboard.SetTarget(rotateAnimation, this.MainImage);
            Storyboard.SetTargetProperty(rotateAnimation, new PropertyPath("(UIElement.RenderTransform).(RotateTransform.Angle)"));
            storyboard.Children.Add(rotateAnimation);
            storyboard.Begin();
            if (!main.Context.IsEnd)
            {
                main.TaskCard = main.Context.GetNextCard();
            }
            else
            {
                if (!Lost)
                {
                    Lost = true;
                    main.History.Records.Add(new HistoryRecord
                    {
                        PlayDate = DateTime.Today,
                        Years = main.Context.Years
                    });
                    main.History.Serialize();
                }
            }
        }

        private void Right_Click(object sender, RoutedEventArgs e)
        {
            var main = this.DataContext as MainViewModel;
            main.TaskCard.OnRight?.Invoke(main.Context);
            var storyboard = new Storyboard
            {
                Duration = new Duration(TimeSpan.FromSeconds(0.5))
            };
            var rotateAnimation = new DoubleAnimation()
            {
                From = 360,
                To = 0,
                Duration = storyboard.Duration
            };
            Storyboard.SetTarget(rotateAnimation, this.MainImage);
            Storyboard.SetTargetProperty(rotateAnimation, new PropertyPath("(UIElement.RenderTransform).(RotateTransform.Angle)"));
            storyboard.Children.Add(rotateAnimation);
            storyboard.Begin();
            if (!main.Context.IsEnd)
            {
                main.TaskCard = main.Context.GetNextCard();
            }
            else
            {
                if (!Lost)
                {
                    Lost = true;
                    main.History.Records.Add(new HistoryRecord
                    {
                        PlayDate = DateTime.Now,
                        Years = main.Context.Years
                    });
                    main.History.Serialize();
                }
            }
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var newWindow =new HistoryTable();
            newWindow.DataContext = (this.DataContext as MainViewModel).History;
            newWindow.Show();
        }
    }
}
