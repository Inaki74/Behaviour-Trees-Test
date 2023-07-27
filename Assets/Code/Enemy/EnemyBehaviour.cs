using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTreeTests.BehaviorTree;
using BehaviourTreeTests.BehaviorTree.Nodes;

namespace BehaviourTreeTests.Enemy
{
    public class EnemyBehaviour : MonoBehaviour
    {
        public BhTree _tree;
        // Start is called before the first frame update
        void Start()
        {
            _tree = new(true);

            _tree.Setup(new LogLeaf(_tree.DataContext, "Test 1"));
        }

        // Update is called once per frame
        void Update()
        {
            _tree.Execute(Time.deltaTime);
            Debug.Log(_tree.GetSequence());
        }
    }
}
