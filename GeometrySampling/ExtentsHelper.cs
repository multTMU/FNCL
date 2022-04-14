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
        public static MyPoint3D GetCenterFromCylinderBase(MyPoint3D Base, MyPoint3D Axis, double Height)
        {
            return Base + (Height / 2) * Axis;
        }
        
        public static Encased<MyPoint3D> GetSharedCenter(MyPoint3D center)
        {
            return new Encased<MyPoint3D>(center, center);
        }
    }

    public struct SphereExtent
    {
        public MyPoint3D Center;
        public double Radius;

        public SphereExtent(MyPoint3D center, double radius)
        {
            Center = center;
            Radius = radius;
        }
    }

    public struct CuboidExtent
    {
        public MyPoint3D Lower;
        public MyPoint3D Upper;

        public CuboidExtent(MyPoint3D lower, MyPoint3D upper)
        {
            Lower = lower;
            Upper = upper;
        }
    }

    public struct CylinderExtent
    {
        public double Height;
        public double Radius;
        public MyPoint3D Axis;

        public CylinderExtent(double height, double radius, MyPoint3D axis)
        {
            Height = height;
            Radius = radius;
            Axis = Point3DHelper.GetUnitVector(axis);
        }
    }
}
