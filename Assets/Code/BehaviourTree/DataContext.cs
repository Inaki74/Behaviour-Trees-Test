using System.Collections.Generic;

namespace BehaviourTreeTests.BehaviorTree
{
    public class DataContext
    {
        public bool Debug { get; set; }

        public Dictionary<string, object> _data = new();

        public void AddOrUpdateVariable(string varName, object value)
        {
            if (_data.ContainsKey(varName))
            {
                _data[varName] = value;
            }
            else
            {
                _data.Add(varName, value);
            }
        }

        // PRE: VarName exists in Dictionary.
        public T GetVariable<T>(string varName) {
            return (T) _data[varName];
        }

        public bool VariableExists(string varName) {
            return _data.ContainsKey(varName);
        }
    }
}
