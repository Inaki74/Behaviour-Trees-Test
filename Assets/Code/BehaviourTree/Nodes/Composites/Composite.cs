using System.Collections.Generic;

namespace BehaviourTreeTests.BehaviorTree.Nodes
{
    public abstract class Composite : Node
    {
        protected List<Node> _children = new();

        public Composite(DataContext context, List<Node> nodes) : base(context)
        {
            _children = nodes;
        }
        
        protected void ResetChildrenIfNecessary() {
            bool necessary = !HelperFunctions.AtleastOneChildRunningOrNotYetRun(_children);
            
            if(necessary) {
                for(int i = 0; i < _children.Count; i++) {
                    _children[i].Reset();
                }
            }
        }
    }
}
