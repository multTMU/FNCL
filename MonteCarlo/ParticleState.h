#pragma once
#define DOUBLE_EPSILON 0.0001
namespace MonteCarlo
{
    struct Point3D
    {
        double X;
        double Y;
        double Z;
        Point3D();
        Point3D(double x, double y, double z);

        void MakeUnitVector();
        bool operator == (const Point3D& rhs) const;
        void operator += (const Point3D & rhs);
        double Magnitude() const;
    };
    Point3D operator + (const Point3D& lhs ,const Point3D& rhs);
    Point3D operator - (const Point3D& lhs, const Point3D& rhs);
    Point3D operator * (const double& scalar, const Point3D& rhs);   
}
