using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monte_Karlo.Models
{
    public class Circle
    {
        public Point circleCenter = new Point(3, 1);
        public float radius = 2;
        public Direction direction = Direction.horizontal;
        public float C = 2;

        public Circle() { }

        public Circle(Point circleCenter, float radius, Direction direction, float c)
        {
            this.circleCenter = circleCenter;
            if (radius <= 0)
                throw new ArgumentException($"R <= 0: R = {radius}");
            this.radius = radius;
            this.direction = direction;
            this.C = c;
        }

        public override bool Equals(object obj)
        {
            return obj is Circle other &&
                circleCenter.X == other.circleCenter.X &&
                circleCenter.Y == other.circleCenter.Y &&
                radius == other.radius &&
                direction == other.direction &&
                C == other.C;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(circleCenter.X, circleCenter.Y, radius, direction, C);
        }

        public override string ToString()
        {
            return $"CircleCenter: {circleCenter}, Radius: {radius}, Direction: {direction}, C: {C}";
        }
    }
}
