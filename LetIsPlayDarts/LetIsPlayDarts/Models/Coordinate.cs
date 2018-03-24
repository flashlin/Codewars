using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetIsPlayDarts.Models
{
    public class Coordinate
    {
        public Coordinate(double x, double y)
        {
            X = x;
            Y = y;
        }
        public double X { get; set; }
        public double Y { get; set; }
        public override string ToString()
        {
            return $"{X},{Y}";
        }
    }
}
