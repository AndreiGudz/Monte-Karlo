// Класс для хранения параметров окружности и линии
namespace Monte_Karlo.Models
{
    public class Circle
    {
        public Point circleCenter = new Point(3, 1);
        public float radius = 2;
        public Direction direction = Direction.horizontal;
        public float C = 2;

        // Конструктор без параметров для создания окружности и линии с значениями по умолчанию
        public Circle() { }

        // Конструктор для задания всех своих параметров
        public Circle(Point circleCenter, float radius, Direction direction, float c)
        {
            this.circleCenter = circleCenter;
            if (radius <= 0)
                throw new ArgumentException($"R <= 0: R = {radius}");
            this.radius = radius;
            this.direction = direction;
            this.C = c;
        }

        // Сравнение на равенство для EF
        public override bool Equals(object obj)
        {
            return obj is Circle other &&
                circleCenter.X == other.circleCenter.X &&
                circleCenter.Y == other.circleCenter.Y &&
                radius == other.radius &&
                direction == other.direction &&
                C == other.C;
        }

        // Генерация хэша для EF
        public override int GetHashCode()
        {
            return HashCode.Combine(circleCenter.X, circleCenter.Y, radius, direction, C);
        }

        // Вывод всех параметров в стоку
        public override string ToString()
        {
            return $"CircleCenter: {circleCenter}, Radius: {radius}, Direction: {direction}, C: {C}";
        }
    }
}
