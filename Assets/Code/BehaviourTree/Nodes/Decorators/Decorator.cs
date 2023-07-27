namespace BehaviourTreeTests.BehaviorTree.Nodes
{
    public abstract class Decorator : Node
    {
        protected Node _child;

        public Decorator(DataContext context, Node node) : base(context)
        {
            _child = node;
        }

        protected void ResetIfNecessary()
        {
            if (_child.Result != RunStates.NOT_YET_RUN && _child.Result != RunStates.RUNNING)
                _child.Reset();
        }
    }
}
