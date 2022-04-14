using System.Collections.Generic;
using System.Linq;

namespace GeometrySampling
{
    public class PlaneRanger : IPoint3DCollection
    {
        private readonly LineRanger LineA;
        private readonly LineRanger LineB;

        public PlaneRanger(MyPoint3D node, MyPoint3D endPointA, int interiorPointsAlongLineA,
            MyPoint3D endPointB, int interiorPointsAlongLineB)
        {
            LineA = new LineRanger(node, endPointA, interiorPointsAlongLineA);
            LineB = new LineRanger(node, endPointB, interiorPointsAlongLineB);
        }

        public List<MyPoint3D> GetPointCollection()
        {
            var Apoints = LineA.GetPointCollection();
            var Bpoints = LineB.GetPointCollection();

            List<MyPoint3D> points = new List<MyPoint3D>();

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
