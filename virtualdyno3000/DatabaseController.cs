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

        public static List<Car> LoadCar(int id = 0)
        {
            List<Car> cars = new List<Car>();

            try
            {
                if (conn.State.ToString() == "Closed")
                {
                    conn.Open();
                }

                string query = "SELECT * FROM cartable";

                if (id != 0)
                {
                    query = "SELECT " + id + " FROM cartable";
                }

                List<string> result = new List<string>();

                MySqlCommand get = new MySqlCommand(query, conn);
                MySqlDataReader dataReader = get.ExecuteReader();

                while(dataReader.Read())
                {
                    Car temp = new Car();
                    temp.id = int.Parse(dataReader["idautot"].ToString());
                    temp.manufacturer = dataReader["manufacturer"].ToString();
                    temp.model = dataReader["model"].ToString();
                    temp.engine = int.Parse(dataReader["engine"].ToString());
                    temp.year = int.Parse(dataReader["year"].ToString());
                    temp.camshaft = int.Parse(dataReader["camshaft"].ToString());
                    temp.piston = int.Parse(dataReader["piston"].ToString());
                    temp.injectionsystem = int.Parse(dataReader["injectsystem"].ToString());
                    temp.exhaust = int.Parse(dataReader["exhaust"].ToString());
                    temp.turbo = int.Parse(dataReader["turbo"].ToString());
                    temp.block = int.Parse(dataReader["block"].ToString());
                    temp.broke = int.Parse(dataReader["broke"].ToString());
                    cars.Add(temp);
                }
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
            //insert into cartable (manufacturer,model,engine,year,camshaft,piston,injectsystem,exhaust,turbo,block,broke) values ('asd', 'sd', 1,1,1,1,1,1,1,1,1)


            /*
                SqlCommand NewCmd = conn.CreateCommand();
                NewCmd.Connection = conn;
                NewCmd.CommandType = CommandType.Text;
                NewCmd.CommandText = " update supplier set " + " ID = " + "'" + id + "'" + " , NAME = " + "'" + name + "'" + " , BALANCE = " + "'" + balance + "'" + " , PLACE = " + "'" + place + "'" + "  , LOCATION = " + "'" + address + "'" + ",  PHONE = " + "'" + phone + "'" + " , BANK_NAME = " + "'" + bankname + "'" + " , BANK_BRANCH = " + "'" + bankbranch + "'" + ", ACCOUNT_NO = " + "'" + accountno + "'" + " where ID = " + "@id";
                NewCmd.Parameters.AddWithValue("@id", id);
                int a = NewCmd.ExecuteNonQuery();
                conn.Close();
                if (a == 0)
                {
                    //Not updated.
                }

                else
                {

                }
            */

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

        static List<Part> LoadPart(int id)
        {
            List<Part> parts = new List<Part>();
            try
            {
                conn.Open();

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot open connection ! " + ex.ToString());
            }

            return parts;
        }
    }
}
