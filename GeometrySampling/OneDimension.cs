using System.Collections.Generic;

namespace GeometrySampling
{
    public class LineRanger : IPoint3DCollection
    {
        private readonly int interiorPoints;

        private readonly MyPoint3D unitVector;
        private readonly MyPoint3D startPoint;
        private readonly MyPoint3D endPoint;

        public LineRanger(MyPoint3D startingPoint, MyPoint3D endingPoint, int interiorPointsAlongLine)
        {
            interiorPoints = interiorPointsAlongLine;
            startPoint = startingPoint;
            endPoint = endingPoint;

            unitVector = Point3DHelper.GetUnitVector(startPoint, endPoint);
        }

        private MyPoint3D GetPoint(in double t)
        {
            return new MyPoint3D(startPoint.X + unitVector.X * t,
                startPoint.Y + unitVector.Y * t,
                startPoint.Z + unitVector.Z * t);
        }

        public List<MyPoint3D> GetPointCollection()
        {
            List<MyPoint3D> positions = new List<MyPoint3D>();

            double stepSize = Point3DHelper.GetDistance(startPoint, endPoint) / (interiorPoints + 1);

            positions.Add(getStartPoint());
            for (int i = 1; i <= interiorPoints; i++)
            {
                positions.Add(GetPoint(stepSize * i));
            }

            positions.Add(getEndPoint());

            return positions;
        }

        private MyPoint3D getEndPoint()
        {
            return new MyPoint3D(endPoint.X, endPoint.Y, endPoint.Z);
        }

        private MyPoint3D getStartPoint()
        {
            return new MyPoint3D(startPoint.X, startPoint.Y, startPoint.Z);
        }
    }
}
