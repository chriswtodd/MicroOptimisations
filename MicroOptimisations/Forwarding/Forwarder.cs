namespace MicroOptimisations.Forwarding
{
    public interface IForwarder {
        int forward(string s);
    }

    public class Forwarder : IForwarder
    {
        private readonly IForwarder _forwarder;

        public Forwarder(IForwarder forwarder) 
        {
            _forwarder = forwarder;
        }

        public int forward(string s)
        {
            return _forwarder.forward(s);
        }
    }

    public class ForwardedResult : IForwarder
    {
        public int forward(string s)
        {
            return s.Length;
        }
    }
}