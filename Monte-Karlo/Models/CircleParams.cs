using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monte_Karlo.Models
{
    public class CircleParams
    {
        [Key]
        public int Id { get; set; }

        public double CenterX { get; set; }
        public double CenterY { get; set; }
        public double Radius { get; set; }
        public Direction Direction { get; set; }
        public double C { get; set; }
        public int TotalPoints { get; set; }
        public double AnalyticalResult { get; set; }

        public List<SimulationResult> Results { get; set; } = new List<SimulationResult>();
    }
}
