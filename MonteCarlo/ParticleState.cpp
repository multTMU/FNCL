#include "pch.h"
#include "ParticleState.h"

#include <cmath>

namespace MonteCarlo
{
    Point3D::Point3D()
    {
        Point3D(0, 0, 0);
    }

    Point3D::Point3D(double x, double y, double z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    bool Point3D::operator==(const Point3D& rhs) const
    {
        return  (abs(X - rhs.X) < DOUBLE_EPSILON) &&
            (abs(Y - rhs.Y) < DOUBLE_EPSILON) &&
            (abs(Z - rhs.Z) < DOUBLE_EPSILON);
    }

    void Point3D::operator+=(const Point3D& rhs)
    {
        X += rhs.X;
        Y += rhs.Y;
        Z += rhs.Z;
    }

    double Point3D::Magnitude() const
    {
        return sqrt(X * X + Y * Y + Z * Z);
    }

    void Point3D::MakeUnitVector()
    {
        const double scale = Magnitude();
        if(scale > 0)
        {
            X /= scale;
            Y /= scale;
            Z /= scale;            
        }        
    }
    Point3D operator+(const Point3D& lhs, const Point3D& rhs)
    {
        return Point3D(lhs.X + rhs.X, lhs.Y + rhs.Y, lhs.Z + rhs.Z);
    }

    Point3D operator-(const Point3D& lhs, const Point3D& rhs)
    {
        return lhs + (-1.0 * rhs);
    }

    Point3D operator*(const double& scalar, const Point3D& rhs)
    {
        return Point3D(scalar * rhs.X, scalar * rhs.Y, scalar * rhs.Z);
    }
}
