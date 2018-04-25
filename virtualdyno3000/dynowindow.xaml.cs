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

        private async void startButton_Click(object sender, RoutedEventArgs e)
        {
            s.torgue = 100;
            s.rpm = 100;
            for (int i=0; i<50; i++)
            {
                s.calcToTime = i;
                s = Power.Calc(s, c);

            }
            
            Random r = new Random();
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
                await Task.Delay(150);

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
            }
            for (int x = 0; x < 10; x++)
            {
                Random fa = new Random();
                int f = fa.Next(9, 12);
                Random fau = new Random();
                int p = fau.Next(7, 9);
                await Task.Delay(150);

                Line objLine = new Line();
                objLine.Stroke = System.Windows.Media.Brushes.Black;
                objLine.Fill = System.Windows.Media.Brushes.Black;

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
                o = (o + l);
                j = (j + k);
                sobjeLine.X2 = j;
                sobjeLine.Y2 = o;
                dynoCanvas.Children.Add(sobjeLine);

            }
            for (int x = 0; x < 10; x++)
            {
                Random fa = new Random();
                int f = fa.Next(10, 14);
                Random fau = new Random();
                int p = fau.Next(8, 9);
                await Task.Delay(150);

                Line objLine = new Line();
                objLine.Stroke = System.Windows.Media.Brushes.Black;
                objLine.Fill = System.Windows.Media.Brushes.Black;

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
                int l = faxx.Next(3, 4);
                await Task.Delay(150);

                Line sobjeLine = new Line();
                sobjeLine.Stroke = System.Windows.Media.Brushes.Red;
                sobjeLine.Fill = System.Windows.Media.Brushes.Red;

                //start
                sobjeLine.X1 = j;
                sobjeLine.Y1 = o;
                //end
                o = (o + l);
                j = (j + k);
                sobjeLine.X2 = j;
                sobjeLine.Y2 = o;
                dynoCanvas.Children.Add(sobjeLine);

            }
            for (int x = 0; x < 10; x++)
            {
                Random fa = new Random();
                int f = fa.Next(1, 14);
                Random fau = new Random();
                int p = fau.Next(2, 6);
                await Task.Delay(150);

                Line objLine = new Line();
                objLine.Stroke = System.Windows.Media.Brushes.Black;
                objLine.Fill = System.Windows.Media.Brushes.Black;

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
                int l = faxx.Next(5, 6);
                await Task.Delay(150);

                Line sobjeLine = new Line();
                sobjeLine.Stroke = System.Windows.Media.Brushes.Red;
                sobjeLine.Fill = System.Windows.Media.Brushes.Red;

                //start
                sobjeLine.X1 = j;
                sobjeLine.Y1 = o;
                //end
                o = (o + l);
                j = (j + k);
                sobjeLine.X2 = j;
                sobjeLine.Y2 = o;
                dynoCanvas.Children.Add(sobjeLine);

            }
            for (int x = 0; x < 10; x++)
            {
                Random fa = new Random();
                int f = fa.Next(8, 14);
                Random fau = new Random();
                int p = fau.Next(4, 9);
                await Task.Delay(150);

                Line objLine = new Line();
                objLine.Stroke = System.Windows.Media.Brushes.Black;
                objLine.Fill = System.Windows.Media.Brushes.Black;

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
                int l = faxx.Next(6, 7);
                await Task.Delay(150);

                Line sobjeLine = new Line();
                sobjeLine.Stroke = System.Windows.Media.Brushes.Red;
                sobjeLine.Fill = System.Windows.Media.Brushes.Red;

                //start
                sobjeLine.X1 = j;
                sobjeLine.Y1 = o;
                //end
                o = (o + l);
                j = (j + k);
                sobjeLine.X2 = j;
                sobjeLine.Y2 = o;
                dynoCanvas.Children.Add(sobjeLine);

            }
            for (int x = 0; x < 10; x++)
            {
                Random fa = new Random();
                int f = fa.Next(2, 14);
                Random fau = new Random();
                int p = fau.Next(1, 9);
                await Task.Delay(150);

                Line objLine = new Line();
                objLine.Stroke = System.Windows.Media.Brushes.Black;
                objLine.Fill = System.Windows.Media.Brushes.Black;

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
                int l = faxx.Next(1, 2);
                await Task.Delay(150);

                Line sobjeLine = new Line();
                sobjeLine.Stroke = System.Windows.Media.Brushes.Red;
                sobjeLine.Fill = System.Windows.Media.Brushes.Red;

                //start
                sobjeLine.X1 = j;
                sobjeLine.Y1 = o;
                //end
                o = (o + l);
                j = (j + k);
                sobjeLine.X2 = j;
                sobjeLine.Y2 = o;
                dynoCanvas.Children.Add(sobjeLine);

            }
            for (int x = 0; x < 10; x++)
            {
                Random fa = new Random();
                int f = fa.Next(3, 9);
                Random fau = new Random();
                int p = fau.Next(1, 4);
                await Task.Delay(150);

                Line objLine = new Line();
                objLine.Stroke = System.Windows.Media.Brushes.Black;
                objLine.Fill = System.Windows.Media.Brushes.Black;

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
                int l = faxx.Next(0, 1);
                await Task.Delay(150);

                Line sobjeLine = new Line();
                sobjeLine.Stroke = System.Windows.Media.Brushes.Red;
                sobjeLine.Fill = System.Windows.Media.Brushes.Red;

                //start
                sobjeLine.X1 = j;
                sobjeLine.Y1 = o;
                //end
                o = (o + l);
                j = (j + k);
                sobjeLine.X2 = j;
                sobjeLine.Y2 = o;
                dynoCanvas.Children.Add(sobjeLine);

            }
            for (int x = 0; x < 30; x++)
            {
                Random fa = new Random();
                int f = fa.Next(5, 12);
                Random fau = new Random();
                int p = fau.Next(1, 6);
                await Task.Delay(150);

                Line objLine = new Line();
                objLine.Stroke = System.Windows.Media.Brushes.Black;
                objLine.Fill = System.Windows.Media.Brushes.Black;

                //start
                objLine.X1 = h;
                objLine.Y1 = a;
                //end
                h = (h + f);
                a = (a - p);
                objLine.X2 = h;
                objLine.Y2 = a;
                dynoCanvas.Children.Add(objLine);

            }


  
     
          /*  for (int x = 0; x < 480; x++)
            {
               // await Task.Delay(1);

                Line objLine = new Line();
                objLine.Stroke = System.Windows.Media.Brushes.Black;
                objLine.Fill = System.Windows.Media.Brushes.Black;

                //start
                objLine.X1 = h;
                objLine.Y1 = a;
                //end
                objLine.X2 = h ;
                objLine.Y2 = a+1 ;
                dynoCanvas.Children.Add(objLine);
               // h = (h + 1);
                a = (a + 1);
            }*/


            hp.Text = s.rpm.ToString();
            nm.Text = s.torgue.ToString();
        }
        
        private void stopButton_Click(object sender, RoutedEventArgs e)
        {
            // Stops the dyno
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
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
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
            TimeSpan t = stopwatch.Elapsed;
        }
    }
}
