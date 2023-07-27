using System.Collections.Generic;
using BehaviourTreeTests.Utility;

namespace BehaviourTreeTests.BehaviorTree.Nodes
{
    public class RandomSelector : Selector
    {
        public RandomSelector(DataContext context, List<Node> nodes) : base(context, nodes) { }

        protected override RunStates InternalRun(float deltaTime)
        {
            _children.Shuffle<Node>();

            return base.InternalRun(deltaTime);
        }

        public override string ToString()
        {
            return "RandomSelector";
        }
    }
}
