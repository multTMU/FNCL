using System;
using System.Collections.Generic;

namespace GlobalHelpersDefaults
{
    public enum PoliMiOrganicNeutronEnergyCal
    {
        // these numbers map to the MPPost input file, there are other Ecals for photons, and neutrons off Carbon and Deuteron.
        None = -1,
        NotPoliMiLinear = 0,
        Quadratic = 1,
        Rational = 2,
        Transcendental = 3,
        FourthOrder = 4
    }

    public interface IEnergyCalibration
    {
        PoliMiOrganicNeutronEnergyCal GetPoliMiCalType();
        double GetPulseInKeVee(double pulseADC);
        List<double> GetParameters();
        void SetParameters(List<double> eCalParams);
        int NumberOfParameters();
        void ConvertToKeVeeFromMeVee(bool convert);
        bool GetConvertToKeVeeFromMeVee();
        string ToFile();
    }

    public abstract class EnergyCalibration : IEnergyCalibration
    {
        private bool convertToKeVee;
        private readonly int nParameters;

        protected EnergyCalibration(int NumberParameters, bool ConvertToKeVee, List<double> Parameters) : this(
            ConvertToKeVee, NumberParameters)
        {
            MapParameters(Parameters);
        }

        protected EnergyCalibration(bool ConvertFromMeVeeToKeVee, int NumberParameters)
        {
            convertToKeVee = ConvertFromMeVeeToKeVee;
            nParameters = NumberParameters;
        }

        public abstract PoliMiOrganicNeutronEnergyCal GetPoliMiCalType();

        public double GetPulseInKeVee(double pulseADC)
        {
            double energy = GetEnergy(pulseADC);
            if (convertToKeVee)
            {
                return energy * 1000.0;
            }

            return energy;
        }

        public List<double> GetParameters()
        {
            return GetListOfParameters();
        }

        protected abstract List<double> GetListOfParameters();

        public void SetParameters(List<double> eCalParams)
        {
            if (eCalParams.Count == nParameters)
            {
                MapParameters(eCalParams);
            }
            else
            {
                ThrowInvalidParamSize(eCalParams.Count);
            }
        }

        private void ThrowInvalidParamSize(int nGot)
        {
            throw new Exception("Wrong number of ECal parameters for " + GetPoliMiCalType().ToString() + " need " +
                                NumberOfParameters() + " got " + nGot);
        }

        protected abstract void MapParameters(List<double> eCalParams);

        public int NumberOfParameters()
        {
            return nParameters;
        }

        protected abstract double GetEnergy(double pulseADC);

        public void ConvertToKeVeeFromMeVee(bool convert)
        {
            convertToKeVee = convert;
        }

        public bool GetConvertToKeVeeFromMeVee()
        {
            return convertToKeVee;
        }

        public string ToFile()
        {
            return EnergyCalibrationHelper.GetStringToWriteToFile(this);
        }
    }

    public class Channels : EnergyCalibration
    {
        public Channels() : base(false, 0)
        {
        }

        public override PoliMiOrganicNeutronEnergyCal GetPoliMiCalType()
        {
            return PoliMiOrganicNeutronEnergyCal.None;
        }

        protected override List<double> GetListOfParameters()
        {
            return new List<double>();
        }

        protected override void MapParameters(List<double> eCalParams)
        {
            // Do Nothing
        }

        protected override double GetEnergy(double pulseADC)
        {
            return pulseADC;
        }
    }

    public class LinearEnergyCalibration : EnergyCalibration
    {
        private double slope;
        private double intercept;
        private const int NPARAMS = 3;

        public LinearEnergyCalibration(bool ConvertToKeVee, List<double> Parameters) : base(NPARAMS, ConvertToKeVee,
            Parameters)
        {
        }

        public LinearEnergyCalibration(double Slope, double Intercept, bool ConvertToKeVee) : base(ConvertToKeVee,
            NPARAMS)
        {
            slope = Slope;
            intercept = Intercept;
        }

        public override PoliMiOrganicNeutronEnergyCal GetPoliMiCalType()
        {
            return PoliMiOrganicNeutronEnergyCal.NotPoliMiLinear;
        }

        protected override List<double> GetListOfParameters()
        {
            List<double> eCal = new List<double>();
            eCal.Add(intercept);
            eCal.Add(slope);
            return eCal;
        }

        protected override void MapParameters(List<double> eCalParams)
        {
            intercept = eCalParams[0];
            slope = eCalParams[1];
        }

        protected override double GetEnergy(double pulseADC)
        {
            return slope * pulseADC + intercept;
        }
    }

    public class QuadraticEnergyCalibration : EnergyCalibration
    {
        private double coeff2;
        private double coeff1;
        private double coeff0;
        private const int NPARAMS = 3;

        public QuadraticEnergyCalibration(bool ConvertToKeVee, List<double> Parameters) : base(NPARAMS, ConvertToKeVee,
            Parameters)
        {
        }

        public QuadraticEnergyCalibration(double Coeff0, double Coeff1, double Coeff2, bool ConvertToKeVee) : base(
            ConvertToKeVee, 3)
        {
            coeff0 = Coeff0;
            coeff1 = Coeff1;
            coeff2 = Coeff2;
        }

        public override PoliMiOrganicNeutronEnergyCal GetPoliMiCalType()
        {
            return PoliMiOrganicNeutronEnergyCal.Quadratic;
        }

        protected override List<double> GetListOfParameters()
        {
            List<double> eCal = new List<double>();
            eCal.Add(coeff0);
            eCal.Add(coeff1);
            eCal.Add(coeff2);
            return eCal;
        }

        protected override void MapParameters(List<double> eCalParams)
        {
            coeff0 = eCalParams[0];
            coeff1 = eCalParams[1];
            coeff2 = eCalParams[2];
        }

        protected override double GetEnergy(double pulseADC)
        {
            return coeff0 + coeff1 * pulseADC + coeff2 * pulseADC * pulseADC;
        }
    }

    public class RationalEnergyCalibration : EnergyCalibration
    {
        private double numerator;
        private double demoninator;
        private const int NPARAMS = 2;

        public RationalEnergyCalibration(bool ConvertToKeVee, List<double> Parameters) : base(NPARAMS, ConvertToKeVee,
            Parameters)
        {
        }

        public RationalEnergyCalibration(double Numerator, double Denominator, bool ConvertToKeVee) : base(
            ConvertToKeVee, 2)
        {
            numerator = Numerator;
            demoninator = Denominator;
        }

        public override PoliMiOrganicNeutronEnergyCal GetPoliMiCalType()
        {
            return PoliMiOrganicNeutronEnergyCal.Rational;
        }

        protected override List<double> GetListOfParameters()
        {
            List<double> eCal = new List<double>();
            eCal.Add(numerator);
            eCal.Add(demoninator);
            return eCal;
        }

        protected override void MapParameters(List<double> eCalParams)
        {
            numerator = eCalParams[0];
            demoninator = eCalParams[1];
        }

        protected override double GetEnergy(double pulseADC)
        {
            return (numerator * (pulseADC * pulseADC)) / (pulseADC + demoninator);
        }
    }

    public class TranscendentalEnergyCalibration : EnergyCalibration
    {
        private double amplitude;
        private double linear;
        private double expLinear;
        private double expScalar;
        private double expPower;
        private const int NPARAMS = 5;

        public TranscendentalEnergyCalibration(bool ConvertToKeVee, List<double> Parameters) : base(NPARAMS,
            ConvertToKeVee,
            Parameters)
        {
        }

        public TranscendentalEnergyCalibration(double Amplitude, double Linear, double ExpLinear, double ExpScalar,
            double ExpPower, bool ConvertToKeVee) : base(ConvertToKeVee, 5)
        {
            amplitude = Amplitude;
            linear = Linear;
            expLinear = ExpLinear;
            expScalar = ExpScalar;
            expPower = ExpPower;
        }

        public override PoliMiOrganicNeutronEnergyCal GetPoliMiCalType()
        {
            return PoliMiOrganicNeutronEnergyCal.Transcendental;
        }

        protected override List<double> GetListOfParameters()
        {
            List<double> eCal = new List<double>();
            eCal.Add(amplitude);
            eCal.Add(linear);
            eCal.Add(expLinear);
            eCal.Add(expScalar);
            eCal.Add(expPower);
            return eCal;
        }

        protected override void MapParameters(List<double> eCalParams)
        {
            amplitude = eCalParams[0];
            linear = eCalParams[1];
            expLinear = eCalParams[2];
            expScalar = eCalParams[3];
            expPower = eCalParams[4];
        }

        protected override double GetEnergy(double pulseADC)
        {
            return amplitude *
                   (linear * pulseADC - expLinear * (1.0 - Math.Exp(expScalar * Math.Pow(pulseADC, expPower))));
        }
    }
}
