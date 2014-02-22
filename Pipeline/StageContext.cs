using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;

namespace Pipeline
{
    public class StageContext
    {
        public SynchronizationContext Synchro { get; set; }
        private List<IProgress> _results;
        public List<IProgress> Results
        {
            get
            {
                if (_results == null)
                    _results = new List<IProgress>();
                return _results;
            }
        }
        public CancellationToken Token { get; set; }
        public event EventHandler<CancelEventArgs> Completed;

        public StageContext()
        {
            Synchro = SynchronizationContext.Current;
            Token = CancellationToken.None;
        }

        public void ReportCompletion(bool cancellation)
        {
            OnCompleted(new CancelEventArgs(cancellation));
        }

        protected virtual void OnCompleted(CancelEventArgs e)
        {
            if (Synchro != null)
                Synchro.Post(o => Completed(this, e), null);
            else
                Completed(this, e);            
        }
    }
}
