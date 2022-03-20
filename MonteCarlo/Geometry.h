#pragma once
# define PI 3.14159
# define MAX_BISECT_ITERATIONS 10

#include "ParticleState.h"
#include "RandomNumberHelper.h"

namespace MonteCarlo
{
    enum GeometryTypes{Spherical, Box};

    //TODO better name, Center isn't really an extent
    struct Extents
    {
        virtual double getVolume() const = 0;
        Point3D Center;
        virtual double maximumDistance() const = 0;
        virtual  GeometryTypes getGeometryType() const = 0;
    };

    struct  SphereExtents : Extents
    {
        double getVolume() const override { return PI * Radius * Radius; }
        double maximumDistance() const override { return 2.0 * Radius; }
        GeometryTypes getGeometryType() const override { return Spherical; }
        double Radius;
    };

    struct OrthogonalBoxExtents :Extents
    {
        double getVolume() const override { return SideLengths.X * SideLengths.Y * SideLengths.Z; }
        double maximumDistance() const override { return SideLengths.Magnitude(); }
        GeometryTypes getGeometryType() const override { return Box; }
        Point3D SideLengths;
    };

    template <class TExtents>
    class Geometry
    {
    public:
        Geometry(TExtents& Extents)
        {
            extents = Extents;
        }
        double getVolume() const { return extents.getVolume(); }
        virtual Point3D getRandomPoint() = 0;
        virtual bool pointIsWithin(Point3D testPoint) const = 0;
        double distanceToBoundary(Point3D position, Point3D direction);
    protected:
        RandomNumberHelper* randomHelper;
        TExtents extents;
        class Bisector
        {
        public:

            Bisector(double MinDistance, double MaxDistance, Point3D Position, Point3D Direction,
                int MaxIterations = MAX_BISECT_ITERATIONS);

            double getDistance(const Geometry<TExtents>* geometry);

        private:
            double minDistance;
            double maxDistance;
            Point3D position;
            Point3D direction;
            int maxIterations;
            int currentIteration;
            double low;
            double high;

            bool solutionFound(double midPoint) const;
            Point3D getNewTestPoint(double distance) const;
        };
    };

    class Sphere : public Geometry<SphereExtents>
    {
    public:
        Sphere(SphereExtents& sphereExtents) :Geometry(sphereExtents) {};
        Point3D getRandomPoint() override;
        bool pointIsWithin(Point3D testPoint) const override;
    };

    class OrthogonalBox : public Geometry<OrthogonalBoxExtents>
    {
    public:
        OrthogonalBox(OrthogonalBoxExtents& boxExtents) :Geometry(boxExtents) {};
        Point3D getRandomPoint() override;
        bool pointIsWithin(Point3D testPoint) const override;
    private:
        static bool dimensionBounded(double dimension, double dimensionLength);
    };

    template <class TExtents>
    Geometry<TExtents>* GeometryFactory(Extents& extents)
    {
        switch(extents.getGeometryType())
        {
        case Spherical:
            return new Sphere(dynamic_cast<SphereExtents&>(extents));
        case Box:
            return new OrthogonalBox(dynamic_cast<OrthogonalBoxExtents&>(extents));
        }
    }
}
