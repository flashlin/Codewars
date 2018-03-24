using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetIsPlayDarts.Models
{
    public class Dartboard
    {
        public static readonly double BullsEye = 12.70;
        public static readonly double Bull = 31.8;
        public static readonly double TripleRingInnerCircle = 198;
        public static readonly double TripleRingOuterCircle = 214;
        public static readonly double DoubleRingInnerCircle = 324;
        public static readonly double DoubleRingOuterCircle = 340;
        public static readonly int AreaAngle = 360 / 20;
        public static readonly Coordinate Zero = new Coordinate(0, 0);

        private double[] _angleScores = { 20, 1, 18, 4, 13, 6, 10, 15, 2, 17, 3, 19, 7, 16, 8, 11, 14, 9, 12, 5 };
        private double[] _distanceArea = { BullsEye, Bull, TripleRingInnerCircle, TripleRingOuterCircle, DoubleRingInnerCircle, DoubleRingOuterCircle };
        private string[] _multiple = { "DB", "SB", "", "T", "", "D" };

        public Dartboard()
        {
        }

        public string GetScore(double x, double y)
        {
            var pt = new Coordinate(x, y);

            var distance = GetDistance(Zero, pt) * 2;
            if (distance > DoubleRingOuterCircle)
            {
                return "X";
            }

            if (distance <= BullsEye)
            {
                return "DB";
            }

            if (distance <= Bull)
            {
                return "SB";
            }

            var angle = CalculateAngle(Zero, pt);

            int area = (int) Math.Round(angle / AreaAngle);
            area = (area >= 20) ? 0 : area;

            double baseScore = _angleScores[area];

            int distanceArea = GetDistanceArea(distance);
            string score = $"{_multiple[distanceArea]}{baseScore}";

            return score;
        }

        protected int GetDistanceArea(double distance)
        {
            for (int i = 0; i < _distanceArea.Length; i++)
            {
                if (distance <= _distanceArea[i])
                {
                    return i;
                }
            }
            return -1;
        }

        protected double CalculateAngle(Coordinate a, Coordinate b)
        {
            double angle = Math.Atan2(b.Y - a.Y, b.X - a.X) * 180 / Math.PI;
            if (90 >= angle && angle >= 0)
            {
                return 90 - angle;
            }

            if (180 >= angle && angle > 90)
            {
                return 180 - Math.Abs(angle) + 180 + 90;
            }

            if (angle < -90)
            {
                return Math.Abs(angle) - 90 + 180;
            }

            return Math.Abs(angle) + 90;
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
