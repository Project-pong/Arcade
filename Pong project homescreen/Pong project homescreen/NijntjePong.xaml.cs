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

        private double nijntjeX = 0.0;
        private double nijntjeY = 0.0;
        private double nijntjeDirX = -2.25;
        private double nijntjeDirY = 3.0;
        int puntenP1 = 1;
        int puntenP2 = 1;

        //houdt bij welkle speler als laatste heeft gekaatst
        int lastPlayerHit = 0;

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

        private void MoveNijntje(object sender, EventArgs e)
        {
            nijntjeY += nijntjeDirY;
            nijntjeX += nijntjeDirX;

            var group = new TransformGroup();
            group.Children.Add(new TranslateTransform(nijntjeX, nijntjeY));
            NijntjeRect.RenderTransform = group;
            if (nijntjeY >= 178.0)
            {
                nijntjeDirY = nijntjeDirY * -1.0;
            }
            if (nijntjeY <= -196.0)
            {
                nijntjeDirY = nijntjeDirY * -1.0;
            }

            //bereken de posities van nijntje en de twee spelers
            Rect positionNijntje = new Rect(Canvas.GetLeft(NijntjeRect) + nijntjeX, Canvas.GetTop(NijntjeRect) + nijntjeY, 40, 40);
            Rect player1position = new Rect(Canvas.GetLeft(Player1), Canvas.GetTop(Player1), Player1.Width, Player1.Height);
            Rect player2position = new Rect(Canvas.GetLeft(Player2), Canvas.GetTop(Player2), Player2.Width, Player2.Height);

            //kaats nijntje als speler 1 wordt geraakt
            if (positionNijntje.IntersectsWith(player1position) && lastPlayerHit != 1)
            {
                lastPlayerHit = 1;
                nijntjeDirX *= -1;
            }
            //kaats nijntje als speler 2 wordt geraakt
            if (positionNijntje.IntersectsWith(player2position) && lastPlayerHit != 2)
            {
                lastPlayerHit = 2;
                nijntjeDirX *= -1;
            }
            //doelpunt voor player 1
            if (nijntjeX >= 360)
            {
                nijntjeDirY = nijntjeDirY * -0;
                nijntjeDirX = nijntjeDirX * -0;
                nijntjeX = 0;
                nijntjeY = 0;
                nijntjeDirX = 2.25;
                nijntjeDirY = 3.0;
            }
            if (nijntjeX >= 357)
            {
                scoreP1.Content = puntenP1++;
            }
            //doelpunt voor player 2
            if (nijntjeX <= -380)
            {
                nijntjeDirY = nijntjeDirY * -0;
                nijntjeDirX = nijntjeDirX * -0;            
                nijntjeX = 0;
                nijntjeY = 0;
                nijntjeDirX = -2.25;
                nijntjeDirY = 3.0;
            }
            if (nijntjeX <= -377)
            {
                scoreP2.Content = puntenP2++;
            }
            //speler 1 heeft gewonnen
            if (puntenP1 == 11)
            {
                nijntjeDirY = nijntjeDirY * -0;
                nijntjeDirX = nijntjeDirX * -0;
            }
            //speler 2 heeft gewonnen
            if (puntenP2 == 11)
            {
                nijntjeX = 0;
                nijntjeY = 0;
                nijntjeDirY = nijntjeDirY * -0;
                nijntjeDirX = nijntjeDirX * -0;
            }
        }



        private void MovePlayers(object sender, EventArgs e)
        {
            if (moveUpPlayer2)
            {
                if (Canvas.GetTop(Player2) > 0)
                {
                    Canvas.SetTop(Player2, Canvas.GetTop(Player2) - SPEED);
                }
            }

            if (moveUpPlayer1)
            {
                if (Canvas.GetTop(Player1) > 0)
                {
                    Canvas.SetTop(Player1, Canvas.GetTop(Player1) - SPEED);
                }
            }

            if (moveDownPlayer2)
            {
                if (Canvas.GetTop(Player2) < 346)
                {
                    Canvas.SetTop(Player2, Canvas.GetTop(Player2) + SPEED);
                }
            }

            if (moveDownPlayer1)
            {

                if (Canvas.GetTop(Player1) < 346)
                {
                    Canvas.SetTop(Player1, Canvas.GetTop(Player1) + SPEED);
                }
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
