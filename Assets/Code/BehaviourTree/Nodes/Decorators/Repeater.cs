namespace BehaviourTreeTests.BehaviorTree.Nodes {
    public class Repeater : Decorator {
        public Repeater(DataContext context, Node node) : base(context, node) {}
        public Repeater(DataContext context, Node node, int iterations) : base(context, node) 
        {
            _iterations = iterations;
        }

        private int _iterations = -1;
        private int _currentIteration = 0;

        protected override RunStates InternalRun(float deltaTime)
        {
            ResetIfNecessary();

            RunStates result = _child.Run(deltaTime);

            _currentIteration++;

            if(_iterations != -1 && _currentIteration == _iterations) {
                return result;
            }

            return RunStates.RUNNING;
        }
        public override string ToString()
        {
            return "Repeater";
        }
    }
}
