namespace BehaviourTreeTests.BehaviorTree.Nodes {
    public class Inverter : Decorator {
        public Inverter(Node node) : base(node) {}

        public override RunStates Run(float deltaTime)
        {
            RunStates result = _child.Run(deltaTime);

            if(result == RunStates.FAILURE)
                return RunStates.SUCCESS;

            if(result == RunStates.SUCCESS)
                return RunStates.FAILURE;

            return RunStates.RUNNING;
        }
    }
}
