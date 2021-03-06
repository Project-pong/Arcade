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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Pong_project_homescreen
{
  
    public partial class NijntjePong : Window
    {
        private ImageBrush PongBal2 = new ImageBrush();
        private bool moveUpPlayer2 = false, moveDownPlayer2 = false;
        private bool moveUpPlayer1 = false, moveDownPlayer1 = false;
        const int SPEED = 7;
        private DispatcherTimer gameTimer = new DispatcherTimer();
        
        public NijntjePong(string P1Naam, string P2Naam)
        {
            InitializeComponent();

            gameTimer.Interval = TimeSpan.FromMilliseconds(20);
            gameTimer.Tick += MovePlayers;
            gameTimer.Tick += MoveNijntje;
            gameTimer.Start();

            NijntjeCanvas.Focus();

            PongBal2.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/NijntjebalGoed.png"));
            NijntjeRect.Fill = PongBal2;
            
        }

        private double nijntjeY = 0.0;
        private double nijntjeDirY = 3.0;

        private double nijntjeX = 0.0;
        private double nijntjeDirX = 0.25;
        private void MoveNijntje(object sender, EventArgs e)
        {
            nijntjeY += nijntjeDirY;
            nijntjeX += nijntjeDirX;

            var group = new TransformGroup();
            group.Children.Add(new TranslateTransform(nijntjeX, nijntjeY));
            NijntjeRect.RenderTransform = group;
            if (nijntjeY >= 178.0)
            {
                nijntjeDirY = nijntjeDirY * - 1.0;
            }
            if (nijntjeY <= -196.0)
            {
                nijntjeDirY = nijntjeDirY * -1.0;
            }
        }



        private void MovePlayers(object sender, EventArgs e)
        {
            if (moveUpPlayer2)
            {
                Canvas.SetTop(Player2, Canvas.GetTop(Player2) - SPEED);
            }
            if (moveUpPlayer1)
            {
                Canvas.SetTop(Player1, Canvas.GetTop(Player1) - SPEED);
            }

            if (moveDownPlayer2)
            {
                Canvas.SetTop(Player2, Canvas.GetTop(Player2) + SPEED);
            }

            if (moveDownPlayer1)
            {
                Canvas.SetTop(Player1, Canvas.GetTop(Player1) + SPEED);
            }

        }
        private void KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down)
            {
                moveDownPlayer2 = true;
            }
            if (e.Key == Key.W)
            {
                moveUpPlayer1 = true;
            }
            if (e.Key == Key.Up)
            {
                moveUpPlayer2 = true;
            }
            if (e.Key == Key.S)
            {
                moveDownPlayer1 = true;
            }
            
        }

        private void KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up)
            {
                moveUpPlayer2 = false;
            }
            if (e.Key == Key.W)
            {
                moveUpPlayer1 = false;
            }
            if (e.Key == Key.Down)
            {
                moveDownPlayer2 = false;
            }
            if (e.Key == Key.S)
            {
                moveDownPlayer1 = false;
            }            
            
        }


        
        
       
    }
}
