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

namespace Pong_project_homescreen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Window highscores = null;
        public NijntjePong game2 = null;
        public ClassicPong game = null;

        public MainWindow()
        {
            InitializeComponent();
            
        }
        private void Image_MouseUp(object sender, RoutedEventArgs e)
        {
            string P1Naam = Player1_naam.Text;
            string P2Naam = Player2_naam.Text;
            
            //Spel starten
            ClassicPong game = new ClassicPong(P1Naam, P2Naam);
            game.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Hidden;
        }


        
        private void Image2_MouseUp(object sender, RoutedEventArgs e)
        {
            string P1Naam = Player1_naam.Text;
            string P2Naam = Player2_naam.Text;

            //Spel starten
            game2 = new NijntjePong(P1Naam, P2Naam);
            game2.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Hidden;

            
        }

        private void Classic_Pong_MouseEnter(object sender, MouseEventArgs e)
        {
            //als je met de muis over het plaatje hovered wordt de border rood.
            border_classic.BorderBrush = Brushes.Red;
        }

        private void Classic_Pong_MouseLeave(object sender, MouseEventArgs e)
        {
            //als je niet meer me je muis over het plaatje hovered wordt de border weer grijs.
            border_classic.BorderBrush = Brushes.Gray;
        }

        private void Nijntje_Pong_MouseEnter(object sender, MouseEventArgs e)
        {
            //als je met de muis over het plaatje hovered wordt de border rood.
            border_nijntje.BorderBrush = Brushes.Red;
        }
        private void Nijntje_Pong_MouseLeave(object sender, MouseEventArgs e)
        {

            //als je niet meer me je muis over het plaatje hovered wordt de border weer grijs.
            border_nijntje.BorderBrush = Brushes.Gray;
        }


        private void createHighScores(string naam1, string naam2)
        {

/*            var label2 = game2.TimerMin.Content.ToString();
            var label = game2.victory2.Content.ToString();
*/            highscores = new Window1("x", "y", "z");
            highscores.ShowDialog();
/*
            highscores.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Hidden;
            this.highscores = highscores;*/
        }
        private void HighscoreLabel_Click(object sender, RoutedEventArgs e)
        {
            string P1Naam = Player1_naam.Text;
            string P2Naam = Player2_naam.Text;

            this.createHighScores(P1Naam, P2Naam);
            //Window1 highscores = new Window1(string P1Naam, string P2Naam);
        }
    }
}
