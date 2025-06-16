using System.ComponentModel.DataAnnotations;

namespace Monte_Karlo.Models
{
    public class SimulationResult
    {
        [Key]
        public int Id { get; set; }

        public int PointsInCircle { get; set; }
        public int PointsInSegment { get; set; }
        public double MonteCarloResult { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;

        public int CircleParamsId { get; set; }
        public CircleParams CircleParams { get; set; }
    }
}
