namespace BehaviourTreeTests.BehaviorTree.Nodes
{
    public class RunXTimes : Leaf
    {
        public RunXTimes(DataContext context, int iterations, RunStates finalResult) : base(context) 
        {
            _iterations = iterations;
            _finalResult = finalResult;
        }

        private RunStates _finalResult;
        private int _iterations;
        private int _currentIteration;

        protected override RunStates InternalRun(float deltaTime)
        {
            _currentIteration++;

            if(_currentIteration == _iterations) {
                return _finalResult; 
            }

            return RunStates.RUNNING;
        }
        public override string ToString()
        {
            return "RunXTimes";
        }
    }
}
