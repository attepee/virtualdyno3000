using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;

namespace virtualdyno3000
{
    static class DB
    {
        private static SqlConnection conn = new SqlConnection("Data Source = mysql.labranet.jamk.fi:3306; Initial Catalog = K9251_3; user=K9251;password=pwd;");

        public static List<car> LoadCar()
        {
            List<car> cars = new List<car>();

            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot open connection ! ");
            }

            return cars;
        }

        static bool CreateCar()
        {
            bool result = false;
            return result;
        }

        static bool UpdateCar()
        {
            bool result = false;
            return result;
        }

        static bool DeleteCar()
        {
            bool result = false;
            return result;
        }

        static List<part> LoadPart()
        {
            List<part> parts = new List<part>();
            return parts;
        }
    }
}
