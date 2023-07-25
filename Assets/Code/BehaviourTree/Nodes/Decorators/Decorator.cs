namespace BehaviourTreeTests.BehaviorTree.Nodes {
    public abstract class Decorator : Node {
        protected Node _child;

        public Decorator(Node node) {
            _child = node;
        }
    }
}
