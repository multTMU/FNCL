#pragma once
#include "ParticleState.h"
#define SPEED_OF_LIGHT 1.0f
#define MASS_NEUTRON 1.0f
namespace MonteCarlo
{
    enum ParticleType { Undefined, Photon, Neutron };

    class Particle
    {
    public:
        Particle() = default;
        Particle(double EnergyKeV, Point3D& Position, Point3D& Direction);
        virtual  ParticleType ParticleType() const = 0;

        Point3D Position() const;// { return position; }
        double EnergyKeV() const;// { return energyKeV; }
        Point3D Direction() const;// { return direction; }
        double LifeTime() const;// { return lifeTime; }

        void StreamDistance(const double distance);

    protected:
        double lifeTime;
        Point3D position;
        Point3D direction;
        double energyKeV;
        virtual double getSpeed() const = 0;

    private:

        void updateLifeTime(const double distance);
    };

    class PhotonParticle :public Particle
    {
    public:
        PhotonParticle(double Energy, Point3D& Position, Point3D& Direction)
            : Particle(Energy, Position, Direction) {};

        MonteCarlo::ParticleType ParticleType() const override { return ParticleType::Photon; }

    protected:
        double getSpeed() const override;
    };

    class NeutronParticle :public Particle
    {
    public:
        NeutronParticle(double Energy, Point3D& Position, Point3D& Direction)
            : Particle(Energy, Position, Direction) {};

        MonteCarlo::ParticleType ParticleType() const override { return ParticleType::Neutron; }
    protected:
        double getSpeed() const override;
    };

}

