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
                    query = "SELECT * FROM cartable where carId = " + id + ";";
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
                    temp.id = int.Parse(dataReader["carId"].ToString());
                    temp.manufacturer = dataReader["manufacturer"].ToString();
                    temp.model = dataReader["model"].ToString();
                    temp.engine = double.Parse(dataReader["engine"].ToString());
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
                dataReader.Close();
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Something wrong " + ex.ToString());
            }

            return cars;
        }

        public static bool CreateCar(Car c)
        {
            bool result = false;
            string query = string.Format("insert into cartable (manufacturer,model,engine,year,camshaft,piston,injectsystem,exhaust,turbo,block,broke) values('{0}','{1}',{2},{3},{4},{5},{6},{7},{8},{9},{10});", c.manufacturer, c.model, c.engine.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture), c.year, c.camshaft, c.piston, c.injectionsystem, c.exhaust, c.turbo, c.block, c.broke);

            try
            {
                //check if connection is not already open
                if (conn.State.ToString() == "Closed")
                {
                    conn.Open();
                }

                MySqlCommand get = new MySqlCommand(query, conn);
                //get number of affected rows
                int i = get.ExecuteNonQuery();
                conn.Close();

                //affected rows should be 1
                if (i == 1)
                {
                    result = true;
                }
                else if (i > 1)
                {
                    //this shouldn't happen but ok
                    throw new Exception("ISO HÄLYTYS, liikaa rivejä muuttu");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Something wrong " + ex.ToString());
            }

            return result;
        }

        public static bool UpdateCar(Car c)
        {
            bool result = false;
            string query = string.Format("update cartable set manufacturer = '{0}', model = '{1}', engine = {2}, year = {3}, camshaft = {4}, piston = {5}, injectsystem = {6}, exhaust = {7}, turbo = {8}, block = {9}, broke = {10} where carId = {11};", c.manufacturer, c.model, c.engine, c.year, c.camshaft, c.piston, c.injectionsystem, c.exhaust, c.turbo, c.block, c.broke, c.id);

            try
            {
                //check if connection is not already open
                if (conn.State.ToString() == "Closed")
                {
                    conn.Open();
                }

                MySqlCommand get = new MySqlCommand(query, conn);
                //get number of affected rows
                int i = get.ExecuteNonQuery();
                conn.Close();

                //affected rows should be 1
                if (i == 1)
                {
                    result = true;
                }
                else if (i > 1)
                {
                    //this shouldn't happen but ok
                    throw new Exception("ISO HÄLYTYS, liikaa rivejä muuttu");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Something wrong " + ex.ToString());
            }

            return result;
        }

        public static bool DeleteCar(int id)
        {
            bool result = false;
            string query = string.Format("delete from cartable where carId = {0};", id);

            try
            {
                //check if connection is not already open
                if (conn.State.ToString() == "Closed")
                {
                    conn.Open();
                }

                MySqlCommand get = new MySqlCommand(query, conn);
                //get number of affected rows
                int i = get.ExecuteNonQuery();
                conn.Close();

                //affected rows should be 1
                if (i == 1)
                {
                    result = true;
                }
                else if (i > 1)
                {
                    //this shouldn't happen but ok
                    throw new Exception("ISO HÄLYTYS, liikaa rivejä muuttu");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Something wrong " + ex.ToString());
            }

            return result;
        }

        public static List<Part> LoadPart(int id = 0)
        {
            List<Part> parts = new List<Part>();
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
                    query = "SELECT * FROM tuningtable where partId = " + id + ";";
                }
                else
                {
                    query = "SELECT * FROM cartable";
                }

                MySqlCommand get = new MySqlCommand(query, conn);
                MySqlDataReader dataReader = get.ExecuteReader();

                //while reader has new data, keep creating new Car objects and add them to list
                while (dataReader.Read())
                {
                    Part temp = new Part();
                    temp.id = int.Parse(dataReader["partId"].ToString());
                    temp.manufacturer = dataReader["manufacturer"].ToString();
                    temp.partname = dataReader["partname"].ToString();
                    temp.parttype = int.Parse(dataReader["parttype"].ToString());
                    temp.stage = int.Parse(dataReader["stage"].ToString());
                    temp.toughness = int.Parse(dataReader["toughness"].ToString());
                    parts.Add(temp);
                }
                dataReader.Close();
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Something wrong " + ex.ToString());
            }

            return parts;
        }

        public static bool CreatePart(Part p)
        {
            bool result = false;
            string query = string.Format("insert into tuningtable (manufacturer, partname, parttype, stage, toughness) values('{0}','{1}',{2},{3},{4});", p.manufacturer, p.partname, p.parttype, p.stage, p.toughness);

            try
            {
                //check if connection is not already open
                if (conn.State.ToString() == "Closed")
                {
                    conn.Open();
                }

                MySqlCommand get = new MySqlCommand(query, conn);
                //get number of affected rows
                int i = get.ExecuteNonQuery();
                conn.Close();

                //affected rows should be 1
                if (i == 1)
                {
                    result = true;
                }
                else if (i > 1)
                {
                    //this shouldn't happen but ok
                    throw new Exception("ISO HÄLYTYS, liikaa rivejä muuttu");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Something wrong " + ex.ToString());
            }

            return result;
        }

        public static bool UpdatePart(Part p)
        {
            bool result = false;
            string query = string.Format("update tuningtable set manufacturer = '{0}', partname = '{1}', parttype = {2}, stage = {3}, toughness = {4} where partId = {5};", p.manufacturer, p.partname, p.parttype, p.stage, p.toughness, p.id);

            try
            {
                //check if connection is not already open
                if (conn.State.ToString() == "Closed")
                {
                    conn.Open();
                }

                MySqlCommand get = new MySqlCommand(query, conn);
                //get number of affected rows
                int i = get.ExecuteNonQuery();
                conn.Close();

                //affected rows should be 1
                if (i == 1)
                {
                    result = true;
                }
                else if (i > 1)
                {
                    //this shouldn't happen but ok
                    throw new Exception("ISO HÄLYTYS, liikaa rivejä muuttu");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Something wrong " + ex.ToString());
            }

            return result;
        }

        public static bool DeletePart(int id)
        {
            bool result = false;
            string query = string.Format("delete from tuningtable where partId = {0};", id);

            try
            {
                //check if connection is not already open
                if (conn.State.ToString() == "Closed")
                {
                    conn.Open();
                }

                MySqlCommand get = new MySqlCommand(query, conn);
                //get number of affected rows
                int i = get.ExecuteNonQuery();
                conn.Close();

                //affected rows should be 1
                if (i == 1)
                {
                    result = true;
                }
                else if (i > 1)
                {
                    //this shouldn't happen but ok
                    throw new Exception("ISO HÄLYTYS, liikaa rivejä muuttu");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Something wrong " + ex.ToString());
            }

            return result;
        }
    }
}
