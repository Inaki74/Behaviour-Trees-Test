namespace BehaviourTreeTests.BehaviorTree.Nodes
{
    public class Success : Leaf
    {
        public Success(DataContext context) : base(context) {}
        protected override RunStates InternalRun(float deltaTime)
        {
            return RunStates.SUCCESS;
        }
        public override string ToString()
        {
            return "Success";
        }
    }
}
