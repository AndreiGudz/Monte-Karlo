namespace Monte_Karlo.Models
{
    public class PointsSnapshot
    {
        public List<PointF> Points { get; }
        public List<PointF> IncludedPoints { get; }
        public List<PointF> CuttedPoints { get; }

        public PointsSnapshot(
            List<PointF> points,
            List<PointF> includedPoints,
            List<PointF> cuttedPoints)
        {
            Points = points;
            IncludedPoints = includedPoints;
            CuttedPoints = cuttedPoints;
        }
    }
}