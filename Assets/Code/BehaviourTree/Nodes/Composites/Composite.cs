using System.Collections.Generic;

namespace BehaviourTreeTests.BehaviorTree.Nodes {
    public abstract class Composite : Node {
        protected List<Node> _children;

        public Composite(List<Node> nodes) {
            _children = nodes;
        }
    }
}
