using System;
using System.Collections.Generic;

namespace Pipeline
{
    /// <summary>
    /// Status of operations with single item
    /// </summary>
    public class ItemProgress<T>:IProgress
    {
        private List<object> _results;
        /// <summary>
        /// Gets whether item left pipeline with success
        /// </summary>
        public bool Completed { get; set; }

        /// <summary>
        /// Gets whether item left pipeline after cancellation
        /// </summary>
        public bool Cancelled { get; set; }

        /// <summary>
        /// Gets whether item left pipeline after exception
        /// </summary>
        public Exception Error { get; set; }

        /// <summary>
        /// Gets whether item left pipeline after exception
        /// </summary>
        public bool Failed { get { return Error != null; } }

        /// <summary>
        /// Gets intermediate state of pipeline
        /// </summary>
        public T CurrentValue { get; private set; }

        /// <summary>
        /// Gets previous states of pipeline
        /// </summary>
        public List<object> Results
        {
            get
            {
                if (_results == null)
                    _results = new List<object>();
                return _results;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="current">Current state</param>
        public ItemProgress(T current)
        {
            CurrentValue = current;
            Results.Add(current);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="st">Previous states of pipeline</param>
        /// <param name="current">Current state</param>
        public ItemProgress(IProgress st, T current)
        {
            if (st != null)
                _results = st.Results;
            CurrentValue = current;
            Results.Add(current);            
        }
    }
}
