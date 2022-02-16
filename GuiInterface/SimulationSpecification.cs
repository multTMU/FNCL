using System;
using System.Collections.Generic;
using FastNeutronCollar;
using GlobalHelpers;
using PoliMiRunner;
using Runner;

namespace GuiInterface
{
    public interface IModelRunner
    {
        void SetProblems(List<SimulationSpecification> simulationSpecifications);
        void SetConfig(ProblemConfig Config);
        void Run();
    }

    public static class PoliMiRunnerGuiHelper
    {
        public static IModelRunner GetModelRunnerPassiveNonFuel(ModelTypes model)
        {
            return GetModelRunner(model, false);
        }

        private static IModelRunner GetModelRunner(ModelTypes model, bool Active)
        {
            switch (model)
            {
                case ModelTypes.Undefined:
                    throw new Exception("Undefined Model");
                case ModelTypes.AmLi:
                    return new AmLiRunner(Active);
                case ModelTypes.AmLiSel:
                    return new AmLiSelRunner(Active);
                case ModelTypes.MP320:
                    return new MP320Runner(Active);
                case ModelTypes.MP320Sel:
                    return new MP320SelRunner(Active);
                case ModelTypes.Starfire:
                    return new StarFireNGen350(Active);
                case ModelTypes.StarfireSel:
                    throw new NotImplementedException("Starfire SEL");
                case ModelTypes.NGamArray12:
                    return new NGammaArray12Runner();
                default:
                    throw new ArgumentOutOfRangeException(nameof(model), model, null);
            }
        }

        public static IModelRunner GetFnclRunnerPassiveFuel(ModelTypes model)
        {
            return GetModelRunner(model, false);
        }

        public static IModelRunner GetFnclRunnerActiveNonFuel(ModelTypes model)
        {
            return GetModelRunner(model, true);
        }

        public static IModelRunner GetFnclRunnerActiveFuel(ModelTypes model)
        {
            return GetModelRunner(model, true);
        }
    }

    public abstract class DetectorRunnerGui : IModelRunner
    {
        protected ProblemConfig config;
        protected List<SimulationSpecification> simSpecs;
        protected bool active;

        protected DetectorRunnerGui(bool Active)
        {
            active = Active;
        }

        public void SetProblems(List<SimulationSpecification> simulationSpecifications)
        {
            simSpecs = simulationSpecifications;
        }

        protected IComponentSpecification GetSource(SimulationSpecification sim)
        {
            return SourceModelHelper.GetSourceModel(sim);
        }

        public void SetConfig(ProblemConfig Config)
        {
            config = Config;
        }

        public void Run()
        {
            ModelRunner runner = InitializeRunner();
            foreach (var s in simSpecs)
            {
                runner.SetUpFromGenericSpecifications(s);

                if (s.SourceType == Sources.Fuel)
                {
                    runner.DisplaceHeightFromCenter(s.FuelHeightDisplacement);
                }

                runner.AddSourceModel(GetSource(s));
                runner.MakeMCNPfiles(s.McnpInputDirectory, s.NPS, s.TrackParticle, s.Activity);
            }

            runner.RunPoliMiandMPPost();
        }

        protected abstract ModelRunner InitializeRunner();
    }

    public static class SourceModelHelper
    {
        public static IComponentSpecification GetSourceModel(SimulationSpecification sim)
        {
            switch (sim.SourceType)
            {
                case Sources.Point:
                    return GetPoint(sim);
                case Sources.Sphere:
                    return GetSphere(sim);
                case Sources.HollowCylinder:
                    return GetHollowCylinder(sim);
                case Sources.Cylinder:
                    return GetCylinder(sim);
                case Sources.Fuel:
                    return GetFuel(sim);
                case Sources.NblStandard:
                    return GetNbl(sim);
                case Sources.PolySphere:
                    return GetPolyBall(sim);
                case Sources.PointSourceInSphericalShell:
                    return GetPointSourceInSphericalShell(sim);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static IComponentSpecification GetPointSourceInSphericalShell(SimulationSpecification sim)
        {
            return new NonEmbeddedSources.PointSourceInSphericalShell(sim.Center, sim.InnerRadius, sim.OutRadius,
                sim.SourcePoliMi,
                sim.Material, sim.ActiveProblem);
        }

        private static IComponentSpecification GetPolyBall(SimulationSpecification sim)
        {
            return new NonEmbeddedSources.PolyBall(sim.Center, sim.InnerRadius, sim.OutRadius, sim.SourcePoliMi,
                sim.Material, sim.ActiveProblem);
        }

        private static IComponentSpecification GetNbl(SimulationSpecification sim)
        {
            return new NonEmbeddedSources.NblStandard(sim.Center, sim.Axis, sim.Material, sim.Height, sim.SourcePoliMi);
        }

        private static IComponentSpecification GetFuel(SimulationSpecification sim)
        {
            return new FuelAssemblyComponent(sim.FuelFile, !sim.ActiveProblem);
        }

        private static IComponentSpecification GetCylinder(SimulationSpecification sim)
        {
            return new NonEmbeddedSources.CylinderSource(sim.Center, sim.Axis, sim.Radius, sim.Height,
                sim.ActiveProblem, sim.SourcePoliMi);
        }

        private static IComponentSpecification GetHollowCylinder(SimulationSpecification sim)
        {
            return new NonEmbeddedSources.HollowCylinder(sim);
        }

        private static IComponentSpecification GetSphere(SimulationSpecification sim)
        {
            return new NonEmbeddedSources.Sphere(sim.Center, sim.Radius, sim.Material, sim.SourcePoliMi,
                !sim.ActiveProblem);
        }

        private static IComponentSpecification GetPoint(SimulationSpecification sim)
        {
            return new NonEmbeddedSources.PointSource(sim.Center, sim.SourcePoliMi);
        }
    }

    public class MP320SelRunner : MP320Runner
    {
        public MP320SelRunner(bool Active) : base(Active)
        {
        }
    }

    public class NGammaArray12Runner : DetectorRunnerGui
    {
        private RunNGammaDetector runner;

        public NGammaArray12Runner() : base(false)
        {
        }

        protected override ModelRunner InitializeRunner()
        {
            runner = new RunNGammaDetector(config);
            return runner;
        }
    }

    public class StarFireNGen350 : DetectorRunnerGui
    {
        private nGen350Fncl runner;

        public StarFireNGen350(bool Active) : base(Active)
        {
        }

        protected override ModelRunner InitializeRunner()
        {
            runner = new nGen350Fncl(config, active);
            return runner;
        }
    }

    public class MP320Runner : DetectorRunnerGui
    {
        private Mp320Fncl runner;

        public MP320Runner(bool Active) : base(Active)
        {
        }

        protected override ModelRunner InitializeRunner()
        {
            runner = new Mp320Fncl(config, active);
            return runner;
        }
    }

    public class AmLiSelRunner : AmLiRunner
    {
        protected new SelFNCL runner;

        public AmLiSelRunner(bool Active) : base(Active)
        {
        }

        protected override ModelRunner InitializeRunner()
        {
            runner = new SelFNCL(config, active, AmLiBlockTypes.Undefined);
            return runner;
        }
    }

    public class AmLiRunner : DetectorRunnerGui
    {
        private AmLiFNCL runner;

        public AmLiRunner(bool Active) : base(Active)
        {
        }

        protected override ModelRunner InitializeRunner()
        {
            runner = new AmLiFNCL(config, active, AmLiBlockTypes.Undefined);
            return runner;
        }
    }
}
