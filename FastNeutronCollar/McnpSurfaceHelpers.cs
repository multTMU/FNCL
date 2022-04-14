using System;
using GeometrySampling;

namespace FastNeutronCollar
{
    public static class VolumeHelper
    {
        public static double GetSphereVolume(double radius)
        {
            return (4 / 3) * Math.PI * Math.Pow(radius, 3);
        }

        public static double GetSphereVolume(SphereExtent sphere)
        {
            return GetSphereVolume(sphere.Radius);
        }

        public static double GetCylinderVolume(CylinderExtent cylinder)
        {
            return GetCylinderVolume(cylinder.Radius, cylinder.Height);
        }

        public static double GetCylinderVolume(double radius, double height)
        {
            return Math.PI * Math.Pow(radius, 2) * height;
        }

        public static double GetCuboidVolume(MyPoint3D extents)
        {
            return extents.X * extents.Y * extents.Z;
        }

        public static double GetCuboidVolume(CuboidExtent cuboid)
        {
            return GetCuboidVolume(cuboid.Upper - cuboid.Lower);
        }

        public static Encased<double> GetEncaseCuboidVolume(Encased<CuboidExtent> cuboid)
        {
            return GetEncasedVolume(GetCuboidVolume(cuboid.Inner), GetCuboidVolume(cuboid.Outer));
        }

        private static Encased<double> GetEncasedVolume(double innerVolume, double outerVolume)
        {
            return new Encased<double> {Inner = innerVolume, Outer = outerVolume - innerVolume};
        }

        public static Encased<double> GetEncasedCylinderVolume(Encased<CylinderExtent> cylinder)
        {
            return GetEncasedVolume(GetCylinderVolume(cylinder.Inner), GetCylinderVolume(cylinder.Outer));
        }

        public static Encased<double> GetEncaseSphereVolume(Encased<SphereExtent> sphere)
        {
            return GetEncasedVolume(GetSphereVolume(sphere.Inner), GetSphereVolume(sphere.Outer));
        }
    }

    public static class McnpSurfaces
    {
        private const string NAME_CYLINDER = "rcc";
        private const string NAME_SPHERE = "sph";
        private const string NAME_RECTANGLE = "rpp";
        private const string NAME_BOX = "box";
        private const string NAME_PLANE = "p";
        private const string NAME_WEDGE = "wed";

        public static string Format = "F6";

        public static string GetRightCircularCylinder(MyPoint3D baseCenter, MyPoint3D axisVectorWithLength, double radius)
        {
            return NAME_CYLINDER + " " + baseCenter.ToString() + " " + axisVectorWithLength.ToString() + " " +
                   radius.ToString(MyPoint3D.format);
        }

        public static string GetRightCircularCylinder(MyPoint3D baseCenter, CylinderExtent cylinderExtent)
        {
            return GetRightCircularCylinder(baseCenter, cylinderExtent.Axis, cylinderExtent.Height,
                cylinderExtent.Radius);
        }

        public static string GetRightCircularCylinder(MyPoint3D baseCenter, MyPoint3D axisVector, double length,
            double radius)
        {
            MyPoint3D axisVectorWithLength = length * axisVector;
            return NAME_CYLINDER + " " + baseCenter.ToString() + " " + axisVectorWithLength.ToString() + " " +
                   radius.ToString(MyPoint3D.format);
        }

        public static string GetSphere(MyPoint3D center, double radius)
        {
            return NAME_SPHERE + " " + center.ToString() + " " + radius.ToString(MyPoint3D.format);
        }

        public static string GetRectangularParallelepipedFromCenterExtents(MyPoint3D center, MyPoint3D extents)
        {
            return GetRectangularParallelepiped(McnpSurfaceHelpers.GetRectangleMinPoint(center, extents),
                McnpSurfaceHelpers.GetRectangleMaxPoint(center, extents));
        }

        public static string GetRectangularParallelepiped(MyPoint3D minimumPoints, MyPoint3D maximumPoints)
        {
            MyPoint3D minPoints = McnpSurfaceHelpers.GetMinPointFromBoundPoints(minimumPoints, maximumPoints);
            MyPoint3D maxPoints = McnpSurfaceHelpers.GetMaxPointFromBoundPoints(minimumPoints, maximumPoints);

            return NAME_RECTANGLE + " " +
                   minPoints.X.ToString(MyPoint3D.format) + " " + maxPoints.X.ToString(MyPoint3D.format) + " " +
                   minPoints.Y.ToString(MyPoint3D.format) + " " + maxPoints.Y.ToString(MyPoint3D.format) + " " +
                   minPoints.Z.ToString(MyPoint3D.format) + " " + maxPoints.Z.ToString(MyPoint3D.format);
        }

        public static string GetArbitrarilyOrientedOrthogonalBox(MyPoint3D corner, Matrix3D sides)
        {
            return GetArbitrarilyOrientedOrthogonalBox(corner, sides.Xrow, sides.Yrow, sides.Zrow);
        }

        public static string GetArbitrarilyOrientedOrthogonalBox(MyPoint3D corner, MyPoint3D side1, MyPoint3D side2,
            MyPoint3D side3)
        {
            return NAME_BOX + " " + corner.ToString() + " " + side1.ToString() + " " + side2.ToString() + " " +
                   side3.ToString();
        }

        public static string GetPlane(MyPoint3D planeCoefficients, double planeConstant)
        {
            return NAME_PLANE + " " + planeCoefficients.ToString() + " " + planeConstant.ToString(MyPoint3D.format);
        }

        public static string GetPlane(MyPoint3D point, MyPoint3D normal)
        {
            return GetPlane(Point3DHelper.GetUnitVector(normal), Point3DHelper.DotProduct(normal, point));
        }

        public static string GetWedge(MyPoint3D vertex, MyPoint3D vectorBaseA, MyPoint3D vectorBaseB, MyPoint3D vectorHeight)
        {
            return NAME_WEDGE + " " + vertex.ToString() + " " + vectorBaseA.ToString() + " " + vectorBaseB.ToString() +
                   " " + vertex.ToString();
        }
    }

    public static class McnpSurfaceHelpers
    {
        public static MyPoint3D GetRectangleMinPoint(MyPoint3D center, MyPoint3D extents)
        {
            return center - (extents / 2);
        }

        public static MyPoint3D GetRectangleMaxPoint(MyPoint3D center, MyPoint3D extents)
        {
            return center + (extents / 2);
        }

        public static MyPoint3D GetMinPointFromBoundPoints(MyPoint3D pointA, MyPoint3D pointB)
        {
            return new MyPoint3D()
            {
                X = Math.Min(pointA.X, pointB.X), Y = Math.Min(pointA.Y, pointB.Y), Z = Math.Min(pointA.Z, pointB.Z)
            };
        }

        public static MyPoint3D GetMaxPointFromBoundPoints(MyPoint3D pointA, MyPoint3D pointB)
        {
            return new MyPoint3D()
            {
                X = Math.Max(pointA.X, pointB.X), Y = Math.Max(pointA.Y, pointB.Y), Z = Math.Max(pointA.Z, pointB.Z)
            };
        }

        public static double BoundingSphereRadiusForCylinder(double radius, MyPoint3D axisWithLength)
        {
            return Math.Sqrt(Math.Pow(radius, 2) + Math.Pow(Point3DHelper.GetMagnitude(axisWithLength) / 2, 2));
        }

        public static double BoundingSphereRadiusForCylinder(double radius, double height)
        {
            return Math.Sqrt(Math.Pow(radius, 2) + Math.Pow(height / 2, 2));
        }
    }
}
