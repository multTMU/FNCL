using System.Collections.Generic;
using System.Linq;

namespace GeometrySampling
{
    public class PlaneRanger : IPoint3DCollection
    {
        private readonly LineRanger LineA;
        private readonly LineRanger LineB;

        public PlaneRanger(Point3D node, Point3D endPointA, int interiorPointsAlongLineA,
            Point3D endPointB, int interiorPointsAlongLineB)
        {
            LineA = new LineRanger(node, endPointA, interiorPointsAlongLineA);
            LineB = new LineRanger(node, endPointB, interiorPointsAlongLineB);
        }

        public List<Point3D> GetPointCollection()
        {
            var Apoints = LineA.GetPointCollection();
            var Bpoints = LineB.GetPointCollection();

            List<Point3D> points = new List<Point3D>();

            points.AddRange(Apoints);
            points.AddRange(Bpoints);

            foreach (var a in Apoints)
            {
                foreach (var b in Bpoints)
                {
                    points.Add(a + b);
                }
            }

            return points.Distinct().ToList();
        }
    }
}
