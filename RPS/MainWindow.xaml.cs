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

namespace RPS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        int HumanChoice = 0;
        int AIChoice = 0;
        int points = 0;
        Random Ai = new Random();
        private void Sten_Click(object sender, RoutedEventArgs e)
        {
            HumanChoice = 1;
            Human.Source = new BitmapImage(new Uri("C:/Users/erik2708/source/repos/RPS/RPS/img/Rock.png"));
            AIChoose();
        }

        private void Saks_Click(object sender, RoutedEventArgs e)
        {
            HumanChoice = 2;
            Human.Source = new BitmapImage(new Uri("C:/Users/erik2708/source/repos/RPS/RPS/img/Scissors.png"));
            AIChoose();
        }

        private void Papir_Click(object sender, RoutedEventArgs e)
        {
            HumanChoice = 3;
            Human.Source = new BitmapImage(new Uri("C:/Users/erik2708/source/repos/RPS/RPS/img/Paper.png"));
            AIChoose();
        }
        private void AIChoose()
        {
            Sten.IsEnabled = false;
            Saks.IsEnabled = false;
            Papir.IsEnabled = false;
            AIChoice = Ai.Next(1, 4);
            if(AIChoice == 1)
            {
                AI.Source = new BitmapImage(new Uri("C:/Users/erik2708/source/repos/RPS/RPS/img/Rock.png"));
            }
            else if(AIChoice == 2)
            {
                AI.Source = new BitmapImage(new Uri("C:/Users/erik2708/source/repos/RPS/RPS/img/Scissors.png"));
            }
            else if (AIChoice == 3)
            {
                AI.Source = new BitmapImage(new Uri("C:/Users/erik2708/source/repos/RPS/RPS/img/Paper.png"));
            }
            ScoreCalculate();
        }
        async void Wait()
        {
            await Task.Delay(1000);
            ReactivareButtons();
        }
        private void ScoreCalculate()
        {
            if(HumanChoice == AIChoice) { }
            else if (AIChoice - HumanChoice == 1 || AIChoice - HumanChoice == -2)
            {
                points++;
                Score.Text = "Score: " + points;
            }
            else if(HumanChoice - AIChoice == 1 || HumanChoice - AIChoice == -2)
            {
                points = 0;
                Score.Text = "Score: " + points;
            }
            Wait();
        }
        private void ReactivareButtons()
        {
            Human.Source = new BitmapImage(new Uri("C:/Users/erik2708/source/repos/RPS/RPS/img/Thinking.png"));
            AI.Source = new BitmapImage(new Uri("C:/Users/erik2708/source/repos/RPS/RPS/img/Thinking.png"));
            Sten.IsEnabled = true;
            Saks.IsEnabled = true;
            Papir.IsEnabled = true;
        }
    }
}
