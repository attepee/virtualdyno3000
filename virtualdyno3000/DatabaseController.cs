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
        //create connection
        private static MySqlConnection conn = new MySqlConnection("SERVER=mysql.labranet.jamk.fi; DATABASE=K9251_3; UID=K9251;PASSWORD=glB9PN8Nn88ragKWgo4Q2d7YFd3mRrcS;");

        public static List<Car> LoadCar(int id = 0)
        {
            List<Car> cars = new List<Car>();
            string query;

            try
            {
                //check if connection is not already open
                if (conn.State.ToString() == "Closed")
                {
                    conn.Open();
                }

                //creating query by requested id
                if (id != 0)
                {
                    query = "SELECT " + id + " FROM cartable";
                }
                else
                {
                    query = "SELECT * FROM cartable";
                }

                MySqlCommand get = new MySqlCommand(query, conn);
                MySqlDataReader dataReader = get.ExecuteReader();

                //while reader has new data, keep creating new Car objects and add them to list
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
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Something wrong " + ex.ToString());
            }

            return cars;
        }

        static bool CreateCar(Car c)
        {
            bool result = false;

            string query = string.Format("insert into cartable (manufacturer,model,engine,year,camshaft,piston,injectsystem,exhaust,turbo,block,broke) values('{0}','{1}',{2},{3},{4},{5},{6},{7},{8},{9},{10});", c.manufacturer, c.model, c.engine, c.year, c.camshaft, c.piston, c.injectionsystem, c.exhaust, c.turbo, c.block, c.broke);

            try
            {
                //check if connection is not already open
                if (conn.State.ToString() == "Closed")
                {
                    conn.Open();
                }

                MySqlCommand get = new MySqlCommand(query, conn);
                MySqlDataReader dataReader = get.ExecuteReader();

                //get number of affected rows
                int i = get.ExecuteNonQuery();

                //affected rows should be 1
                if(i == 1)
                {
                    result = true;
                }
                else if (i > 1)
                {
                    //this shouldn't happen but ok
                    throw new Exception("iso hälytys, liikaa rivejä muuttu");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Something wrong " + ex.ToString());
            }

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
