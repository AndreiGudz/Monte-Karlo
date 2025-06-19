using Microsoft.EntityFrameworkCore;
using Monte_Karlo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monte_Karlo.DataBase
{
    public class DatabaseHelper
    {
        public DatabaseHelper()
        {
            InitializeDatabase();
        }

        public void InitializeDatabase()
        {
            using var context = new AppDbContext();
            context.Database.EnsureCreated();
        }

        public void SaveResults(Circle circle, int totalPoints,
            int pointsInCircle, int pointsInSegment, double analyticalResult, double monteCarloResult)
        {
            using var context = new AppDbContext();

            var circleParams = context.CircleParams
                .Include(cp => cp.Results)
                .FirstOrDefault(cp =>
                    cp.CenterX == circle.circleCenter.X &&
                    cp.CenterY == circle.circleCenter.Y &&
                    cp.Radius == circle.radius &&
                    cp.Direction == circle.direction &&
                    cp.C == circle.C &&
                    cp.TotalPoints == totalPoints);

            if (circleParams == null)
            {
                circleParams = new CircleParams
                {
                    CenterX = circle.circleCenter.X,
                    CenterY = circle.circleCenter.Y,
                    Radius = circle.radius,
                    Direction = circle.direction,
                    C = circle.C,
                    TotalPoints = totalPoints,
                    AnalyticalResult = analyticalResult
                };
                context.CircleParams.Add(circleParams);
            }

            var result = new SimulationResult
            {
                CircleParams = circleParams,
                PointsInCircle = pointsInCircle,
                PointsInSegment = pointsInSegment,
                MonteCarloResult = monteCarloResult
            };

            context.SimulationResults.Add(result);
            context.SaveChanges();
        }

        public CircleParams GetData(Circle circle, int totalPoints)
        {
            using var context = new AppDbContext();

            var query = context.CircleParams
                .Include(cp => cp.Results)
                .Where(cp =>
                    cp.CenterX == circle.circleCenter.X &&
                    cp.CenterY == circle.circleCenter.Y &&
                    cp.Radius == circle.radius &&
                    cp.Direction == circle.direction &&
                    cp.C == circle.C &&
                    cp.TotalPoints == totalPoints);

            return query.FirstOrDefault();
        }
    }
}
