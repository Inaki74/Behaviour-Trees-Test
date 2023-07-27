namespace BehaviourTreeTests.BehaviorTree.Nodes
{
    public class RunForever : Leaf
    {
        public RunForever(DataContext context) : base(context) {}
        protected override RunStates InternalRun(float deltaTime)
        {
            return RunStates.RUNNING;
        }
        public override string ToString()
        {
            return "RunForever";
        }
    }
}
