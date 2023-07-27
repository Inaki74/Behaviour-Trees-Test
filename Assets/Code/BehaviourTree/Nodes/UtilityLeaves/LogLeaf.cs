namespace BehaviourTreeTests.BehaviorTree.Nodes
{
    public class LogLeaf : Leaf
    {
        public string _message;

        public LogLeaf(DataContext context, string message) : base(context)
        {
            _message = message;
        }

        protected override RunStates InternalRun(float deltaTime)
        {
            int rInt = UnityEngine.Random.Range(0, 3);


            UnityEngine.Debug.Log($"{rInt}");

            switch (rInt)
            {
                case 0:
                    UnityEngine.Debug.Log($"Ran LogLeaf {_message}, FAILURE");
                    return RunStates.FAILURE;
                case 1:
                    UnityEngine.Debug.Log($"Ran LogLeaf {_message}, SUCCESS");
                    return RunStates.SUCCESS;
                case 2:
                    UnityEngine.Debug.Log($"Ran LogLeaf {_message}, RUNNING");
                    return RunStates.RUNNING;
                default:
                    return RunStates.NOT_YET_RUN;
            }
        }

        public override string ToString()
        {
            return "LogLeaf, m: " + _message;
        }
    }
}
