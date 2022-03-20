#include "pch.h"
#include "Geometry.h"

namespace MonteCarlo
{
    Geometry::Bisector::Bisector(double MinDistance, double MaxDistance, const Point3D Position,
        const Point3D Direction, int MaxIterations)
    {
        minDistance = MinDistance;
        maxDistance = MaxDistance;
        position = Position;
        direction = Direction;
        maxIterations = MaxIterations;
    }    

    double Geometry::Bisector::getDistance(bool pointInside(const Point3D))
    {
        double distance = 0;
        low = minDistance;
        high = maxDistance;

        currentIteration = 0;

        while(stopCriteriaNotMeet())
        {
            currentIteration++;
            distance = (low + high) / 2.0;
            if(solutionFound(distance))
            {
                return distance;
            }
            const Point3D testPoint = position + distance * direction;
            if(pointInside(testPoint))
            {
                low = distance;
            }else
            {
                high = distance;
            }
        }

        return distance;
    }

    bool Geometry::Bisector::solutionFound(double midPoint)
    {
        if(currentIteration > maxIterations)
        {
            return true;
        }
        return  ((high - low) / 2.0) < DOUBLE_EPSILON;
    }

    Sphere::Sphere(const Point3D& Center, const double Radius)
    {
        center = Center;
        radius = Radius;
    }

    Point3D Sphere::getRandomPoint()
    {
        double r = randomHelper->getRadius(radius);
        return center + r * randomHelper->getOnUnitSphere();
    }

    bool Sphere::pointIsWithin(const Point3D testPoint)
    {
        const Point3D point = testPoint - center;
        return point.Magnitude() <= radius;
    }

    double Sphere::distanceToBoundary(const Point3D position, const Point3D direction)
    {
        Bisector bisector(0.0, radius, position, direction);
        return bisector.getDistance()
            ;
    }
}
