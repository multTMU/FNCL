#include "pch.h"
#include "CppUnitTest.h"
#include "ParticleState.h"
#include "RandomNumberHelper.h"
#include "../MonteCarlo/Particle.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;
using namespace MonteCarlo;

namespace UnitTestsMonteCarlo
{
	TEST_CLASS(UnitTestsMonteCarlo)
	{
	public:

        Particle& getParticle()
        {
            // todo make initial values vars for testing
            PhotonParticle photon(511.0, Point3D(0.0, 0.0, 0.0), Point3D(2.0, 0.0, 0.0));
            return photon;
        }

        TEST_METHOD(CreateParticle)
        {            
            Particle& particle = getParticle();
            Assert::AreEqual((int)particle.ParticleType(), (int)Photon);
            Assert::AreEqual(511.0, particle.EnergyKeV());
            Assert::IsTrue(particle.Position() == Point3D(0.0, 0.0, 0.0));
            Assert::IsTrue(particle.Direction() == Point3D(2.0, 0.0, 0.0));
        }

        TEST_METHOD(Point3Dmath)
        {
            // Todo break out into own test class, with one test per Test_method
            Point3D A(2, 2, 2);
            A.MakeUnitVector();
            Assert::IsTrue(floatEqual(A.Magnitude() ,1.0));

            Point3D scaled = 5.0 * A;
            Assert::IsTrue(floatEqual(scaled.Magnitude(), 5.0));

            Point3D B(0, 0, 1);
            Point3D C(1, 1, 0);
            Point3D D(1, 1, 1);

            B += C;
            Assert::IsTrue( B == D);

            Point3D E = C + C;

            Assert::IsTrue(floatEqual(E.Magnitude() , (2.0 * C).Magnitude()));
        }

        TEST_METHOD(StreamParticle)
        {
            Particle& particle = getParticle();
            particle.StreamDistance(10.0);
            Assert::IsTrue(particle.Position() == Point3D(10.0, 0, 0));
            Assert::IsTrue(floatEqual(particle.LifeTime(),10.0));

        }


    private:
        static bool floatEqual(const double& a, const double& b)
        {
            return abs(a - b) < DOUBLE_EPSILON;
        }

	};

    TEST_CLASS(UnitTestsRandomNumbers)
    {
    public:
        TEST_METHOD(SeedRand)
        { 
            RandomNumberHelper* randomHelper = RandomNumberHelper::GetInstance(1);
            int randInt = randomHelper->getInt(10, 100);
            Assert::IsTrue( randInt >= 10);
            Assert::IsTrue(randomHelper->getRadial(10.0) <= 10.0);
        }
    };
}
