using System;
using System.Collections.Generic;

namespace GeometrySampling
{
    public interface IPoint3DCollection
    {
        List<Point3D> GetPointCollection();
    }

    public struct Point3D
    {
        public double X;
        public double Y;
        public double Z;

        public const string FORMAT = "F4";
        public static string format = FORMAT;
        public const string DEFAULT_SET = " ";

        public Point3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public new string ToString(string seperator = DEFAULT_SET)
        {
            return X.ToString(format) + seperator + Y.ToString(format) + seperator + Z.ToString(format);
        }

        public static Point3D operator +(Point3D A, Point3D B)
        {
            Point3D C = new Point3D {X = A.X + B.X, Y = A.Y + B.Y, Z = A.Z + B.Z};
            return C;
        }

        public static Point3D operator +(Point3D A, double b)
        {
            Point3D C = new Point3D {X = A.X + b, Y = A.Y + b, Z = A.Z + b};
            return C;
        }

        public static Point3D operator -(Point3D A, double b)
        {
            Point3D C = new Point3D {X = A.X - b, Y = A.Y - b, Z = A.Z - b};
            return C;
        }

        public static Point3D operator -(Point3D A, Point3D B)
        {
            Point3D C = new Point3D {X = A.X - B.X, Y = A.Y - B.Y, Z = A.Z - B.Z};
            return C;
        }

        public static Point3D operator *(Point3D A, Point3D B)
        {
            Point3D C = new Point3D {X = A.X * B.X, Y = A.Y * B.Y, Z = A.Z * B.Z};
            return C;
        }

        public static Point3D operator *(Point3D A, double b)
        {
            return b * A;
        }

        public static Point3D operator *(double b, Point3D A)
        {
            Point3D C = new Point3D {X = b * A.X, Y = b * A.Y, Z = b * A.Z};
            return C;
        }

        public static Point3D operator /(Point3D A, double b)
        {
            Point3D C = A;
            C.X /= b;
            C.Y /= b;
            C.Z /= b;
            return C;
        }

        public static Point3D Swap_213(Point3D A)
        {
            Point3D C = new Point3D {X = A.Y, Y = A.X, Z = A.Z};
            return C;
        }

        public static Point3D Swap_231(Point3D A)
        {
            Point3D C = new Point3D {X = A.Y, Y = A.Z, Z = A.X};
            return C;
        }

        public static Point3D Swap_132(Point3D A)
        {
            Point3D C = new Point3D {X = A.X, Y = A.Z, Z = A.Y};
            return C;
        }

        public static Point3D Swap_312(Point3D A)
        {
            Point3D C = new Point3D {X = A.Z, Y = A.X, Z = A.Y};
            return C;
        }

        public static Point3D Swap_321(Point3D A)
        {
            Point3D C = new Point3D {X = A.Z, Y = A.Y, Z = A.X};
            return C;
        }

        public static Point3D MirrorX(Point3D A)
        {
            Point3D C = new Point3D();
            C = A;
            C.X = -C.X;
            return C;
        }

        public static Point3D MirrorY(Point3D A)
        {
            Point3D C = new Point3D();
            C = A;
            C.Y = -C.Y;
            return C;
        }

        public static Point3D Mirror(Point3D A)
        {
            Point3D C = new Point3D();
            C = A;
            C.X = -C.X;
            C.Y = -C.Y;
            C.Z = -C.Z;
            return C;
        }

        public static Point3D MirrorZ(Point3D A)
        {
            Point3D C = new Point3D();
            C = A;
            C.Z = -C.Z;
            return C;
        }
    }

    public struct Matrix3D
    {
        public Point3D Xrow;
        public Point3D Yrow;
        public Point3D Zrow;

        public Matrix3D(Point3D x, Point3D y, Point3D z)
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
        private static readonly Point3D Origin = new Point3D {X = 0, Y = 0, Z = 0};

        public static double GetDistance(Point3D pointA, Point3D pointB)
        {
            Point3D delta = pointB - pointA;
            return Math.Sqrt(delta.X * delta.X + delta.Y * delta.Y + delta.Z * delta.Z);
        }

        public static double GetMagnitude(Point3D pointA)
        {
            return GetDistance(Origin, pointA);
        }

        public static Point3D GetUnitVector(Point3D point)
        {
            return GetUnitVector(Origin, point);
        }

        public static Point3D GetUnitVector(Point3D startPoint, Point3D endPoint)
        {
            double distance = GetDistance(startPoint, endPoint);
            if (distance == 0)
            {
                return Origin;
            }
            Point3D delta = endPoint - startPoint;
            Point3D unitVector = new Point3D(delta.X / distance, delta.Y / distance, delta.Z / distance);
            return unitVector;
        }

        public static double DotProduct(Point3D pointA, Point3D pointB)
        {
            Point3D pointC = pointA * pointB;
            return pointC.X + pointC.Y + pointC.Z;
        }

        public static Point3D CrossProduct(Point3D pointA, Point3D pointB)
        {
            Point3D pointC = new Point3D
            {
                X = pointA.Y * pointB.Z - pointA.Z * pointB.Y,
                Y = pointA.Z * pointB.X - pointA.X * pointB.Z,
                Z = pointA.X * pointB.Y - pointA.Y * pointB.X
            };
            return pointC;
        }

        public static Matrix3D GetRotationMatrix(Point3D basisVector, Point3D newVector)
        {
            var rowX = new Point3D
            {
                X = DotProduct(basisVector, newVector),
                Y = -1 * GetMagnitude(CrossProduct(basisVector, newVector)),
                Z = 0
            };

            var rowY = new Point3D
            {
                X = GetMagnitude(CrossProduct(basisVector, newVector)),
                Y = DotProduct(basisVector, newVector),
                Z = 0
            };

            var rowZ = new Point3D {X = 0, Y = 0, Z = 1};

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
