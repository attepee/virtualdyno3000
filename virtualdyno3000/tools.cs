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
        private static State state;
        /// <summary>
        /// Claculates power output and rpm increase of a car on specified timeframe.
        /// </summary>
        /// <param name="s">Current state of the car</param>
        /// <param name="c">Car object</param>
        /// <returns></returns>
        public static State Calc(State s, Car c)
        {
            state = s;
            //check if continuing with same car, else format calc for new car
            if(currentCar != c)
            {
                currentCar = c;
                cam = DB.LoadPart(c.camshaft).FirstOrDefault();
                cam.effect = GetSpec(cam.stage, 1);
                piston = DB.LoadPart(c.piston).FirstOrDefault();
                piston.effect = GetSpec(piston.stage, 2);
                inject = DB.LoadPart(c.injectionsystem).FirstOrDefault();
                inject.effect = GetSpec(inject.stage, 3);
                exh = DB.LoadPart(c.exhaust).FirstOrDefault();
                exh.effect = GetSpec(exh.stage, 4);
                turbo = DB.LoadPart(c.turbo).FirstOrDefault();
                turbo.effect = GetSpec(turbo.stage, 5);
                block = DB.LoadPart(c.block).FirstOrDefault();
                block.effect = GetSpec(block.stage, 6);
                stroke = 1;
                m = new Mixture();
            }

            //calculate time that we run
            double time = state.calcToTime - state.lastCalcTime;

            //Actually start the simulation
            for (double d = 0; d < time;)
            {
                m.round = 60 / state.rpm;

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
                if (stroke < 4)
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
            //s.lastCalcTime = s.calcToTime;
            state.lastCalcTime = 0;
            return state;
        }

        private static Mixture Suck(Mixture mIn)
        {
            m.exhaustVelocity = 1;
            Mixture mOut = mIn;
            double gasFlow = (0.0580 * inject.effect) / 100;
            double airFlow = (0.83 * (turbo.effect*m.exhaustVelocity))/100;

            double rpmDiv = cam.effect / state.rpm;
            double rpmEffect = rpmDiv * (-1.2* Math.Pow(rpmDiv, 2) + 2 * rpmDiv);

            if(rpmEffect < 0.32)
            {
                rpmEffect = 0.32;
            }


            for (double t = 0; t < m.round/2; t = t+0.01)
            {
                mOut.air = mOut.air + (airFlow * rpmEffect);
                mOut.gas = mOut.gas + (gasFlow * rpmEffect);
            }

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
            const double targetAfr = 12.5;
            return mOut;
        }

        private static Mixture Blow(Mixture mIn)
        {
            Mixture mOut = mIn;
            return mOut;
        }

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
                            d = 3200;
                            break;
                        case 1:
                            d = 5500;
                            break;
                        case 2:
                            d = 7000;
                            break;
                        case 3:
                            d = 8700;
                            break;
                        case 4:
                            d = 10500;
                            break;
                    }
                    break;

                case 2:
                    //case for piston
                    switch (stage)
                    {
                        case 0:
                            d = 1.4;
                            break;
                        case 1:
                            d = 1.5;
                            break;
                        case 2:
                            d = 1.7;
                            break;
                        case 3:
                            d = 1.9;
                            break;
                        case 4:
                            d = 2;
                            break;
                    }
                    break;

                case 3:
                    //case for injection system
                    switch (stage)
                    {
                        case 0:
                            d = 1;
                            break;
                        case 1:
                            d = 2;
                            break;
                        case 2:
                            d = 2.5;
                            break;
                        case 3:
                            d = 2.9;
                            break;
                        case 4:
                            d = 3.2;
                            break;
                    }
                    break;

                case 4:
                    //case for exhaust
                    switch (stage)
                    {
                        case 0:
                            d = 1;
                            break;
                        case 1:
                            d = 1.4;
                            break;
                        case 2:
                            d = 1.9;
                            break;
                        case 3:
                            d = 2.4;
                            break;
                        case 4:
                            d = 3;
                            break;
                    }
                    break;
                case 5:
                    //case for turbo
                    switch (stage)
                    {
                        case 0:
                            d = 1;
                            break;
                        case 1:
                            d = 1.3;
                            break;
                        case 2:
                            d = 1.7;
                            break;
                        case 3:
                            d = 2.2;
                            break;
                        case 4:
                            d = 2.8;
                            break;
                    }
                    break;
                case 6:
                    //case for block
                    switch (stage)
                    {
                        case 0:
                            d = 9;
                            break;
                        case 1:
                            d = 10;
                            break;
                        case 2:
                            d = 11;
                            break;
                        case 3:
                            d = 13;
                            break;
                        case 4:
                            d = 14;
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