#include "pch.h"
#include "Geometry.h"

namespace MonteCarlo
{
    template <class TExtents>
    Geometry<TExtents>::Bisector::Bisector(double MinDistance, double MaxDistance, const Point3D Position,
        const Point3D Direction, int MaxIterations)
    {
        minDistance = MinDistance;
        maxDistance = MaxDistance;
        position = Position;
        direction = Direction;
        maxIterations = MaxIterations;
    }

    template <class TExtents>
    double Geometry<TExtents>::Bisector::getDistance(const Geometry* geometry)
    {
        //TODO this is too long, refactor
        double distance = 0;
        low = minDistance;
        high = maxDistance;

        currentIteration = 0;

        while (currentIteration < maxIterations)
        {
            currentIteration++;
            distance = (low + high) / 2.0;
            if (solutionFound(distance))
            {
                return distance;
            }
            
            if (geometry->pointIsWithin(getNewTestPoint(distance)))
            {
                low = distance;
            }
            else
            {
                high = distance;
            }
        }

        return distance;
    }

    template <class TExtents>
    Point3D Geometry<TExtents>::Bisector::getNewTestPoint(double distance) const
    {
        return position + distance * direction;
    }

    template <class TExtents>
    bool Geometry<TExtents>::Bisector::solutionFound(double midPoint) const
    {
        if(currentIteration > maxIterations)
        {
            return true;
        }
        return  ((high - low) / 2.0) < DOUBLE_EPSILON;
    }

    Point3D Sphere::getRandomPoint()
    {
        double r = randomHelper->getRadius(extents.Radius);
        return extents.Center + r * randomHelper->getOnUnitSphere();
    }

    bool Sphere::pointIsWithin(const Point3D testPoint) const
    {
        const Point3D point = testPoint - extents.Center;
        return point.Magnitude() <= extents.Radius;
    }

    template <class TExtents>
    double Geometry<TExtents>::distanceToBoundary(Point3D position, Point3D direction)
    {
        Bisector bisector(0.0, extents.maximumDistance(), position, direction);
        return bisector.getDistance(this);
    }

    Point3D OrthogonalBox::getRandomPoint()
    {
        Point3D point(randomHelper->getUniform(extents.SideLengths.X),
            randomHelper->getUniform(extents.SideLengths.Y),
            randomHelper->getUniform(extents.SideLengths.Z));
        point.X -= extents.SideLengths.X / 2.0;
        point.Y -= extents.SideLengths.Y / 2.0;
        point.Z -= extents.SideLengths.Z / 2.0;
        return extents.Center + point;
    }

    bool OrthogonalBox::pointIsWithin(Point3D testPoint) const
    {
        Point3D point = testPoint - extents.Center;
        point.X += extents.SideLengths.X / 2.0;
        point.Y += extents.SideLengths.Y / 2.0;
        point.Z += extents.SideLengths.Z / 2.0;
        return dimensionBounded(point.X, extents.SideLengths.X)
            && dimensionBounded(point.Y, extents.SideLengths.Y)
            && dimensionBounded(point.Z, extents.SideLengths.Z);
    }

    bool OrthogonalBox::dimensionBounded(double dimension, double dimensionLength)
    {
        return ( dimension >= 0 )&& (dimension <= dimensionLength);
    }
}
