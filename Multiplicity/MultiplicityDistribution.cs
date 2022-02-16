using System;
using System.Collections.Generic;
using System.Linq;

namespace Multiplicity
{
    public static class GetMultiplicityDistributions
    {
        public const int UNBOUND_FLAG = 0;

        public static MultiplicityDistribution GetDistribution(int fixedSize = UNBOUND_FLAG)
        {
            if (fixedSize == UNBOUND_FLAG)
            {
                return new MultiplicityDistribution();
            }
            else
            {
                return new FixedSizeMultiplicityDistribution(fixedSize);
            }
        }
    }


    public class MultiplicityDistribution
    {
        public static MultiplicityDistribution operator -(MultiplicityDistribution A, MultiplicityDistribution B)
        {
            return AddOrSubtract(A, B, false);
        }

        public static MultiplicityDistribution operator +(MultiplicityDistribution A, MultiplicityDistribution B)
        {
            return AddOrSubtract(A, B, true);
        }

        private static MultiplicityDistribution AddOrSubtract(MultiplicityDistribution A, MultiplicityDistribution B,
            bool Add)
        {
            MultiplicityDistribution C = new MultiplicityDistribution();
            int maxIndex = Math.Max(A.distribution.Count, B.distribution.Count);
            C.SetSize(maxIndex);
            for (int i = 0; i < maxIndex; i++)
            {
                int aCount = (i < A.distribution.Count) ? A.distribution[i] : 0;
                int bCount = (i < B.distribution.Count) ? B.distribution[i] : 0;

                C.distribution[i] = (Add) ? (aCount + bCount) : (aCount - bCount);
            }

            C.setNormalizedDistribution();
            return C;
        }

        public int MaxMultiplicity => (distribution.Count - 1);

        public List<int> NonNormalizedDistribution => distribution;

        public List<double> NormalizedDistribution
        {
            get
            {
                if (!normalaizedUpToDate)
                {
                    setNormalizedDistribution();
                }

                return normalizedDistribution;
            }
        }

        protected List<int> distribution;
        private List<double> normalizedDistribution;
        protected bool normalaizedUpToDate;

        public MultiplicityDistribution()
        {
            normalaizedUpToDate = false;
            distribution = new List<int>();
            distribution.Add(0);
        }

        protected void SetSize(int multiplicity)
        {
            while (multiplicity > MaxMultiplicity)
            {
                distribution.Add(0);
            }
        }

        public void AddMultiplicity(int multiplicity)
        {
            normalaizedUpToDate = false;
            SetSize(multiplicity);
            distribution[multiplicity]++;
        }

        private void setNormalizedDistribution()
        {
            double total = distribution.Sum();
            normalizedDistribution = new List<double>();
            foreach (var n in distribution)
            {
                normalizedDistribution.Add((double)n / total);
            }

            normalaizedUpToDate = true;
        }
    }

    public class FixedSizeMultiplicityDistribution : MultiplicityDistribution
    {
        private readonly int MaximumMultiplicity;
        public int OverflowEvents { get; private set; }

        public FixedSizeMultiplicityDistribution(int maxMultiplicity)
        {
            MaximumMultiplicity = maxMultiplicity;
            OverflowEvents = 0;
        }

        public new void AddMultiplicity(int multiplicity)
        {
            normalaizedUpToDate = false;
            SetSize(multiplicity);
            if (multiplicity > MaxMultiplicity)
            {
                OverflowEvents++;
            }
            else
            {
                distribution[multiplicity]++;
            }
        }

        protected new void SetSize(int multiplicity)
        {
            while (multiplicity > MaxMultiplicity && MaxMultiplicity <= MaximumMultiplicity)
            {
                distribution.Add(0);
            }
        }
    }
}
