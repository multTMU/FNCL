#include "pch.h"
#include "RandomNumberHelper.h"
#include "Geometry.h"

namespace MonteCarlo
{
    RandomNumberHelper* RandomNumberHelper::randomNumberHelper = nullptr;

    int RandomNumberHelper::getInt(int low, int high) const
    {
        return (int)getNumber((double)low, (double)high);
    }

    double RandomNumberHelper::getNumber(double low, double high) const
    {
        return (high - low) * getRand() + low;
    }

    RandomNumberHelper* RandomNumberHelper::GetInstance(const int& randomSeed)
    {
        if (randomNumberHelper == nullptr) {
           
                randomNumberHelper = new RandomNumberHelper(randomSeed);
            
        }
        return randomNumberHelper;
    }

     double RandomNumberHelper::getRand() const
    {
#if _DEBUG
         double randNumber = (double)rand() / RAND_MAX;
         return randNumber;
#endif
         return (double)rand() / RAND_MAX;        

    }

    Point3D RandomNumberHelper::getUnitSpherePoint(double theta, double cosine) const
    {
        double sine = sqrt(1 - cosine * cosine);
        return Point3D(sine * cos(theta), sine * sin(theta), cosine);
    }

    double RandomNumberHelper::getCosine() const
     {
        return 2.0f * getRand() - 1.0f;
     }

    double RandomNumberHelper::getRadius(double radius) const
    {
        return sqrt(getRand()) * radius;
    }

    double RandomNumberHelper::getUniform(double maximum) const
    {
        return getNumber(0.0, maximum);
    }

    double RandomNumberHelper::getMeanFreePath() const
    {
        return -1.0 * log(getRand());
    }

    Point3D RandomNumberHelper::getOnUnitSphere() const
    {
        double theta = getUniform(2.0 * PI);
        double cosine = getCosine();
        double sine = sqrt(1 - cosine * cosine);
        return Point3D(sine * cos(theta), sine * sin(theta), cosine);
    }
}
