using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
            var Card = new CardViewModel(testChar, testTask);
            var Main = new MainViewModel
            {
                TaskCard = Card
            };
            this.DataContext = Main;
        }
    }
}
