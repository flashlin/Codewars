using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetIsPlayDarts.Models
{
    public class Dartboard
    {
        public readonly double BullsEye = 12.70;
        public static readonly double Bull = 31.8;
        public static readonly double TripleRingInnerCircle = 198;
        public static readonly double TripleRingOuterCircle = 214;
        public static readonly double DoubleRingInnerCircle = 324;
        public static readonly double DoubleRingOuterCircle = 340;
        public static readonly Coordinate Zero = new Coordinate(0, 0);

        public string GetScore(double x, double y)
        {
            var distance = GetDistance(Zero, new Coordinate(x, y));
            if (distance > DoubleRingOuterCircle / 2)
            {
                return "X";
            }

            return "X";
        }

        protected double GetDistance(Coordinate p1, Coordinate p2)
        {
            double distance = Math.Pow(Square(p1.X - p2.X) + Square(p1.Y - p2.Y), 0.5);
            return distance;
        }

        protected double Square(double n)
        {
            return Math.Pow(n, 2);
        }
    }
}
