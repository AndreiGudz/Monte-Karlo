using Monte_Karlo.Utilites.Calculators;
using Monte_Karlo.DataBase;
using Monte_Karlo.Models;
using Monte_Karlo.Utilites;
using Monte_Karlo.Utilites.Calculators;
using System;
using System.Collections.Concurrent;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    internal class Program
    {
        private static DatabaseHelper _bd;
        private static PointsGenerator _pg = new PointsGenerator();
        private static Stopwatch[] stopwatchs = new Stopwatch[7];

        static void Main(string[] args)
        {
            
        }
    }
}
