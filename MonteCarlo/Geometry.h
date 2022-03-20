#pragma once
# define PI 3.14159
# define MAX_BISECT_ITERATIONS 10

#include "ParticleState.h"
#include "RandomNumberHelper.h"

namespace MonteCarlo
{
    class Geometry
    {
    public:
        virtual Point3D getRandomPoint() = 0;
        virtual bool pointIsWithin(const Point3D testPoint) = 0;
        virtual double distanceToBoundary(const Point3D position, const Point3D direction) = 0;
    protected:
        RandomNumberHelper* randomHelper;

        class Bisector
        {
        public:
            
            Bisector(double MinDistance, double MaxDistance, const Point3D Position, const Point3D Direction, 
                int MaxIterations = MAX_BISECT_ITERATIONS);            
            double getDistance(bool pointInside(const Point3D));

        private:
            double minDistance;
            double maxDistance;
            Point3D position;
            Point3D direction;
            int maxIterations;
            int currentIteration;
            double low;
            double high;

            bool stopCriteriaNotMeet();
            bool solutionFound(double midPoint);
        };
    };

    class Sphere :Geometry
    {
    public:
        Sphere(const Point3D& Center, const double Radius);
        Point3D getRandomPoint() override;
        bool pointIsWithin(const Point3D testPoint) override;
        double distanceToBoundary(const Point3D position, const Point3D direction) override;
    private:
        double radius;
        Point3D center;

    };
}
