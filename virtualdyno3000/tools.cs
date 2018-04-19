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
        /// <param name="s"></param>
        /// <returns></returns>
        public static string DoubleRegex(string s)
        {
            string result = Regex.Replace(s, @"[^\d\.]", "");
            return result;
        }
        /// <summary>
        /// Removes all but number characters from a string
        /// </summary>
        /// <param name="s"></param>
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
        /// <summary>
        /// Claculates power output and rpm increase of a car on specified timeframe.
        /// </summary>
        /// <param name="s">Current state of the car</param>
        /// <param name="c">Car object</param>
        /// <returns></returns>
  
        private enum camshaft { };
        private enum piston { };
        private enum injectionsystem { };
        private enum exhaust { };
        private enum turbo { };

        public static State Calc(State s, Car c)
        {
            /*const double targetAfr = 12.5;
            double time = s.calcToTime - s.lastCalcTime;

            for (double d = 0; d < time;)
            {
                double round = 60/s.rpm;
                d =+ round;
            }
            */
            double time = s.calcToTime - s.lastCalcTime;

            for (double d = 0; d < time;)
            {
                double round = 60 / s.rpm;
                s.rpm =+ 2;
                d =+ round;
                s.torgue++;
            }
            s.lastCalcTime = s.calcToTime;
            return s;
        }
    }
}
