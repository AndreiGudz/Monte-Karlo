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
    }
}
