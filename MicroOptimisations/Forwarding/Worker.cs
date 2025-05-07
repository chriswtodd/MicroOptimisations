namespace MicroOptimisations.Forwarding
{
    public abstract class Worker 
    {
        public abstract int Do(string r);
    }

    public class WorkerDirect : Worker
    {
        public override int Do(string r)
        {
            return r.Length;
        }
    }

    public class WorkerForwarder : Worker 
    {
        private readonly IForwarder _forwarder;

        public WorkerForwarder() {
            _forwarder = new Forwarder(new Forwarder(new ForwardedResult()));
        }

        public override int Do(string r)
        {
            return _forwarder.forward(r);
        }
    }
}