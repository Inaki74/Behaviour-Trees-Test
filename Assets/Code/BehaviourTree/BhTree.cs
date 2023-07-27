using BehaviourTreeTests.BehaviorTree.Nodes;


namespace BehaviourTreeTests.BehaviorTree
{
    public class BhTree
    {
        private Node _root;

        private DataContext _dataContext = new();
        public DataContext DataContext { get => _dataContext; }

        public BhTree(bool debug)
        {
            _dataContext.Debug = debug;
        }

        public void Setup(Node root)
        {
            _root = root;
        }

        public void Execute(float deltaTime)
        {
            _root.Run(deltaTime);
        }

        public string GetSequence()
        {
            if (_dataContext.Debug)
            {
                return _dataContext.GetVariable<string>(Constants.SEQUENCER_VARIABLE_NAME);
            }
            else
            {
                throw new System.Exception("DEBUG mode not activated, can't get Sequence.");
            }
        }
    }
}
