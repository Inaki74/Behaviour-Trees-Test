namespace BehaviourTreeTests.BehaviorTree.Nodes {
    public class RepeateUntilFail : Decorator {
        public RepeateUntilFail(Node node) : base(node) {}

        public override RunStates Run(float deltaTime)
        {
            RunStates result = _child.Run(deltaTime);

            if(result == RunStates.FAILURE) {
                return result;
            }

            return RunStates.RUNNING;
        }
    }
}
