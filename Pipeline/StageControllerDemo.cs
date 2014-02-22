using System.Collections.Generic;
using System.Threading;

namespace Pipeline
{
    public class StageControllerDemo:PipelineController<string>
    {
        private Stage<string, int> _first;
        private StageContext _ctx;
        private CancellationTokenSource _cts;

        public StageControllerDemo()
        {
            _ctx = new StageContext();
            _ctx.Completed += (sender, e) => OnCompleted(e);
        }

        public override void Start(IEnumerable<string> args)
        {
            _first = new Stage<string, int>(IndexOfA);
            _first.Add(Sqrt).Add(IsCorrect);

            _cts = new CancellationTokenSource();
            _ctx.Token = _cts.Token;            
            _ctx.Results.Clear();
            _first.Start(args, _ctx);
        }

        public override void Cancel()
        {
            if (_cts != null)
                _cts.Cancel();
        }

        public override IEnumerable<IProgress> Results
        {
            get
            {                
                return _ctx.Results;
            }
        }
    }
}
