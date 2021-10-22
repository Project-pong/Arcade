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
    /// <summary>
    /// Interaction logic for ClassicPong.xaml
    /// </summary>
    public partial class ClassicPong : Window
    {

        private ImageBrush PongClassic = new ImageBrush();
        private bool moveUpPlayer11 = false;
        private bool moveDownPlayer11 = false;
        private bool moveUpPlayer22 = false;
        private bool moveDownPlayer22 = false;
        double countPlayerHit = 0.15;
        const int SPEED2 = 5;
        private DispatcherTimer gameTimer = new DispatcherTimer();

        private double nijntjeX = 0.0;
        private double nijntjeY = 0.0;
        private double nijntjeDirX = -2.25;
        private double nijntjeDirY = 3.0;
        int puntenP1 = 1;
        int puntenP2 = 1;
        

        int timeCs, timeSec, timeMin;
        bool staatAan;

        //houdt bij welkle speler als laatste heeft gekaatst
        int lastPlayerHit = 0;
        

        private void MovePlayers2 (object sender, EventArgs e)
        {
            if (moveUpPlayer22)
            {
                if (Canvas.GetTop(Player22) > 0)
                {
                    Canvas.SetTop(Player22, Canvas.GetTop(Player22) - SPEED2);
                }
            }
            if (moveUpPlayer11)
            {
                if (Canvas.GetTop(Player11) > 0)
                {
                    Canvas.SetTop(Player11, Canvas.GetTop(Player11) - SPEED2);
                }
            }
            if (moveDownPlayer11)
            {
                if (Canvas.GetTop(Player11) < 346)
                {
                    Canvas.SetTop(Player11, Canvas.GetTop(Player11) + SPEED2);
                }
            }
            if (moveDownPlayer22)
            {
                if (Canvas.GetTop(Player22) < 346)
                {
                    Canvas.SetTop(Player22, Canvas.GetTop(Player22) + SPEED2);
                }
            }
        }
        
        
        private void PongCanvas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down)
            {
                moveDownPlayer22 = true;
            }
            if (e.Key == Key.W)
            {
                moveUpPlayer11 = true;
            }
            if (e.Key == Key.Up)
            {
                moveUpPlayer22 = true;
            }
            if (e.Key == Key.S)
            {
                moveDownPlayer11 = true;
            }
        }

        private void PongCanvas_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up)
            {
                moveUpPlayer22 = false;
            }
            if (e.Key == Key.W)
            {
                moveUpPlayer11 = false;
            }
            if (e.Key == Key.Down)
            {
                moveDownPlayer22 = false;
            }
            if (e.Key == Key.S)
            {
                moveDownPlayer11 = false;
            }
        }

        public ClassicPong(string p1Naam, string p2naam)
        {
            
            InitializeComponent();


            gameTimer.Interval = TimeSpan.FromMilliseconds(5);
            gameTimer.Tick += MovePlayers2;
            gameTimer.Tick += MoveNijntje;
            gameTimer.Start();

            PongCanvas.Focus();

            PongClassic.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/WitteBal.png"));
            Bal2.Fill = PongClassic;

            SaveNaam1.Content = p1Naam;
            SaveNaam2.Content = p2naam;
         
        }

        private void MoveNijntje(object sender, EventArgs e)
        {
            nijntjeY += nijntjeDirY;
            nijntjeX += nijntjeDirX;

            var group = new TransformGroup();
            group.Children.Add(new TranslateTransform(nijntjeX, nijntjeY));
            Bal2.RenderTransform = group;
            if (nijntjeY >= 178.0)
            {
                nijntjeDirY = nijntjeDirY * -1.0;
            }
            if (nijntjeY <= -196.0)
            {
                nijntjeDirY = nijntjeDirY * -1.0;
            }

            //bereken de posities van nijntje en de twee spelers
            Rect positionNijntje = new Rect(Canvas.GetLeft(Bal2) + nijntjeX, Canvas.GetTop(Bal2) + nijntjeY, 40, 40);
            Rect player1position = new Rect(Canvas.GetLeft(Player11), Canvas.GetTop(Player11), Player11.Width, Player11.Height);
            Rect player2position = new Rect(Canvas.GetLeft(Player22) + 15, Canvas.GetTop(Player22), Player22.Width, Player22.Height);
            

            //kaats nijntje als speler 1 wordt geraakt
            if (positionNijntje.IntersectsWith(player1position) && lastPlayerHit != 1)
            {
                countPlayerHit = countPlayerHit + 0.01;
                lastPlayerHit = 1;
                nijntjeDirX = nijntjeDirX * -1 + countPlayerHit;               
            }
            //kaats nijntje als speler 2 wordt geraakt
            if (positionNijntje.IntersectsWith(player2position) && lastPlayerHit != 2)
            {
                countPlayerHit = countPlayerHit + 0.01;
                lastPlayerHit = 2;
                nijntjeDirX = nijntjeDirX * -1 - countPlayerHit;
            }
            //doelpunt voor player 1
            if (nijntjeX >= 400)
            {
                nijntjeDirY = nijntjeDirY * -0;
                nijntjeDirX = nijntjeDirX * -0;
                nijntjeX = 0;
                nijntjeY = 0;
                nijntjeDirX = 2.25;
                nijntjeDirY = 3.0;
                countPlayerHit = 0.15;
            }
            if (nijntjeX >= 397)
            {
                ScoreP11.Content = puntenP1++;
            }
            //doelpunt voor player 2
            if (nijntjeX <= -400)
            {
                nijntjeDirY = nijntjeDirY * -0;
                nijntjeDirX = nijntjeDirX * -0;
                nijntjeX = 0;
                nijntjeY = 0;
                nijntjeDirX = -2.25;
                nijntjeDirY = 3.0;
                countPlayerHit = 0.15;
            }
            if (nijntjeX <= -397)
            {
                ScoreP22.Content = puntenP2++;
            }
            //speler 1 heeft gewonnen
            if (puntenP1 == 11)
            {
                nijntjeX = 0;
                nijntjeY = 0;
                nijntjeDirY = nijntjeDirY * -0;
                nijntjeDirX = nijntjeDirX * -0;
                staatAan = false;
                victory1.Content = SaveNaam1.Content + " " + "heeft gewonnen";
            }
            //speler 2 heeft gewonnen
            if (puntenP2 == 11)
            {
                nijntjeX = 0;
                nijntjeY = 0;
                nijntjeDirY = nijntjeDirY * -0;
                nijntjeDirX = nijntjeDirX * -0;
                staatAan = false;
                victory1.Content = SaveNaam2.Content + " " + "heeft gewonnen";
            }
           

            if (nijntjeX != 0.0)
            {
                staatAan = true;
            }

            if (staatAan == true)
            {
                timeCs++;

                if (timeCs >= 100)
                {
                    timeSec++;
                    timeCs = 00;

                    if (timeSec >= 60)
                    {
                        timeMin++;
                        timeSec = 00;

                    }
                }
            }

            TimerMin2.Content = timeMin;
            TimerSec2.Content = timeSec;
            TimerCs2.Content = timeCs;

            //if (timeSec == 3 && timeCs == 00)
            //{
            //    Rectangle Power = new Rectangle()

            //    {
            //        Width = 25,
            //        Height = 25,
            //        Fill = Brushes.Red,
            //        Stroke = Brushes.Green,
            //        StrokeThickness = 1,
            //    };

            //    PongCanvas.Children.Add(Power);
            //    Canvas.SetTop(Power, 200);
            //    Canvas.SetLeft(Power, 250);
            //    //Rect PowerBox = new Rect(Canvas.GetLeft(Power), Canvas.GetTop(Power), Power.Width, Power.Height);
            //    Rect PowerBox = new Rect(Canvas.GetLeft(Power), Canvas.GetTop(Power), Power.Width, Power.Height);
            //    if (positionNijntje.IntersectsWith(PowerBox))
            //    {
            //        nijntjeDirX = nijntjeDirX * 0;
            //    }
            //}
            PUP1.Visibility = Visibility.Hidden;

            if (timeSec > 3)
            {
                PUP1.Visibility = Visibility.Visible;
                PUP1.Fill = Brushes.Cyan;
            }

            Rect PowerUp1 = new Rect(Canvas.GetTop(PUP1) + 100, Canvas.GetLeft(PUP1) - 100, PUP1.Width, PUP1.Height);

            if (PUP1.Visibility == Visibility.Visible && positionNijntje.IntersectsWith(PowerUp1))
            {
                nijntjeDirX = nijntjeDirX * -1;
            }

        }
    }
   
}

