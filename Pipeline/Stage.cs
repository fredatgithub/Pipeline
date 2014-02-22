using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Pipeline
{
    public class Stage<TIn, TOut>:IStage<TIn>
    {
        private Queue<ItemProgress<TIn>> _buffer;
        private StageContext _ctx;
        private int _capacity;
        private IStage<TOut> _next;
        private bool _canStop;
        private bool _isCompleted;
        private bool _isCancelled;

        public Stage(Func<TIn, TOut> function)
        {
            _capacity = Int32.MaxValue;
            if (function == null)
                throw new ArgumentNullException("function");
            Function = function;
        }

        private Func<TIn, TOut> _function;
        public Func<TIn, TOut> Function
        {
            get { return _function; }
            set
            {
                if (IsRunning)
                    return;
                _function = value;
            }
        }

        /// <summary>
        /// Next stage of a pipeline
        /// </summary>
        public IStage<TOut> Next
        {
            get { return _next; }
            set
            {
                if (IsRunning)
                    return;
                _next = value;
            }
        }

        public bool IsLastStage { get { return Next == null; } }

        public int BufferCapacity
        {
            get { return _capacity; }
            set
            {
                if (IsRunning)
                    return;
                if (value < 4)
                    throw new ArgumentOutOfRangeException("value");
                _capacity = value;
            }
        }

        public bool CanBeStarted
        {
            get { return IsRunning == false && (Next == null || Next.CanBeStarted); }
        }

        public virtual bool IsCompleted
        {
            get { return _isCompleted; }
            protected set
            {
                _isCompleted = value;
                if (_isCompleted)
                {
                    IsRunning = false;
                    if (Next != null)
                        Next.SendTerminationSignal();
                }
            }
        }
        
        public virtual bool IsCancelled
        {
            get { return _isCancelled; }
            protected set
            {
                _isCancelled = value;
                if (_isCancelled)
                    IsRunning = false;   
            }
        }

        public bool IsRunning
        {
            get;
            private set;
        }

        public void Start(IEnumerable<TIn> input, StageContext ctx)
        {
            if (CanBeStarted == false)
                throw new InvalidOperationException("Pipeline can not be started: one of stages is running");
            _ctx = ctx ?? new StageContext();
            Next.Init(_ctx);
            var t = new Task(() =>
            {
                ItemProgress<TOut> produced = null;
                foreach (var item in input)
                {
                    var pr = new ItemProgress<TIn>(item);                    
                    try
                    {
                        produced = new ItemProgress<TOut>(pr, Function(pr.CurrentValue));
                    }
                    catch (Exception ex)
                    {
                        ItemFailed(pr, ex);
                        continue;
                    }
                    TryEnqueueResult(produced);
                    if (_ctx.Token.IsCancellationRequested)
                    {
                        break;
                    }
                }
                StageCompleted();
            }, _ctx.Token);
            t.Start();
        }

        public void Init(StageContext ctx)
        {
            if (IsRunning)
                return;
            _ctx = ctx ?? new StageContext();
            _buffer = new Queue<ItemProgress<TIn>>();
            IsRunning = true;
            IsCompleted = false;
            IsCancelled = false;
            _canStop = false;
            if (Next != null)
                Next.Init(_ctx);

            var t = new Task(() =>
                {
                    while ((_canStop == false || (_canStop && _buffer.Count > 0)) && !_ctx.Token.IsCancellationRequested)
                    {
                        if (_buffer.Count > 0)
                        {
                            var current = _buffer.Dequeue();
                            try
                            {
                                var produced = new ItemProgress<TOut>(current, Function(current.CurrentValue));
                                TryEnqueueResult(produced);
                            }
                            catch (Exception ex)
                            {
                                ItemFailed(current, ex);
                            }
                        }
                        else
                        {
                            Thread.Sleep(50);
                        }
                    }

                    StageCompleted();
                });
            t.Start();
        }        

        private void TryEnqueueResult(ItemProgress<TOut> itemProgress)
        {
            if (Next != null)            
                while (Next.Enqueue(itemProgress) == false)
                {
                    Thread.Sleep(50);
                    if (_ctx.Token.IsCancellationRequested)
                        return;
                }            
            else
                ItemCompleted(itemProgress);
        }

        /// <summary>
        /// Enqueue item when stage is running and buffer is not full. 
        /// </summary>
        /// <param name="input">Input value</param>
        /// <returns>Returns true if item was added</returns>
        public bool Enqueue(ItemProgress<TIn> input)
        {            
            if (IsRunning == false)
                return true;
            if (_buffer.Count >= BufferCapacity)
                return false;
            _buffer.Enqueue(input);
            return true;
        }        

        public void SendTerminationSignal()
        {
            _canStop = true;
        }

        public Stage<TOut, TNext> Add<TNext>(Func<TOut, TNext> nextFunction)
        {                        
            return Add(new Stage<TOut, TNext>(nextFunction));
        }

        public Stage<TOut, TNext> Add<TNext>(Stage<TOut, TNext> nextStage)
        {
            if (IsRunning)
                throw new InvalidOperationException();
            if (nextStage == null)
                throw new ArgumentNullException("nextStage");
            Next = nextStage;
            return nextStage;
        }

        /// <summary>
        /// Reports when result was produces
        /// </summary>
        /// <param name="result">Output value</param>
        public void ItemCompleted(ItemProgress<TOut> result)
        {
            result.Completed = IsLastStage;
            _ctx.Results.Add(result);
        }

        /// <summary>
        /// Reports when exception occured
        /// </summary>
        /// <param name="result"> </param>
        /// <param name="ex"></param>
        public void ItemFailed(ItemProgress<TIn> result, Exception ex)
        {
            result.Error = ex;
            _ctx.Results.Add(result);
        }

        /// <summary>
        /// Reports when opeartion was completed
        /// </summary>  
        private void StageCompleted()
        {
            if (_ctx.Token.IsCancellationRequested)
                StageCancelled();
            else
                IsCompleted = true;

            if (IsLastStage)
                _ctx.ReportCompletion(IsCancelled);
            else
                Next.SendTerminationSignal();
        }

        /// <summary>
        /// Reports when opeartion was cancelled
        /// </summary>        
        public void StageCancelled()
        {
            if (_buffer != null)
            {
                foreach (var result in _buffer)
                {
                    result.Cancelled = true;
                    _ctx.Results.Add(result);
                }
                _buffer.Clear();
            }            
            IsCancelled = true;
        }
    }
}
