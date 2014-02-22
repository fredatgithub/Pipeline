namespace Pipeline
{
    public interface IStage<TIn>
    {
        void Init(StageContext ctx);
        bool Enqueue(ItemProgress<TIn> input);
        int BufferCapacity { get; }
        bool CanBeStarted { get; }
        void SendTerminationSignal();
    }
}
