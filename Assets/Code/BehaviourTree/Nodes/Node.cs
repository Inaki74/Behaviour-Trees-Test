using UnityEngine;
using BehaviourTreeTests.BehaviorTree;

namespace BehaviourTreeTests.BehaviorTree.Nodes
{
    public abstract class Node
    {
        public Node(DataContext dataContext) {
            _dataContext = dataContext;
        }

        public RunStates Result { get; set; } = RunStates.NOT_YET_RUN;

        protected DataContext _dataContext;
        public DataContext DataContext { get => _dataContext; set => _dataContext = value; }

        public virtual void Init() 
        { 
        }

        public RunStates Run(float deltaTime)
        {
            if (Result == RunStates.SUCCESS || Result == RunStates.FAILURE)
            {
                DebugIfAble(this + " has run already.");
                return Result;
            }

            if (Result == RunStates.NOT_YET_RUN)
                Init();

            DebugIfAble("Running: " + this);
            AddToExecutionListIfAble();
            RunStates result = InternalRun(deltaTime);

            Result = result;

            DebugIfAble("Result of running: " + this + " is: " + Result);

            return result;
        }

        protected virtual RunStates InternalRun(float deltaTime)
        {
            return RunStates.SUCCESS;
        }
        public virtual void FixedUpdate(float deltaTime) { }
        public virtual void Reset()
        {
            Result = RunStates.NOT_YET_RUN;
        }

        private void DebugIfAble(string message)
        {
            if (_dataContext.Debug)
            {
                Debug.Log(message);
            }
        }

        private void AddToExecutionListIfAble()
        {
            if (_dataContext.Debug)
            {
                if (_dataContext.VariableExists(Constants.SEQUENCER_VARIABLE_NAME))
                {
                    string sequence = _dataContext.GetVariable<string>(Constants.SEQUENCER_VARIABLE_NAME);
                    sequence += $"/{this.ToString()}";
                    _dataContext.AddOrUpdateVariable(Constants.SEQUENCER_VARIABLE_NAME, sequence);
                }
                else
                {
                    _dataContext.AddOrUpdateVariable(Constants.SEQUENCER_VARIABLE_NAME, this.ToString());
                }
            }
        }
    }
}
