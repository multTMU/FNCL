#include "pch.h"
#include "RandomNumberHelper.h"
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

    RandomNumberHelper* RandomNumberHelper::GetInstance(const int& value)
    {
        if (randomNumberHelper == nullptr) {
            randomNumberHelper = new RandomNumberHelper(value);
        }
        return randomNumberHelper;
    }

     double RandomNumberHelper::getRand() const
    {
         return (double)rand() / RAND_MAX;
    }

    double RandomNumberHelper::getCosine() const
     {
        return 2.0f * getRand() - 1.0f;
     }

    double RandomNumberHelper::getRadial(double radius) const
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
}
