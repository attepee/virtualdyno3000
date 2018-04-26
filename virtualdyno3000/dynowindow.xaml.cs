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
using System.Diagnostics;
using System.Threading;

namespace virtualdyno3000
{
    /// <summary>
    /// Interaction logic for dynowindow.xaml
    /// </summary>
    public partial class DynoWindow : Window
    {
        public State s = new State();
        public Car c = new Car();

        public DynoWindow(Car car)
        {
            InitializeComponent();
            c = car;
        }

        private bool loop = true;
        private async void startButton_Click(object sender, RoutedEventArgs e)
        {
            loop = false;
            s.rpm = 1900;
            s.calcToTime = 10;
            Car reset = new Car();
            State resetS = new State();
            Power.Calc(resetS, reset);

            s = Power.Calc(s, c);

            int h = -5;
            int a = 570;

            for (int i = 0; i < (s.rpmPerRev.Count() - 1) && !loop; i++)
            {

                Line objLineTorq = new Line();
                Line objLineRpm = new Line();
                objLineTorq.Stroke = System.Windows.Media.Brushes.Black;
                objLineTorq.Fill = System.Windows.Media.Brushes.Black;
                objLineRpm.Stroke = System.Windows.Media.Brushes.Red;
                objLineRpm.Fill = System.Windows.Media.Brushes.Red;

                //start
                objLineRpm.X1 = i ;
                objLineRpm.Y1 = -(int)Math.Round(s.rpmPerRev[i] / 30) + 570;
                //end
                objLineRpm.X2 = i + 1;
                objLineRpm.Y2 = -(int)Math.Round(s.rpmPerRev[(i + 1)] / 30) + 570;


                //start
                objLineTorq.X1 = i;
                objLineTorq.Y1 = -(int)Math.Round(s.torquePerRev[i])/2 + 570;
                //end
                objLineTorq.X2 = i + 1;
                objLineTorq.Y2 = -(int)Math.Round(s.torquePerRev[(i + 1)])/2 + 570;

                dynoCanvas.Children.Add(objLineRpm);
                dynoCanvas.Children.Add(objLineTorq);

                hp.Text = ((int)Math.Round(s.rpmPerRev[i])).ToString();
                nm.Text = ((int)Math.Round(s.torquePerRev[i])).ToString();
                double HPTT = ((int)Math.Round(s.rpmPerRev[i]) * (int)Math.Round(s.torquePerRev[i]) / 9000.5488);
                HPY.Text = HPTT.ToString();

                await Task.Delay(30);


            }
        }

        private void stopButton_Click(object sender, RoutedEventArgs e)
        {
            loop = true;
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            // Saves results ot db
        }

        private void menuButton_Click(object sender, RoutedEventArgs e)
        {
            // Closes dynowindow and opens main
            MainWindow mWindow = new MainWindow();
            mWindow.Show();
            this.Close();
        }

        private void modButton_Click(object sender, RoutedEventArgs e)
        {
            // closes dynowindow and opens modwindow
            Car auto = new Car();
            ModWindow modWundow = new ModWindow(auto);
            modWundow.Show();
            this.Close();
        }

        //tän voi sit ihan poistella kun on laskuri valmis. penkittelen tuota laskuria tällä ettei se ala jumittaa
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            s.rpm = 1900;
            s.calcToTime = 7;
            s = Power.Calc(s, c);

           

            for (int i = 0; i < (s.rpmPerRev.Count() - 1); i++)
            {
                Line objLineTorq = new Line();
                Line objLineRpm = new Line();
                objLineTorq.Stroke = System.Windows.Media.Brushes.Black;
                objLineTorq.Fill = System.Windows.Media.Brushes.Black;
                objLineRpm.Stroke = System.Windows.Media.Brushes.Red;
                objLineRpm.Fill = System.Windows.Media.Brushes.Red;

                //start
                objLineRpm.X1 = i;
                objLineRpm.Y1 = -(int)Math.Round(s.rpmPerRev[i]/100);
                //end
                objLineRpm.X2 = i + 1;
                objLineRpm.Y2 = -(int)Math.Round(s.rpmPerRev[(i + 1)]/100);


                //start
                objLineTorq.X1 = i;
                objLineTorq.Y1 = -(int)Math.Round(s.torquePerRev[i]);
                //end
                objLineTorq.X2 = i + 1;
                objLineTorq.Y2 = -(int)Math.Round(s.torquePerRev[(i + 1)]);

                dynoCanvas.Children.Add(objLineRpm);
                dynoCanvas.Children.Add(objLineTorq);

                hp.Text = ((int)Math.Round(s.rpmPerRev[i] / 100)).ToString();
                nm.Text = ((int)Math.Round(s.torquePerRev[i])).ToString();
                double HPTT = (s.rpm * s.torque / 9000.5488);
                HPY.Text = HPTT.ToString();

                await Task.Delay(20);

            }

            /* Random r = new Random();
             int a = r.Next(525, 570);
             int h = -5;
             //int a = 570;
             Random re = new Random();
             int o = re.Next(325, 400);
             int j = -5;
             for (int x = 0; x < 10; x++)
             {
                 Random fa = new Random();
                 int f = fa.Next(1, 15);
                 Random fau = new Random();
                 int p = fau.Next(1, 12);


                 Line objLine = new Line();
                 objLine.Stroke = System.Windows.Media.Brushes.Black;
                 objLine.Fill = System.Windows.Media.Brushes.Red;

                 //start
                 objLine.X1 = h;
                 objLine.Y1 = a;
                 //end
                 h = (h + f);
                 a = (a - p);
                 objLine.X2 = h;
                 objLine.Y2 = a;
                 dynoCanvas.Children.Add(objLine);

                 Random fax = new Random();
                 int k = fax.Next(9, 15);
                 Random faxx = new Random();
                 int l = faxx.Next(2, 3);
                 await Task.Delay(150);

                 Line sobjeLine = new Line();
                 sobjeLine.Stroke = System.Windows.Media.Brushes.Red;
                 sobjeLine.Fill = System.Windows.Media.Brushes.Red;

                 //start
                 sobjeLine.X1 = j;
                 sobjeLine.Y1 = o;
                 //end
                 o = (o - l);
                 j = (j + k);
                 sobjeLine.X2 = j;
                 sobjeLine.Y2 = o;
                 dynoCanvas.Children.Add(sobjeLine);
             }*/

            /*Stopwatch stopwatch = new Stopwatch();
            s.rpm = 100;
            s.calcToTime = 10;

            stopwatch.Start();
            Power.Calc(s, c);
            stopwatch.Stop();

            //mk1 osien muunto arvoiksi ja ajon alustus ja kierrosten keston laskenta
            //00:00:00.0004999 eka ajo
            //00:00:00.0000010 toinen pyöräytys samalla oliolla


            //mk2 hakulogiikka muutettu osat objekteina
            //00:00:00.5334331 eka ajo, tietokanta jarruttelee.. olkoon ei haittaa käytännössä
            //00:00:00.0000017 toinen

            //mk3 lisätty imu tahti
            //Elapsed	{00:00:00.9495005}	System.TimeSpan, nouspas paljon wtf
            //Elapsed	{00:00:00.0000079}	System.TimeSpan, this is ok

            TimeSpan t = stopwatch.Elapsed;
            */




        }
    }
}
