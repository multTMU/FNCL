#include "pch.h"
#include "Particle.h"

#include <cmath>

namespace MonteCarlo
{
    Particle::Particle(double EnergyKeV, Point3D& Position, Point3D& Direction)
    {
        energyKeV = EnergyKeV;
        position = Position;
        direction = Direction;
        direction.MakeUnitVector();
        lifeTime = 0.0;
    }

    Point3D Particle::Position() const
    {
        return position;
    }

    double Particle::EnergyKeV() const
    {
        return energyKeV;
    }

    Point3D Particle::Direction() const
    {
        return direction;
    }

    double Particle::LifeTime() const
    {
        return lifeTime;
    }

    void Particle::StreamDistance(const double distance)
    {
        position += (distance * direction);
        updateLifeTime(distance);
    }

    void Particle::updateLifeTime(const double distance)
    {
        const double time = (distance / getSpeed());
        lifeTime += time;
    }

    double PhotonParticle::getSpeed() const
    {
        return SPEED_OF_LIGHT;
    }

    double NeutronParticle::getSpeed() const
    {
        return sqrt(2.0 * energyKeV / MASS_NEUTRON);
    }
}
