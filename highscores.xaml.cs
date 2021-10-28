using MongoDB.Driver.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace Pong_project_homescreen
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {

        List<string> highscores1 = new List<string>();
        public Window1(string P1Naam, string P2Naam, string label2)
        {
            InitializeComponent();

            //string query = "SELECT Player, Time FROM Table";
            //high.Content = query;
            GetHighScores();
            CreateLabels();


        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {

            //SetHighScores("marietje", "900");
            GetHighScores();
            CreateLabels();
            
        }

        private void Homescreen_Click(object sender, RoutedEventArgs e)
        {
            MainWindow homescreen = new MainWindow();
            this.Visibility = Visibility.Hidden;
            homescreen.Visibility = Visibility.Visible;
        }

        private void GetHighScores()
        {
            highscores1.Clear();

            string query = "SELECT Player,Time FROM dbo.Highscores";
            const string filename = "\"C:\\Users\\Startklaar\\Desktop\\Visual studio dingen\\Pong project homescreen\\Pong project homescreen\\Data\\GameDatabase1.mdf\"";
            string connectionString = String.Format("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={0};Integrated Security=True", filename);

            using (SqlConnection connection =
                  new SqlConnection(connectionString))
            {
                SqlCommand command =
                    new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                // Call Read before accessing data.
                while (reader.Read())
                {
                    highscores1.Add((string)reader[0]);
                    highscores1.Add((string)reader[1]);
                }

                // Call Close when done reading.
                reader.Close();
            }
        }

        public static void SetHighScores(string winner, string time)
        {
            const string filename = "\"C:\\Users\\Startklaar\\Desktop\\Visual studio dingen\\Pong project homescreen\\Pong project homescreen\\Data\\GameDatabase1.mdf\"";
            string connectionString = String.Format("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={0};Integrated Security=True", filename);

            string Query1 = "INSERT INTO [Highscores] ([Player], [Time]) VALUES ('"+ winner +"', '"+ time +"')";


            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(Query1, connection);
            try
            {
                command.CommandText = Query1;
                command.CommandType = CommandType.Text;
                command.Connection = connection;
                connection.Open(); 
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                connection.Close();
            }
           
        }
        private void CreateLabels()
        {
            HighScorePanel.Children.Clear();
            //var sortedHighscores = from score in highscores1 orderby score.Value ascending select score;
            //foreach (KeyValuePair<string, string> highscore1 in sortedHighscores)
            for (int i = 0; i < highscores1.Count; i += 2)
           {
                Label label = new Label();
                label.Content = "player " + highscores1[i] + "\t" + " Time " + highscores1[i + 1];
                label.HorizontalAlignment = HorizontalAlignment.Center;
                HighScorePanel.Children.Add(label);
            }
        }

    }
}
