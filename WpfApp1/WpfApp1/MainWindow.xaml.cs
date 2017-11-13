using System.Windows;
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
            var testChar = new CharacterModel();
            testChar.CharType = CharacterTypes.Priest;
            testChar.Name = CharacterHelper.GetNameByType(testChar.CharType);
            var testTask = new TaskModel();
            testTask.Text = "Мілорд, щурі їдять наші запаси їжі! Направити проти них армію?";
            var context = new GameContext();
            var contextModel = new ContextViewModel(context);
            var Card = new CardViewModel(testChar, testTask);

            Card.OnRight = gameContext =>
            {
                gameContext.People -= 100;
                gameContext.Army += 50;
            };
            Card.OnLeft = gameContext =>
            {
                gameContext.People += 200;
                gameContext.Army -= 100;
                gameContext.Money -= 50;
            };

            var Main = new MainViewModel
            {
                TaskCard = Card,
                Context = contextModel
            };
            this.DataContext = Main;
        }

        private void Left_Click(object sender, RoutedEventArgs e)
        {
            var main = this.DataContext as MainViewModel;
            main.TaskCard.OnLeft.Invoke(main.Context);
        }

        private void Right_Click(object sender, RoutedEventArgs e)
        {
            var main = this.DataContext as MainViewModel;
            main.TaskCard.OnRight.Invoke(main.Context);
        }
    }
}
