
namespace BehaviourTreeTests.BehaviorTree.Nodes
{
    public class Fail : Leaf
    {
        public Fail (DataContext context) : base(context) {}
        protected override RunStates InternalRun(float deltaTime)
        {
            return RunStates.FAILURE;
        }
        public override string ToString()
        {
            return "Fail";
        }
    }
}
