namespace BehaviourTreeTests.BehaviorTree.Nodes {
    public class RepeatUntilFail : Decorator {
        public RepeatUntilFail(DataContext context, Node node) : base(context, node) {}

        protected override RunStates InternalRun(float deltaTime)
        {
            ResetIfNecessary();

            RunStates result = _child.Run(deltaTime);

            if(result == RunStates.FAILURE) {
                return RunStates.SUCCESS;
            }

            return RunStates.RUNNING;
        }
        public override string ToString()
        {
            return "RepeatUntilFail";
        }
    }
}
