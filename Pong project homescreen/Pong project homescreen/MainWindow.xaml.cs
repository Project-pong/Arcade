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
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Image_MouseUp(object sender, RoutedEventArgs e)
        {
            string P1Naam = Player1_naam.Text;
            string P2Naam = Player2_naam.Text;
            
            //Spel starten
            ClassicPong game = new ClassicPong(P1Naam);
            game.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Hidden;
        }

        private void Image2_MouseUp(object sender, RoutedEventArgs e)
        {
            string P1Naam = Player1_naam.Text;
            string P2Naam = Player2_naam.Text;

            //Spel starten
            NijntjePong game2 = new NijntjePong();
            game2.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Hidden;
        }

        private void Classic_Pong_MouseEnter(object sender, MouseEventArgs e)
        {
            border_classic.BorderBrush = Brushes.Red;
        }

        private void Classic_Pong_MouseLeave(object sender, MouseEventArgs e)
        {
            border_classic.BorderBrush = Brushes.Gray;
        }

        private void Nijntje_Pong_MouseEnter(object sender, MouseEventArgs e)
        {
            border_nijntje.BorderBrush = Brushes.Red;
        }
        private void Nijntje_Pong_MouseLeave(object sender, MouseEventArgs e)
        {
            border_nijntje.BorderBrush = Brushes.Gray;
        }

      
    }
}
