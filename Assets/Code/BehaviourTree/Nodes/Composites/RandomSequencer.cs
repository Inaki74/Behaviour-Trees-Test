using System.Collections.Generic;
using BehaviourTreeTests.Utility;

namespace BehaviourTreeTests.BehaviorTree.Nodes {
    public class RandomSequencer : Sequencer {
        public RandomSequencer(List<Node> nodes) : base(nodes) {}

        public override RunStates Run(float deltaTime)
        {
            _children.Shuffle<Node>();

            return base.Run(deltaTime);
        }
    }
}

