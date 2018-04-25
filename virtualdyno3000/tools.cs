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
        private static Car currentCar = new Car();
        private static double cam;
        private static double piston;
        private static double inject;
        private static double exh;
        private static double turbo;
        private static int stroke;

        /// <summary>
        /// Claculates power output and rpm increase of a car on specified timeframe.
        /// </summary>
        /// <param name="s">Current state of the car</param>
        /// <param name="c">Car object</param>
        /// <returns></returns>
        public static State Calc(State s, Car c)
        {
            if(currentCar != c)
            {
                currentCar = c;
                cam = GetSpec(c.camshaft, 1);
                piston = GetSpec(c.piston, 2);
                inject = GetSpec(c.injectionsystem, 3);
                exh = GetSpec(c.exhaust, 4);
                turbo = GetSpec(c.turbo, 5);
                stroke = 1;
            }

            const double targetAfr = 12.5;
            double time = s.calcToTime - s.lastCalcTime;

            for (double d = 0; d < time;)
            {
                double round = (double)60 / s.rpm;

                //executing current stroke
                switch (stroke)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                }

                //assigning next stroke
                if (stroke >= 4)
                {
                    stroke++;
                }
                else
                {
                    stroke = 1;
                }

                //calculating total time elapsed.
                d = d + (round/2);
            }
            //s.lastCalcTime = s.calcToTime;
            s.lastCalcTime = 0;
            return s;
        }


        /// <summary>
        /// pls dont mind me, just a horrible hack ))
        /// </summary>
        /// <param name="stage"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private static double GetSpec(int stage, int type)
        {
            double d = 0;

            switch (type)
            {
                case 1:
                    //case for camshaft
                    switch (stage)
                    {
                        case 0:
                            d = 3.2;
                            break;
                        case 1:
                            d = 5.5;
                            break;
                        case 2:
                            d = 7;
                            break;
                        case 3:
                            d = 8.7;
                            break;
                        case 4:
                            d = 10.5;
                            break;
                    }
                    break;

                case 2:
                    //case for piston
                    switch (stage)
                    {
                        case 0:
                            d = 0;
                            break;
                        case 1:
                            d = 0;
                            break;
                        case 2:
                            d = 0;
                            break;
                        case 3:
                            d = 0;
                            break;
                        case 4:
                            d = 0;
                            break;
                    }
                    break;

                case 3:
                    //case for injection system
                    switch (stage)
                    {
                        case 0:
                            d = 0;
                            break;
                        case 1:
                            d = 0;
                            break;
                        case 2:
                            d = 0;
                            break;
                        case 3:
                            d = 0;
                            break;
                        case 4:
                            d = 0;
                            break;
                    }
                    break;

                case 4:
                    //case for exhaust
                    switch (stage)
                    {
                        case 0:
                            d = 0;
                            break;
                        case 1:
                            d = 0;
                            break;
                        case 2:
                            d = 0;
                            break;
                        case 3:
                            d = 0;
                            break;
                        case 4:
                            d = 0;
                            break;
                    }
                    break;

                case 5:
                    //case for turbo
                    switch (stage)
                    {
                        case 0:
                            d = 0;
                            break;
                        case 1:
                            d = 0;
                            break;
                        case 2:
                            d = 0;
                            break;
                        case 3:
                            d = 0;
                            break;
                        case 4:
                            d = 0;
                            break;
                    }
                    break;

                default:
                    //should not land here but well if it does assign something to the part, results may suprise depending on the part. kjäh :D
                    d = 90.01;
                    break;
            }
            return d;
        }
        
    }
}