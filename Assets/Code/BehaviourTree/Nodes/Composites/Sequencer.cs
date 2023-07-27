using System.Collections.Generic;

namespace BehaviourTreeTests.BehaviorTree.Nodes
{
    public class Sequencer : Composite
    {
        public Sequencer(DataContext context, List<Node> nodes) : base(context, nodes) { }

        protected override RunStates InternalRun(float deltaTime)
        {
            ResetChildrenIfNecessary();

            for (int i = 0; i < this._children.Count; i++)
            {
                RunStates result = _children[i].Run(deltaTime);

                switch (result)
                {
                    case RunStates.FAILURE:
                        return RunStates.FAILURE;
                    case RunStates.SUCCESS:
                        continue;
                    case RunStates.RUNNING:
                        return RunStates.RUNNING;
                }
            }

            return RunStates.SUCCESS;
        }
        public override string ToString()
        {
            return "Sequencer";
        }
    }
}
