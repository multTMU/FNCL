using System;
using System.Collections.Generic;

namespace GeometrySampling
{
    public abstract class PointRanger3D : IPoint3DCollection
    {
        protected DimensionRanger Dim1;
        protected DimensionRanger Dim2;
        protected DimensionRanger Dim3;

        protected PointRanger3D(DimensionRanger dim1Ranger, DimensionRanger dim2Ranger, DimensionRanger dim3Ranger)
        {
            Dim1 = dim1Ranger;
            Dim2 = dim2Ranger;
            Dim3 = dim3Ranger;
        }

        public virtual List<MyPoint3D> GetPointCollection()
        {
            List<MyPoint3D> positions = new List<MyPoint3D>();
            foreach (double d1 in Dim1.GetValues())
            {
                foreach (double d2 in Dim2.GetValues())
                {
                    foreach (double d3 in Dim3.GetValues())
                    {
                        positions.Add(GetPoint(d1, d2, d3));
                    }
                }
            }

            return positions;
        }

        protected abstract MyPoint3D GetPoint(in double d1, in double d2, in double d3);
    }


    public class CuboidRanger : PointRanger3D
    {
        public CuboidRanger(DimensionRanger xRange, DimensionRanger yRange, DimensionRanger zRange) : base(xRange,
            yRange, zRange)
        {
        }

        protected override MyPoint3D GetPoint(in double x, in double y, in double z)
        {
            return new MyPoint3D(x, y, z);
        }
    }

    public class SphericalRanger : PointRanger3D
    {
        public SphericalRanger(DimensionRanger radiusRanger, int nCosine, int nPhi) : base(radiusRanger,
            new DimensionRanger(-1, 1, nCosine), new DimensionRanger(0, 2 * Math.PI, nPhi, true))
        {
        }

        protected override MyPoint3D GetPoint(in double r, in double cosine, in double phi)
        {
            double sine = Math.Sin(Math.Acos(cosine));
            double x = r * sine * Math.Cos(phi);
            double y = r * sine * Math.Sin(phi);
            double z = r * cosine;

            return new MyPoint3D(x, y, z);
        }
    }

    public class CylindricalRanger : PointRanger3D
    {
        public CylindricalRanger(DimensionRanger radiusRanger, DimensionRanger heightRanger, int nPhi) : base(
            radiusRanger, heightRanger, new DimensionRanger(0, 2 * Math.PI, nPhi))
        {
        }

        protected override MyPoint3D GetPoint(in double radius, in double height, in double phi)
        {
            double x = radius * Math.Cos(phi);
            double y = radius * Math.Sin(phi);
            return new MyPoint3D(x, y, height);
        }
    }
}
