namespace BehaviourTreeTests.BehaviorTree.Nodes {
    public class Repeater : Decorator {
        public Repeater(Node node) : base(node) {}
        public Repeater(Node node, int iterations) : base(node) 
        {
            _iterations = iterations;
        }

        private int _iterations;
        private int _currentIteration = 0;

        public override RunStates Run(float deltaTime)
        {
            RunStates result = _child.Run(deltaTime);

            _currentIteration++;

            if(_currentIteration == _iterations) {
                return result;
            }

            return RunStates.RUNNING;
        }
    }
}
