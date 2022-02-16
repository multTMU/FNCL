using System;

namespace GeometrySampling
{
    public struct Bounds<T> where T : IComparable<T>
    {
        public T Lower;
        public T Upper;

        public bool BoundsValue(T value)
        {
            //  return value.CompareTo(Lower) == 1 && value.CompareTo(Upper) == -1;
            //bool lower = value.CompareTo(Lower) >= 0;
            //bool upper = value.CompareTo(Upper) <= 0;

            //bool lowerA = value.CompareTo(Lower) < 0;
            //bool upperA = value.CompareTo(Upper) > 0;
            return value.CompareTo(Lower) >= 0 && value.CompareTo(Upper) <= 0;
        }

        public bool AboveBounds(T value)
        {
            return value.CompareTo(Upper) > 0;
        }

        public bool BelowBounds(T value)
        {
            return value.CompareTo(Lower) < 0;
        }

        public Bounds(T low, T high)
        {
            Lower = low;
            Upper = high;
        }
    }
}
