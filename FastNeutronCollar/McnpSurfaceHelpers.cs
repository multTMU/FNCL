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

        public static double GetCuboidVolume(Point3D extents)
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

        public static string GetRightCircularCylinder(Point3D baseCenter, Point3D axisVectorWithLength, double radius)
        {
            return NAME_CYLINDER + " " + baseCenter.ToString() + " " + axisVectorWithLength.ToString() + " " +
                   radius.ToString(Point3D.format);
        }

        public static string GetRightCircularCylinder(Point3D baseCenter, CylinderExtent cylinderExtent)
        {
            return GetRightCircularCylinder(baseCenter, cylinderExtent.Axis, cylinderExtent.Height,
                cylinderExtent.Radius);
        }

        public static string GetRightCircularCylinder(Point3D baseCenter, Point3D axisVector, double length,
            double radius)
        {
            Point3D axisVectorWithLength = length * axisVector;
            return NAME_CYLINDER + " " + baseCenter.ToString() + " " + axisVectorWithLength.ToString() + " " +
                   radius.ToString(Point3D.format);
        }

        public static string GetSphere(Point3D center, double radius)
        {
            return NAME_SPHERE + " " + center.ToString() + " " + radius.ToString(Point3D.format);
        }

        public static string GetRectangularParallelepipedFromCenterExtents(Point3D center, Point3D extents)
        {
            return GetRectangularParallelepiped(McnpSurfaceHelpers.GetRectangleMinPoint(center, extents),
                McnpSurfaceHelpers.GetRectangleMaxPoint(center, extents));
        }

        public static string GetRectangularParallelepiped(Point3D minimumPoints, Point3D maximumPoints)
        {
            Point3D minPoints = McnpSurfaceHelpers.GetMinPointFromBoundPoints(minimumPoints, maximumPoints);
            Point3D maxPoints = McnpSurfaceHelpers.GetMaxPointFromBoundPoints(minimumPoints, maximumPoints);

            return NAME_RECTANGLE + " " +
                   minPoints.X.ToString(Point3D.format) + " " + maxPoints.X.ToString(Point3D.format) + " " +
                   minPoints.Y.ToString(Point3D.format) + " " + maxPoints.Y.ToString(Point3D.format) + " " +
                   minPoints.Z.ToString(Point3D.format) + " " + maxPoints.Z.ToString(Point3D.format);
        }

        public static string GetArbitrarilyOrientedOrthogonalBox(Point3D corner, Matrix3D sides)
        {
            return GetArbitrarilyOrientedOrthogonalBox(corner, sides.Xrow, sides.Yrow, sides.Zrow);
        }

        public static string GetArbitrarilyOrientedOrthogonalBox(Point3D corner, Point3D side1, Point3D side2,
            Point3D side3)
        {
            return NAME_BOX + " " + corner.ToString() + " " + side1.ToString() + " " + side2.ToString() + " " +
                   side3.ToString();
        }

        public static string GetPlane(Point3D planeCoefficients, double planeConstant)
        {
            return NAME_PLANE + " " + planeCoefficients.ToString() + " " + planeConstant.ToString(Point3D.format);
        }

        public static string GetPlane(Point3D point, Point3D normal)
        {
            return GetPlane(Point3DHelper.GetUnitVector(normal), Point3DHelper.DotProduct(normal, point));
        }

        public static string GetWedge(Point3D vertex, Point3D vectorBaseA, Point3D vectorBaseB, Point3D vectorHeight)
        {
            return NAME_WEDGE + " " + vertex.ToString() + " " + vectorBaseA.ToString() + " " + vectorBaseB.ToString() +
                   " " + vertex.ToString();
        }
    }

    public static class McnpSurfaceHelpers
    {
        public static Point3D GetRectangleMinPoint(Point3D center, Point3D extents)
        {
            return center - (extents / 2);
        }

        public static Point3D GetRectangleMaxPoint(Point3D center, Point3D extents)
        {
            return center + (extents / 2);
        }

        public static Point3D GetMinPointFromBoundPoints(Point3D pointA, Point3D pointB)
        {
            return new Point3D()
            {
                X = Math.Min(pointA.X, pointB.X), Y = Math.Min(pointA.Y, pointB.Y), Z = Math.Min(pointA.Z, pointB.Z)
            };
        }

        public static Point3D GetMaxPointFromBoundPoints(Point3D pointA, Point3D pointB)
        {
            return new Point3D()
            {
                X = Math.Max(pointA.X, pointB.X), Y = Math.Max(pointA.Y, pointB.Y), Z = Math.Max(pointA.Z, pointB.Z)
            };
        }

        public static double BoundingSphereRadiusForCylinder(double radius, Point3D axisWithLength)
        {
            return Math.Sqrt(Math.Pow(radius, 2) + Math.Pow(Point3DHelper.GetMagnitude(axisWithLength) / 2, 2));
        }

        public static double BoundingSphereRadiusForCylinder(double radius, double height)
        {
            return Math.Sqrt(Math.Pow(radius, 2) + Math.Pow(height / 2, 2));
        }
    }
}
