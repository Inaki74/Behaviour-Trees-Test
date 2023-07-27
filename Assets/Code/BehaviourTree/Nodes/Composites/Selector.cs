using System.Collections.Generic;

namespace BehaviourTreeTests.BehaviorTree.Nodes
{
    public class Selector : Composite
    {
        public Selector(DataContext context, List<Node> nodes) : base(context, nodes) { }

        protected override RunStates InternalRun(float deltaTime)
        {
            ResetChildrenIfNecessary();

            for (int i = 0; i < this._children.Count; i++)
            {
                RunStates result = _children[i].Run(deltaTime);

                switch (result)
                {
                    case RunStates.FAILURE:
                        continue;
                    case RunStates.SUCCESS:
                        return RunStates.SUCCESS;
                    case RunStates.RUNNING:
                        return RunStates.RUNNING;
                }
            }
            return RunStates.FAILURE;
        }
        public override string ToString()
        {
            return "Selector";
        }
    }
}
