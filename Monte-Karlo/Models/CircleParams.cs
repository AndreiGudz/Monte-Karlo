﻿// Таблица с параметрами окружности, для которой проводят эксперементы
using System.ComponentModel.DataAnnotations;

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

        // Связь с результатами эксперементов с такими параметрами
        public List<SimulationResult> Results { get; set; } = new List<SimulationResult>();

        // Вывод всех параметров в стоку
        public override string ToString()
        {
            return $"""
                   Id: {Id}, CenterX: {CenterX}, CenterY: {CenterY}, Radius: {Radius}, 
                   Direction: {Direction}, C: {C}, TotalPoints: {TotalPoints},
                   AnalyticalResult: {AnalyticalResult}, ResultsCount: {Results.Count}
                   """;
        }
    }
}
