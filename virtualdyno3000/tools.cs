using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Threading;
using System.Text.RegularExpressions;

namespace virtualdyno3000
{
    /// <summary>
    /// Some miserable pieces of code
    /// </summary>
    public static class Tools
    {

        /// <summary>
        /// Does magic with string supposed to be double
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static double ConvertToDouble(string s)
        {
            char systemSeparator = Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator[0];
            double result = 0;
            try
            {
                if (s != null)
                    if (!s.Contains(","))
                        result = double.Parse(s, CultureInfo.InvariantCulture);
                    else
                        result = Convert.ToDouble(s.Replace(".", systemSeparator.ToString()).Replace(",", systemSeparator.ToString()));
            }
            catch (Exception e)
            {
                try
                {
                    result = Convert.ToDouble(s);
                }
                catch
                {
                    try
                    {
                        result = Convert.ToDouble(s.Replace(",", ";").Replace(".", ",").Replace(";", "."));
                    }
                    catch
                    {
                        throw new Exception("Wrong string-to-double format");
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Removes all non number and . characters from a string
        /// </summary>
        /// <param name="s">input string</param>
        /// <returns></returns>
        public static string DoubleRegex(string s)
        {
            string result = Regex.Replace(s, @"[^\d\.]", "");
            return result;
        }

        /// <summary>
        /// Removes all but number characters from a string
        /// </summary>
        /// <param name="s">input string</param>
        /// <returns></returns>
        public static string IntRegex(string s)
        {
            string result = Regex.Replace(s, @"[^\d]", "");
            return result;
        }
    }

    /// <summary>
    /// Supposedly calculates something about power
    /// </summary>
    static class Power
    {
        private static Car currentCar;
        private static Part cam, piston, inject, exh, turbo, block;
        private static int stroke;
        private static Mixture m;

        /// <summary>
        /// Claculates power output and rpm increase of a car on specified timeframe.
        /// </summary>
        /// <param name="s">Current state of the car</param>
        /// <param name="c">Car object</param>
        /// <returns></returns>
        public static State Calc(State s, Car c)
        {
            //check if continuing with same car, else format calc for new car
            if(currentCar != c)
            {
                currentCar = c;
                cam = DB.LoadPart(c.camshaft).FirstOrDefault();
                piston = DB.LoadPart(c.piston).FirstOrDefault();
                inject = DB.LoadPart(c.injectionsystem).FirstOrDefault();
                exh = DB.LoadPart(c.exhaust).FirstOrDefault();
                turbo = DB.LoadPart(c.turbo).FirstOrDefault();
                block = DB.LoadPart(c.block).FirstOrDefault();
                stroke = 1;
                m = new Mixture();
            }

            //const double targetAfr = 12.5;

            //calculate time that we run
            double time = s.calcToTime - s.lastCalcTime;

            //Actually start the simulation
            for (double d = 0; d < time;)
            {
                m.round = 60 / s.rpm;

                //executing current stroke
                switch (stroke)
                {
                    case 1:
                        m = Suck(m);
                        break;
                    case 2:
                        m = Squeeze(m);
                        break;
                    case 3:
                        m = Bang(m);
                        break;
                    case 4:
                        m = Blow(m);
                        break;
                }

                //assigning next stroke
                if (stroke <= 4)
                {
                    stroke++;
                }
                else
                {
                    stroke = 1;
                }

                //calculating total time elapsed.
                d = d + (m.round/2);
            }
            s.rpm = m.rpm;
            s.torgue = m.torgue;
            //s.lastCalcTime = s.calcToTime;
            s.lastCalcTime = 0;
            return s;
        }

        private static Mixture Suck(Mixture mIn)
        {
            Mixture mOut = mIn;
            return mOut;
        }

        private static Mixture Squeeze(Mixture mIn)
        {
            Mixture mOut = mIn;
            return mOut;
        }

        private static Mixture Bang(Mixture mIn)
        {
            Mixture mOut = mIn;
            return mOut;
        }

        private static Mixture Blow(Mixture mIn)
        {
            Mixture mOut = mIn;
            return mOut;
        }
    }
}