using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;

namespace Pipeline
{
    public abstract class PipelineController<TIn>
    {        
        public abstract void Start(IEnumerable<TIn> args);

        public abstract void Cancel();

        public abstract IEnumerable<IProgress> Results { get; }

        public event EventHandler<CancelEventArgs> Completed;

        protected virtual void OnCompleted(CancelEventArgs e)
        {
            if (Completed != null)
                Completed(this, e);
        }

        protected int IndexOfA(string str)
        {
            Thread.Sleep(Math.Max(Interval1, 100));
            return Math.Max(str.IndexOf('a'), 0);
        }

        protected double Sqrt(int i)
        {
            if (i > 28)
                throw new IndexOutOfRangeException("fail test");
            Thread.Sleep(Math.Max(Interval2, 100));
            return Math.Sqrt(i);
        }

        protected bool IsCorrect(double d)
        {
            Thread.Sleep(Math.Max(Interval3, 100));
            return d > 3;
        }

        public int Interval1 { get; set; }
        public int Interval2 { get; set; }
        public int Interval3 { get; set; } 
    }
}
