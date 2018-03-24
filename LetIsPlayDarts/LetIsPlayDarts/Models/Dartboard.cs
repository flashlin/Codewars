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

        private readonly double[] _baseScoreOfAngles = { 20, 1, 18, 4, 13, 6, 10, 15, 2, 17, 3, 19, 7, 16, 8, 11, 14, 9, 12, 5 };
        private readonly double[] _distanceAreas = { BullsEye, Bull, TripleRingInnerCircle, TripleRingOuterCircle, DoubleRingInnerCircle, DoubleRingOuterCircle };
        private readonly string[] _multiplier = { "DB", "SB", "", "T", "", "D" };

        public string GetScore(double x, double y)
        {
            var pt = new Coordinate(x, y);

            var distance = GetDistance(Zero, pt) * 2;
            if (distance > DoubleRingOuterCircle)
            {
                return "X";
            }

            string multipler = GetMultipler(distance);
            if (multipler.Length == 2)
            {
                return multipler;
            }

            double baseScore = GetBaseScore(pt);
            string score = $"{multipler}{baseScore}";

            return score;
        }

        private double GetBaseScore(Coordinate pt)
        {
            int area = GetAreaNumber(pt);
            double baseScore = _baseScoreOfAngles[area];
            return baseScore;
        }

        private int GetAreaNumber(Coordinate pt)
        {
            var angle = CalculateAngle(Zero, pt);
            int area = (int)Math.Round(angle / AreaAngle);
            area = (area >= 20) ? 0 : area;
            return area;
        }

        private string GetMultipler(double distance)
        {
            int distanceArea = GetDistanceArea(distance);
            string multiple = $"{_multiplier[distanceArea]}";
            return multiple;
        }

        protected int GetDistanceArea(double distance)
        {
            for (int i = 0; i < _distanceAreas.Length; i++)
            {
                if (distance <= _distanceAreas[i])
                {
                    return i;
                }
            }
            return -1;
        }

        protected double CalculateAngle(Coordinate a, Coordinate b)
        {
            double angle = Math.Atan2(b.Y - a.Y, b.X - a.X) * 180 / Math.PI;
            if (IsFirstQuadrant(angle))
            {
                return 90 - angle;
            }

            if (IsSecondQuadrant(angle))
            {
                return 180 - Math.Abs(angle) + 180 + 90;
            }

            if (IsThirdQuadrant(angle))
            {
                return Math.Abs(angle) - 90 + 180;
            }

            return Math.Abs(angle) + 90;
        }

        private static bool IsThirdQuadrant(double angle)
        {
            return angle < -90;
        }

        private static bool IsSecondQuadrant(double angle)
        {
            return 180 >= angle && angle > 90;
        }

        private bool IsFirstQuadrant(double angle)
        {
            return 90 >= angle && angle >= 0;
        }

        protected double GetDistance(Coordinate p1, Coordinate p2)
        {
            return SurdForm(Square(p1.X - p2.X) + Square(p1.Y - p2.Y));
        }

        protected double SurdForm(double n)
        {
            return Math.Pow(n, 0.5);
        }

        protected double Square(double n)
        {
            return Math.Pow(n, 2);
        }
    }
    
}
