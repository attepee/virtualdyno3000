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

namespace virtualdyno3000
{
    /// <summary>
    /// Interaction logic for dynowindow.xaml
    /// </summary>
    public partial class DynoWindow : Window
    {
        public DynoWindow(Car car)
        {
            InitializeComponent();
            c = car;
        }

        public State s = new State();
        public Car c = new Car();
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

            }
            for (int x = 0; x < 10; x++)
            {
                Random fa = new Random();
                int f = fa.Next(7, 12);
                Random fau = new Random();
                int p = fau.Next(6, 9);
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

            }
            for (int x = 0; x < 10; x++)
            {
                Random fa = new Random();
                int f = fa.Next(8, 14);
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


  
     
            for (int x = 0; x < 480; x++)
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
            }


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
    }
}
