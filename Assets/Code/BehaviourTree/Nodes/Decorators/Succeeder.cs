namespace BehaviourTreeTests.BehaviorTree.Nodes {
    public class Succeeder : Decorator {
        public Succeeder(Node node) : base(node) {}

        public override RunStates Run(float deltaTime)
        {
            RunStates result = _child.Run(deltaTime);

            return RunStates.SUCCESS;
        }
    }
}
