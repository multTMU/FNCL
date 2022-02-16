using System.Collections.Generic;

namespace Multiplicity
{
    /// <summary>
    /// Abstract class that is a first in first out queue.
    /// Rejects duplicate sequential entries, e.g. in a stream: (a,b,b) is stored as (a,b), and (a,b,b,a) is stored as (a,b,a)
    /// Size of queue is limited, by abstract method e.g. max number of entries.
    /// </summary>
    /// <typeparam name="TData"></typeparam> Type of data to be stored
    /// <typeparam name="TLimit"></typeparam> Type that controls queue size limit, e.g. int for a maximum size
    public abstract class LimitedQueueRejectSequentialDuplicates<TData, TLimit> : Queue<TData>
    {
        public int NumberSuccessfullyLogged { get; private set; }
        public int NumberLogAttempts { get; private set; }

        protected TData DataToAdd;
        protected TData LastDataAdded;
        protected readonly TLimit Limit;
        private int _lastHashCode;

        protected LimitedQueueRejectSequentialDuplicates(TLimit maxToKeep)
        {
            Limit = maxToKeep;
            NumberSuccessfullyLogged = 0;
            NumberLogAttempts = 0;
        }

        public new void Enqueue(TData newDataToAdd)
        {
            DataToAdd = newDataToAdd;
            AddDataIfUnique();
            RemoveDataThatExceedsLimit();
            NumberLogAttempts++;
        }

        private void RemoveDataThatExceedsLimit()
        {
            while (DataExceedsLimit())
            {
                Dequeue();
            }
        }

        private void AddDataIfUnique()
        {
            if (NewDataValid())
            {
                base.Enqueue(DataToAdd);
                LastDataAdded = DataToAdd;
                NumberSuccessfullyLogged++;
                _lastHashCode = DataToAdd.GetHashCode();
            }
        }

        protected virtual bool NewDataValid()
        {
            if (Count == 0)
            {
                LastDataAdded = DataToAdd;
                return true;
            }

            return _lastHashCode != DataToAdd.GetHashCode();
        }

        protected abstract bool DataExceedsLimit();
    }

    /// <summary>
    /// Abstract class that is a first in:first out queue.
    /// Allows duplicate sequential entries, e.g. in a stream: (a,b,b) is stored as (a,b,b)
    /// Size of queue is limited, by abstract method e.g. max number of entries.
    /// </summary>
    /// <typeparam name="TData"></typeparam> Type of Data stored in queue
    /// <typeparam name="TLimit"></typeparam> Type that limits queue size
    public abstract class
        LimitedSizeNonUniqueQueue<TData, TLimit> : LimitedQueueRejectSequentialDuplicates<TData, TLimit>
    {
        protected LimitedSizeNonUniqueQueue(TLimit maxToKeep) : base(maxToKeep)
        {
        }

        protected override bool NewDataValid()
        {
            return true;
        }
    }


    /// <summary>
    /// First in:first out data queue to store fixed length (max size) running list of data types
    /// </summary>
    /// <typeparam name="T"></typeparam> Type of data to be stored in queue
    public class FixedSizeNonUniqueQueue<T> : LimitedSizeNonUniqueQueue<T, int>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="maxSize"></param> Maximum size of the list, after maxSize entries are added the first entries are discarded
        public FixedSizeNonUniqueQueue(int maxSize) : base(maxSize)
        {
        }

        protected override bool DataExceedsLimit()
        {
            return Count > Limit;
        }
    }

    /// <summary>
    /// First in:first out data queue to store fixed length (max size) running list of data types, that does not store duplicate sequential entries
    /// </summary>
    /// <typeparam name="T"></typeparam> Type of data to be stored in queue
    public class FixedSizeUniqueQueue<T> : LimitedQueueRejectSequentialDuplicates<T, int>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="maxSize"></param> Maximum size of the list, after maxSize entries are added the first entries are discarded
        public FixedSizeUniqueQueue(int maxSize) : base(maxSize)
        {
        }

        protected override bool DataExceedsLimit()
        {
            return Count > Limit;
        }
    }

    public class DurationLimitedNoSequentialDuplicatesQueue<T> : LimitedQueueRejectSequentialDuplicates<T, double>
        where T : IPulse
    {
        public DurationLimitedNoSequentialDuplicatesQueue(double timeSpanToLog) : base(timeSpanToLog)
        {
        }

        protected override bool DataExceedsLimit()
        {
            if (Count > 0)
            {
                return (DataToAdd.GetTime() - Peek().GetTime()) > Limit;
            }

            return false;
        }

        public double GetTimeSpanned()
        {
            return (LastDataAdded.GetTime() - Peek().GetTime());
        }
    }

    public class TimeBufferedQueue<T> : LimitedSizeNonUniqueQueue<T, double> where T : IPulse
    {
        public TimeBufferedQueue(double timeSpanToLog) : base(timeSpanToLog)
        {
        }

        protected override bool DataExceedsLimit()
        {
            return false;
        }

        protected override bool NewDataValid()
        {
            if (Count > 0)
            {
                return (DataToAdd.GetTime() - LastDataAdded.GetTime()) > Limit;
            }

            return true;
        }

        public double GetTimeSpanned()
        {
            return (LastDataAdded.GetTime() - Peek().GetTime());
        }
    }
}
