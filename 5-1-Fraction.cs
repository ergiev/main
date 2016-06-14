using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_1_Fraction
{
    class Program
    {
        static void Main(string[] args)
        {
            Fraction a = new Fraction(1, 3);
            Console.WriteLine(a.ToString());
            Fraction b = new Fraction(2, 2);
            Console.WriteLine((a + b).ToString());
            Console.WriteLine((b - a).ToString());
        }
    }

    class Fraction
    {
        int chis;
        int znam;


        public Fraction(int c, int z)
        {
            chis = c;
            znam = z;
        }
        public int GetChis()
        {
            return chis;
        }
        public int GetZnam()
        {
            return znam;
        }
        public void SetChis(int a)
        {
            chis = a;
        }
        public void SetZnam(int a)
        {
            znam = a;
        }
        public override string ToString()
        {
            return chis.ToString() + '/' + znam.ToString(); ;
        }
        private static void ToObchiyZnam(ref Fraction one, ref Fraction two)
        {
            one.chis *= two.znam;
            two.chis *= one.znam;
            one.znam = two.znam = one.znam * two.znam;
        }
        public static Fraction operator +(Fraction left, Fraction right)
        {
            Fraction temp = new Fraction(0, 0);
            if (left.znam != right.znam)
            {
                ToObchiyZnam(ref left, ref right);
            }
            temp.znam = left.znam;
            temp.chis = left.chis + right.chis;
            return temp;
        }
        public static Fraction operator -(Fraction left, Fraction right)
        {
            Fraction temp = new Fraction(0, 0);
            if (left.znam != right.znam)
            {
                ToObchiyZnam(ref left, ref right);
            }
            temp.znam = left.znam;
            temp.chis = left.chis - right.chis;
            return temp;
        }
    }
}