namespace BehaviourTreeTests.BehaviorTree.Nodes {
    public abstract class Node {
        public virtual void Init() {}
        public virtual RunStates Run(float deltaTime) 
        {
            return RunStates.SUCCESS;
        }
        public virtual void FixedUpdate(float deltaTime) {}
        public virtual void Reset() {}
    }
}
