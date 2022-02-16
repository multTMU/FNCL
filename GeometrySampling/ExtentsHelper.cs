namespace GeometrySampling
{
    public struct Encased<T>
    {
        public T Inner;
        public T Outer;

        public Encased(T inner, T outer)
        {
            Inner = inner;
            Outer = outer;
        }
    }

    public static class ExtentsHelper
    {
        public static Point3D GetCenterFromCylinderBase(Point3D Base, Point3D Axis, double Height)
        {
            return Base + (Height / 2) * Axis;
        }
        
        public static Encased<Point3D> GetSharedCenter(Point3D center)
        {
            return new Encased<Point3D>(center, center);
        }
    }

    public struct SphereExtent
    {
        public Point3D Center;
        public double Radius;

        public SphereExtent(Point3D center, double radius)
        {
            Center = center;
            Radius = radius;
        }
    }

    public struct CuboidExtent
    {
        public Point3D Lower;
        public Point3D Upper;

        public CuboidExtent(Point3D lower, Point3D upper)
        {
            Lower = lower;
            Upper = upper;
        }
    }

    public struct CylinderExtent
    {
        public double Height;
        public double Radius;
        public Point3D Axis;

        public CylinderExtent(double height, double radius, Point3D axis)
        {
            Height = height;
            Radius = radius;
            Axis = Point3DHelper.GetUnitVector(axis);
        }
    }
}
