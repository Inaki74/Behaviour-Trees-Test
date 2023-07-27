namespace BehaviourTreeTests.BehaviorTree.Nodes {
    public class Succeeder : Decorator {
        public Succeeder(DataContext context, Node node) : base(context, node) {}

        protected override RunStates InternalRun(float deltaTime)
        {
            ResetIfNecessary();

            RunStates result = _child.Run(deltaTime);

            return RunStates.SUCCESS;
        }

        public override string ToString()
        {
            return "Succeeder";
        }
    }
}
