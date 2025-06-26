// Таблица с результатами эксперементов
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

        // Связь по внешнему ключу с таблицей параметров круга и линии, для которой проводился эксперемент
        public int CircleParamsId { get; set; }
        public CircleParams CircleParams { get; set; }

        // Вывод всех параметров в стоку
        public override string ToString()
        {
            return $"""
                   Id: {Id}, PointsInCircle: {PointsInCircle}, PointsInSegment: {PointsInSegment},
                   MonteCarloResult: {MonteCarloResult}, CircleParamsId: {CircleParamsId}
                   """;
        }
    }
}

