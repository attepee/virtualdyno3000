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
    /// Interaction logic for modwindow.xaml
    /// </summary>
    public partial class ModWindow : Window
    {
        public ModWindow()
        {
            InitializeComponent();
            
        }

        private void savebut_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ApplyB_Click(object sender, RoutedEventArgs e)
        {
            int selection = Box1.SelectedIndex;

            switch(selection)
            {
                case 0:
                    textBox1.Text = "Engine";
                   /* List<Car> cars = new List<Car>();
                    cars = DB.LoadCar();
                    TurboData.ItemsSource = cars;*/
                    generate_columns();
                    break;
                case 1:
                    textBox1.Text = "Camshaft";
                    DataGridTextColumn textColumn = new DataGridTextColumn();
                    textColumn.Header = "Model";
                    textColumn.Binding = new Binding("Model");
                    TurboData.Columns.Add(textColumn);
                    break;
                case 2:
                    textBox1.Text = "Piston";
                    List<Car> cars = new List<Car>();
                    cars = DB.LoadCar();
                    TurboData.ItemsSource = cars;
                    break;
                case 3:
                    textBox1.Text = "Injector System";
                    break;
                case 4:
                    textBox1.Text = "Exhaust";
                    break;
                case 5:
                    textBox1.Text = "Turbo";
                    break;
                case 6:
                    textBox1.Text = "Engine Block";
                    break;

            }
                
           /* List<Car> cars = new List<Car>();
            cars = DB.LoadCar();
            TurboData.ItemsSource = cars;*/
        }

        private void mainbut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mWindow = new MainWindow();
            mWindow.Show();
            this.Close();
        }
        private void dynobut_Click(object sender, RoutedEventArgs e)
        {
            DynoWindow dwin = new DynoWindow();
            dwin.Show();
            this.Close();
        }
        public class Item
        {
            public string Num { get; set; }
            public string Start { get; set; }
            public string Finich { get; set; }
        }

        private void generate_columns()
        {
            DataGridTextColumn c1 = new DataGridTextColumn();
            c1.Header = "Manufacturerrori";
            c1.Binding = new Binding("Num");
            c1.Width = 110;
            TurboData.Columns.Add(c1);
            DataGridTextColumn c2 = new DataGridTextColumn();
            c2.Header = "Model";
            c2.Width = 110;
            c2.Binding = new Binding("Start");
            TurboData.Columns.Add(c2);
            DataGridTextColumn c3 = new DataGridTextColumn();
            c3.Header = "Wing size";
            c3.Width = 110;
            c3.Binding = new Binding("Finich");
            TurboData.Columns.Add(c3);

            TurboData.Items.Add(new Item() { Num = "Garret", Start = "A21", Finich = "60mm" });
            TurboData.Items.Add(new Item() { Num = "holset", Start = "hol231", Finich = "120mm" });
            TurboData.Items.Add(new Item() { Num = "motonet", Start = "cheaptrubo", Finich = "2mm" });

        }


    }
}
