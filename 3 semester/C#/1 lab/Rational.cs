using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Rumyantsev.Lab1.Rational
{
    /// <summary>
    /// 
    /// </summary>
    public class Rational : IComparable, ICloneable, IFormattable
    { 
        public int Numerator { get; private set; }
        public int Denominator { get; private set; }
        public int Original_Numerator { get; private set; }
        public int Original_Denominator { get; private set; }

        public static Rational NaN = new Rational(0, 0);
        public static Rational PositiveInfinity = new Rational(1, 0);
        public static Rational NegativeInfinity = new Rational(-1, 0);

        /// <summary>
        /// Constructor with parameters
        /// </summary>
        /// <param name="numerator">numerator of fraction</param>
        /// <param name="denominator">denominator of fraction</param>
        private Rational(int numerator, int denominator)
        {
            this.Original_Numerator = numerator;
            this.Original_Denominator = denominator;
            var temp = Rational.Reducing(Original_Numerator, Original_Denominator);
            this.Numerator = temp.Item1;
            this.Denominator = temp.Item2;
        }

        /// <summary>
        /// Create a Rational object
        /// </summary>
        /// <param name="numerator">numerator of fraction</param>
        /// <param name="denomerator">denominator of fraction</param>
        /// <returns></returns>
        public static Rational Create(int numerator, int denomerator)
        {
            if (denomerator != 0)
                return new Rational(numerator, denomerator);
            else return null;
        }

        /// <summary>
        /// Transform fraction to a string form
        /// </summary>
        /// <param name="type">type of string form(1 - n/m; 2 - 0.00)</param>
        /// <returns>string form of fraction</returns>
        public string ToString(int type)
        {
            switch(type)
            {
                case 1:
                    return (this.Numerator + "/" + this.Denominator);
                case 2:
                    double temp = (double)this.Numerator / (double)this.Denominator;
                    return (temp.ToString());
                default:
                    break;
            }
            return null;
        }

        /// <summary>
        /// Reducing fraction
        /// </summary>
        /// <returns>reduced fraction</returns>
        private static Tuple<int, int> Reducing(int n, int d)
        {
            int m;
            if (n > d)
                m = d;
            else m = n;
            for (int i = 1; i < m; i++)
            {
                if (n % i == 0 && m % i == 0)
                {
                    n /= i;
                    d /= i;
                }
            }
            var temp = new Tuple<int, int>(n, d);
            return temp;
        }

        /// <summary>
        /// Comparison of the two fractions
        /// </summary>
        /// <param name="compare_obj">Fraction, which is a comparison</param>
        /// <returns>result of comparison</returns>
        public int CompareTo(Rational compare_obj)
        {
            if (this < compare_obj)
                return -1;
            else if (this > compare_obj)
                return 1;
            else return 0;
        }

        /// <summary>
        /// Checks the equity between fraction
        /// </summary>
        /// <param name="other">Other fraction</param>
        /// <returns>Equity value</returns>
        public bool Equals(Rational other)
        {
            return CompareTo(other) == 0;
        }

        /// <summary>
        /// Checks the equity between this rational and another (Rational) object
        /// </summary>
        /// <param name="obj">Object for equals</param>
        /// <returns>Equity status</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Rational)) return false;
            return Equals((Rational)obj);
        }

        /// <summary>
        /// Gets hashcode for this instance
        /// </summary>
        /// <returns>Hashcode</returns>
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        /// <summary>
        /// Overriding the + operator to fractions
        /// </summary>
        /// <param name="fract_1">first fraction</param>
        /// <param name="fract_2">second fraction</param>
        /// <returns>result of additional</returns>
        public static Rational operator +(Rational fract_1, Rational fract_2)
        {
            int numer_temp, denom_temp;
            numer_temp = (fract_1.Numerator * fract_2.Denominator) + (fract_1.Denominator * fract_2.Numerator);
            denom_temp = fract_1.Denominator * fract_2.Denominator;
            return Rational.Create(numer_temp, denom_temp);
        }

        /// <summary>
        /// Overriding the - operator to fractions
        /// </summary>
        /// <param name="fract_1">first fraction</param>
        /// <param name="fract_2">Second fraction</param>
        /// <returns>result of substraction</returns>
        public static Rational operator -(Rational fract_1, Rational fract_2)
        {
            int numer_temp, denom_temp;
            numer_temp = (fract_1.Numerator * fract_2.Denominator) - (fract_1.Denominator * fract_2.Numerator);
            denom_temp = fract_1.Denominator * fract_2.Denominator;
            return Rational.Create(numer_temp, denom_temp);
        }

        /// <summary>
        /// Overriding the * operator to fractions
        /// </summary>
        /// <param name="fract_1">first fraction</param>
        /// <param name="fract_2">second fraction</param>
        /// <returns>result of multiplying</returns>
        public static Rational operator *(Rational fract_1, Rational fract_2)
        {
            int numer_temp, denom_temp;
            numer_temp = fract_1.Numerator * fract_2.Numerator;
            denom_temp = fract_1.Denominator * fract_2.Denominator;
            return Rational.Create(numer_temp, denom_temp);
        }

        /// <summary>
        /// Overriding the / operator to fractions
        /// </summary>
        /// <param name="fract_1">first fraction</param>
        /// <param name="fract_2">second fraction</param>
        /// <returns>result of division</returns>
        public static Rational operator /(Rational fract_1, Rational fract_2)
        {
            int numer_temp, denom_temp;
            numer_temp = fract_1.Numerator * fract_2.Denominator;
            denom_temp = fract_1.Denominator * fract_2.Numerator;
            return Rational.Create(numer_temp, denom_temp);
        }

        /// <summary>
        /// Overriding the <= operator to fractions
        /// </summary>
        /// <param name="fract_1">first fraction</param>
        /// <param name="fract_2">second fraction</param>
        /// <returns>result of comparison</returns>
        public static bool operator <=(Rational fract_1, Rational fract_2)
        {
            if (((object)fract_1).Equals(null) || ((object)fract_2).Equals(null))
                return false;
            return ((fract_1.Numerator * fract_2.Denominator) <= (fract_1.Denominator * fract_2.Numerator));  
        }

        /// <summary>
        /// Overriding the < operator to fractions
        /// </summary>
        /// <param name="fract_1">first fraction</param>
        /// <param name="fract_2">second fraction</param>
        /// <returns>result of comparison</returns>
        public static bool operator <(Rational fract_1, Rational fract_2)
        {
            if (((object)fract_1).Equals(null) || ((object)fract_2).Equals(null))
                return false;
            return ((fract_1.Numerator * fract_2.Denominator) < (fract_1.Denominator * fract_2.Numerator));
        }

        /// <summary>
        /// Overriding the >= operator to fractions
        /// </summary>
        /// <param name="fract_1">first fraction</param>
        /// <param name="fract_2">second fraction</param>
        /// <returns>result of comparison</returns>
        public static bool operator >=(Rational fract_1, Rational fract_2)
        {
            if (((object)fract_1).Equals(null) || ((object)fract_2).Equals(null))
                return false;
            return ((fract_1.Numerator * fract_2.Denominator) >= (fract_1.Denominator * fract_2.Numerator)); 
        }

        /// <summary>
        /// Overriding the > operator to fractions
        /// </summary>
        /// <param name="fract_1">first fraction</param>
        /// <param name="fract_2">second fraction</param>
        /// <returns>result of comparison</returns>
        public static bool operator >(Rational fract_1, Rational fract_2)
        {
            if (((object)fract_1).Equals(null) || ((object)fract_2).Equals(null))
                return false;
            return ((fract_1.Numerator * fract_2.Denominator) > (fract_1.Denominator * fract_2.Numerator)); 
        }

        /// <summary>
        /// Overriding the == operator to fractions
        /// </summary>
        /// <param name="fract_1">first fraction</param>
        /// <param name="fract_2">second fraction</param>
        /// <returns>result of comparison</returns>
        public static bool operator ==(Rational fract_1, Rational fract_2)
        {
            if ((object)fract_1 == null && (object)fract_2 == null) return true;

            if ((object)fract_1 == null || (object)fract_2 == null) return false;

            if ((fract_1.Numerator * fract_2.Denominator) == (fract_1.Denominator * fract_2.Numerator))
                return true;
            else return false;
        }

        /// <summary>
        /// Overriding the != operator to fractions
        /// </summary>
        /// <param name="fract_1">first fraction</param>
        /// <param name="fract_2">second fraction</param>
        /// <returns>result of comparison</returns>
        public static bool operator !=(Rational fract_1, Rational fract_2)
        {
            if ((object)fract_1 == null && (object)fract_2 == null) return false;

            if ((object)fract_1 == null || (object)fract_2 == null) return true;

            if ((fract_1.Numerator * fract_2.Denominator) != (fract_1.Denominator * fract_2.Numerator))
                return true;
            else return false;
        }

        /// <summary>
        /// Overriding the implicit operator to fraction
        /// </summary>
        /// <param name="x">Number, that transfer to Rational</param>
        /// <returns>Rational object</returns>
        public static implicit operator Rational(int x)
        {
            return Rational.Create(x, 1);
        }

        /// <summary>
        /// Overriding the explicit operator to fractions
        /// </summary>
        /// <param name="r">Rational, that transfer to double</param>
        /// <returns>Double number</returns>
        public static explicit operator double(Rational r)
        {
            return r.Numerator/r.Denominator;
        }

        /// <summary>
        /// Clone fraction
        /// </summary>
        /// <returns>clone of fraction</returns>
        public Rational Clone()
        {
            Rational copy = new Rational(this.Numerator, this.Denominator);
            return copy;
        }

        /// <summary>
        /// Parse string form of fraction to Rational 
        /// </summary>
        /// <param name="s">string form of fraction</param>
        /// <returns>fraction as an object of class Rational</returns>
        public static Rational Parse(string s)
        {
            if (Regex.IsMatch(s, @"^\d+/\d+"))
            {
                string[] parts = s.Split('/');
                return new Rational(int.Parse(parts[0]), int.Parse(parts[1]));
            }
            else throw new FormatException("Wrong rational string");
        }

    }
}
