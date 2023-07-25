using System.Collections.Generic;

namespace BehaviourTreeTests.BehaviorTree.Nodes {
    public class Sequencer : Composite {
        public Sequencer(List<Node> nodes) : base(nodes) {}

        public override RunStates Run(float deltaTime)
        {
            for(int i = 0; i < this._children.Count; i++) {
                RunStates result = _children[i].Run(deltaTime);

                switch (result) {
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
    }
}
