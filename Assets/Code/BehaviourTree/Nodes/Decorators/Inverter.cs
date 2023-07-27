namespace BehaviourTreeTests.BehaviorTree.Nodes {
    public class Inverter : Decorator {
        public Inverter(DataContext context, Node node) : base(context, node) {}

        protected override RunStates InternalRun(float deltaTime)
        {
            ResetIfNecessary();

            RunStates result = _child.Run(deltaTime);

            if(result == RunStates.FAILURE){
                return RunStates.SUCCESS;
            }

            if(result == RunStates.SUCCESS){
                return RunStates.FAILURE;
            }
            
            return RunStates.RUNNING;
        }
        public override string ToString()
        {
            return "Inverter";
        }
    }
}
