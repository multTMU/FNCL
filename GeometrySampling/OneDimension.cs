using System.Collections.Generic;

namespace GeometrySampling
{
    public class LineRanger : IPoint3DCollection
    {
        private readonly int interiorPoints;

        private readonly Point3D unitVector;
        private readonly Point3D startPoint;
        private readonly Point3D endPoint;

        public LineRanger(Point3D startingPoint, Point3D endingPoint, int interiorPointsAlongLine)
        {
            interiorPoints = interiorPointsAlongLine;
            startPoint = startingPoint;
            endPoint = endingPoint;

            unitVector = Point3DHelper.GetUnitVector(startPoint, endPoint);
        }

        private Point3D GetPoint(in double t)
        {
            return new Point3D(startPoint.X + unitVector.X * t,
                startPoint.Y + unitVector.Y * t,
                startPoint.Z + unitVector.Z * t);
        }

        public List<Point3D> GetPointCollection()
        {
            List<Point3D> positions = new List<Point3D>();

            double stepSize = Point3DHelper.GetDistance(startPoint, endPoint) / (interiorPoints + 1);

            positions.Add(getStartPoint());
            for (int i = 1; i <= interiorPoints; i++)
            {
                positions.Add(GetPoint(stepSize * i));
            }

            positions.Add(getEndPoint());

            return positions;
        }

        private Point3D getEndPoint()
        {
            return new Point3D(endPoint.X, endPoint.Y, endPoint.Z);
        }

        private Point3D getStartPoint()
        {
            return new Point3D(startPoint.X, startPoint.Y, startPoint.Z);
        }
    }
}
