#pragma once
#include <cstdlib>

namespace MonteCarlo
{
    class RandomNumberHelper
    {
    protected:
        RandomNumberHelper(const int randomSeed) : seed(randomSeed)
        {
            srand(randomSeed);
        }

        static RandomNumberHelper* randomNumberHelper;

        int seed;

    public:

        RandomNumberHelper(RandomNumberHelper& other) = delete;

        void operator=(const RandomNumberHelper&) = delete;

        int getInt(int low, int high) const;
        double getNumber(double low, double high) const;
        double getCosine() const;
        double getRadial(double radius) const;
        double getUniform(double maximum) const;
        double getMeanFreePath() const;
        static RandomNumberHelper* GetInstance(const int& randomSeed);
       
    private:

        double getRand() const;

    };


   
}

