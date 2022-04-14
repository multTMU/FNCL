using System;
using System.Collections.Generic;

namespace GeometrySampling
{
    public interface IPoint3DCollection
    {
        List<MyPoint3D> GetPointCollection();
    }

    public struct MyPoint3D
    {
        public double X;
        public double Y;
        public double Z;

        public const string FORMAT = "F4";
        public static string format = FORMAT;
        public const string DEFAULT_SET = " ";

        public MyPoint3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public new string ToString(string seperator = DEFAULT_SET)
        {
            return X.ToString(format) + seperator + Y.ToString(format) + seperator + Z.ToString(format);
        }

        public static MyPoint3D operator +(MyPoint3D A, MyPoint3D B)
        {
            MyPoint3D C = new MyPoint3D {X = A.X + B.X, Y = A.Y + B.Y, Z = A.Z + B.Z};
            return C;
        }

        public static MyPoint3D operator +(MyPoint3D A, double b)
        {
            MyPoint3D C = new MyPoint3D {X = A.X + b, Y = A.Y + b, Z = A.Z + b};
            return C;
        }

        public static MyPoint3D operator -(MyPoint3D A, double b)
        {
            MyPoint3D C = new MyPoint3D {X = A.X - b, Y = A.Y - b, Z = A.Z - b};
            return C;
        }

        public static MyPoint3D operator -(MyPoint3D A, MyPoint3D B)
        {
            MyPoint3D C = new MyPoint3D {X = A.X - B.X, Y = A.Y - B.Y, Z = A.Z - B.Z};
            return C;
        }

        public static MyPoint3D operator *(MyPoint3D A, MyPoint3D B)
        {
            MyPoint3D C = new MyPoint3D {X = A.X * B.X, Y = A.Y * B.Y, Z = A.Z * B.Z};
            return C;
        }

        public static MyPoint3D operator *(MyPoint3D A, double b)
        {
            return b * A;
        }

        public static MyPoint3D operator *(double b, MyPoint3D A)
        {
            MyPoint3D C = new MyPoint3D {X = b * A.X, Y = b * A.Y, Z = b * A.Z};
            return C;
        }

        public static MyPoint3D operator /(MyPoint3D A, double b)
        {
            MyPoint3D C = A;
            C.X /= b;
            C.Y /= b;
            C.Z /= b;
            return C;
        }

        public static MyPoint3D Swap_213(MyPoint3D A)
        {
            MyPoint3D C = new MyPoint3D {X = A.Y, Y = A.X, Z = A.Z};
            return C;
        }

        public static MyPoint3D Swap_231(MyPoint3D A)
        {
            MyPoint3D C = new MyPoint3D {X = A.Y, Y = A.Z, Z = A.X};
            return C;
        }

        public static MyPoint3D Swap_132(MyPoint3D A)
        {
            MyPoint3D C = new MyPoint3D {X = A.X, Y = A.Z, Z = A.Y};
            return C;
        }

        public static MyPoint3D Swap_312(MyPoint3D A)
        {
            MyPoint3D C = new MyPoint3D {X = A.Z, Y = A.X, Z = A.Y};
            return C;
        }

        public static MyPoint3D Swap_321(MyPoint3D A)
        {
            MyPoint3D C = new MyPoint3D {X = A.Z, Y = A.Y, Z = A.X};
            return C;
        }

        public static MyPoint3D MirrorX(MyPoint3D A)
        {
            MyPoint3D C = new MyPoint3D();
            C = A;
            C.X = -C.X;
            return C;
        }

        public static MyPoint3D MirrorY(MyPoint3D A)
        {
            MyPoint3D C = new MyPoint3D();
            C = A;
            C.Y = -C.Y;
            return C;
        }

        public static MyPoint3D Mirror(MyPoint3D A)
        {
            MyPoint3D C = new MyPoint3D();
            C = A;
            C.X = -C.X;
            C.Y = -C.Y;
            C.Z = -C.Z;
            return C;
        }

        public static MyPoint3D MirrorZ(MyPoint3D A)
        {
            MyPoint3D C = new MyPoint3D();
            C = A;
            C.Z = -C.Z;
            return C;
        }
    }

    public struct Matrix3D
    {
        public MyPoint3D Xrow;
        public MyPoint3D Yrow;
        public MyPoint3D Zrow;

        public Matrix3D(MyPoint3D x, MyPoint3D y, MyPoint3D z)
        {
            Xrow = x;
            Yrow = y;
            Zrow = z;
        }

        public new string ToString()
        {
            return Xrow.ToString() + " " + Yrow.ToString() + " " + Zrow.ToString();
        }
    }

    public static class Point3DHelper
    {
        private static readonly MyPoint3D Origin = new MyPoint3D {X = 0, Y = 0, Z = 0};

        public static double GetDistance(MyPoint3D pointA, MyPoint3D pointB)
        {
            MyPoint3D delta = pointB - pointA;
            return Math.Sqrt(delta.X * delta.X + delta.Y * delta.Y + delta.Z * delta.Z);
        }

        public static double GetMagnitude(MyPoint3D pointA)
        {
            return GetDistance(Origin, pointA);
        }

        public static MyPoint3D GetUnitVector(MyPoint3D point)
        {
            return GetUnitVector(Origin, point);
        }

        public static MyPoint3D GetUnitVector(MyPoint3D startPoint, MyPoint3D endPoint)
        {
            double distance = GetDistance(startPoint, endPoint);
            if (distance == 0)
            {
                return Origin;
            }
            MyPoint3D delta = endPoint - startPoint;
            MyPoint3D unitVector = new MyPoint3D(delta.X / distance, delta.Y / distance, delta.Z / distance);
            return unitVector;
        }

        public static double DotProduct(MyPoint3D pointA, MyPoint3D pointB)
        {
            MyPoint3D pointC = pointA * pointB;
            return pointC.X + pointC.Y + pointC.Z;
        }

        public static MyPoint3D CrossProduct(MyPoint3D pointA, MyPoint3D pointB)
        {
            MyPoint3D pointC = new MyPoint3D
            {
                X = pointA.Y * pointB.Z - pointA.Z * pointB.Y,
                Y = pointA.Z * pointB.X - pointA.X * pointB.Z,
                Z = pointA.X * pointB.Y - pointA.Y * pointB.X
            };
            return pointC;
        }

        public static Matrix3D GetRotationMatrix(MyPoint3D basisVector, MyPoint3D newVector)
        {
            var rowX = new MyPoint3D
            {
                X = DotProduct(basisVector, newVector),
                Y = -1 * GetMagnitude(CrossProduct(basisVector, newVector)),
                Z = 0
            };

            var rowY = new MyPoint3D
            {
                X = GetMagnitude(CrossProduct(basisVector, newVector)),
                Y = DotProduct(basisVector, newVector),
                Z = 0
            };

            var rowZ = new MyPoint3D {X = 0, Y = 0, Z = 1};

            return new Matrix3D {Xrow = rowX, Yrow = rowY, Zrow = rowZ};
        }

        public static double GetVolume(Matrix3D sides)
        {
            return GetMagnitude(sides.Xrow) * GetMagnitude(sides.Yrow) * GetMagnitude(sides.Zrow);
        }
    }


    public class DimensionRanger
    {
        public double StartPoint
        {
            get { return Lower; }
        }

        public double EndPoint
        {
            get { return Upper; }
        }

        private readonly int InteriorPoints;
        private readonly double Lower;
        private readonly double Upper;
        private readonly double StepSize;
        private readonly bool SkipEnd;

        public DimensionRanger(double low, double high, int interiorPoints, bool skipEnd = false)
        {
            Lower = low;
            Upper = high;
            InteriorPoints = interiorPoints;
            SkipEnd = skipEnd;
            StepSize = (Upper - Lower) / (InteriorPoints + 1);
        }

        public List<double> GetValues()
        {
            List<double> points = new List<double>();
            points.Add(Lower); // avoid edge round off
            for (int i = 1; i <= InteriorPoints; i++)
            {
                points.Add(Lower + StepSize * i);
            }

            // skip in the case of phi [0,2pi)
            if (!SkipEnd)
            {
                points.Add(Upper); // avoid edge round off
            }

            return points;
        }
    }
}
