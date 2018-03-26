using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows;

namespace virtualdyno3000
{
    static class DB
    {
        private static MySqlConnection conn = new MySqlConnection("SERVER=mysql.labranet.jamk.fi; DATABASE=K9251_3; UID=K9251;PASSWORD=glB9PN8Nn88ragKWgo4Q2d7YFd3mRrcS;");

        public static List<car> LoadCar()
        {
            List<car> cars = new List<car>();

            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot open connection ! " + ex.ToString());
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
