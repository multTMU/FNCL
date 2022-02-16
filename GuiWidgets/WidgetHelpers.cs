using System;
using GuiInterface;

namespace GuiWidgets
{
    public delegate Toutput CustomValidator<Tinput, Toutput>(Tinput testValue);

    public static class CustomValidatorHelper
    {
        public static double GetDistanceToCm(string testValue)
        {
            testValue = TestForFlag(testValue, "i", out bool containsInch);
            testValue = TestForFlag(testValue, "f", out bool containsFeet);
            testValue = TestForFlag(testValue, "m", out bool containsMeters);
            double value = MultiplicityInterfaceHelper.ValidateDouble(testValue);

            if (containsFeet)
            {
                return 2.54 * 12.0 * value;
            }

            if (containsInch)
            {
                return 2.54 * value;
            }

            if (containsMeters)
            {
                return 100.0 * value;
            }

            return value;
        }

        public static double ConvertTimeToNanoSeconds(string testValue)
        {
            testValue = TestForFlag(testValue, "m", out bool convertFromMili);
            testValue = TestForFlag(testValue, "u", out bool convertFromMicro);
            testValue = TestForFlag(testValue, "s", out bool convertFromSeconds);

            double value = MultiplicityInterfaceHelper.ValidateDouble(testValue);
            if (convertFromMili)
            {
                return (1e6) * value;
            }

            if (convertFromMicro)
            {
                return (1e3) * value;
            }

            if (convertFromSeconds)
            {
                return (1e9) * value;
            }

            return value;
        }

        private static string TestForFlag(string testValue, string Flag, out bool convert)
        {
            if (testValue.Contains(Flag))
            {
                convert = true;
                testValue = testValue.Replace(Flag, "");
            }
            else
            {
                convert = false;
            }

            return testValue;
        }
        
        public static double ConvertBetweenRadiansAndDegree(string testValue)
        {
            testValue = TestForFlag(testValue, "r", out bool convertToDegrees);
            testValue = TestForFlag(testValue, "d", out bool convertToRadians);

            double value = MultiplicityInterfaceHelper.ValidateDouble(testValue);
            if (convertToDegrees)
            {
                return MathNet.Numerics.Trig.RadianToDegree(value);
            }

            if (convertToRadians)
            {
                return MathNet.Numerics.Trig.DegreeToRadian(value);
            }

            return value;
        }


        public static double ConvertCuriesToBq(string testValue)
        {
            testValue = TestForFlag(testValue.ToLower(), "c", out bool containsCurie);
            double value = MultiplicityInterfaceHelper.ValidateDouble(testValue);
            return (containsCurie) ? (3.7e10) * value : value;
        }
    }


    interface IMPPostDetector<T>
    {
        void Set(T specs);
        T Get();
    }

    public interface IGuiInputs<Tinput, Toutput>
    {
        void SetReadonly();
        void SetNotReadonly();
        void SetValueRaiseNoEvent(Toutput valueNew);
        void SetValueRaiseEvent(Toutput valueNew);
        void SetLabel(string labelNew);
        Toutput GetValue();
        void SetCustomValidator(CustomValidator<Tinput, Toutput> customValidator);
    }

    interface IWaveformWidget : IPileUpRejectResults, IPsdWaveformResults
    {
        event EventHandler Recalculate;
    }

    interface IPsdWaveformResults
    {
        void SetResults(double psd, double amplitude, string particle);
    }

    interface IPileUpRejectResults
    {
        void SetIsPileUp(bool isPileUp);
        void SetRejector(double scalar, double interval);
        double GetScalar();
        double GetInterval();
    }
}
