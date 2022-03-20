#pragma once
#include <cstdlib>
#include <ctime>


#include "ParticleState.h"

namespace MonteCarlo
{
    class RandomNumberHelper
    {
    protected:
        RandomNumberHelper(int randomSeed) 
        {
            if(randomSeed == DEFAULT_SEED)
            {
                randomSeed = static_cast<int>(time(0));
            }
            srand(randomSeed);
        }

        static RandomNumberHelper* randomNumberHelper;
        int static const DEFAULT_SEED = 0;

    public:

        RandomNumberHelper(RandomNumberHelper& other) = delete;

        void operator=(const RandomNumberHelper&) = delete;

        int getInt(int low, int high) const;
        double getNumber(double low, double high) const;
        double getCosine() const;
        double getRadius(double radius) const;
        double getUniform(double maximum) const;
        double getMeanFreePath() const;
        Point3D getOnUnitSphere()const;
        static RandomNumberHelper* GetInstance(const int& randomSeed = DEFAULT_SEED);
       
    private:        
        double getRand() const;
        Point3D getUnitSpherePoint(double theta, double cosine) const;
    };   
}

