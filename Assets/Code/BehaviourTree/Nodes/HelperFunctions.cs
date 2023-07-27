using System.Collections.Generic;

namespace BehaviourTreeTests.BehaviorTree.Nodes
{
    public static class HelperFunctions
    {
        public static bool AtleastOneChildRunningOrNotYetRun(List<Node> _children)
        {
            for (int i = 0; i < _children.Count; i++)
            {
                if (_children[i].Result == RunStates.RUNNING || _children[i].Result == RunStates.NOT_YET_RUN)
                    return true;
            }
            return false;
        }
    }
}
