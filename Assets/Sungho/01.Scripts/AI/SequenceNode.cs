using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTree
{
    public class SequenceNode : Node
    {
        protected List<Node> _nodes = new();
        public SequenceNode(List<Node> nodes)
        {
            _nodes = nodes;
        }
        public override NodeState Evaluate()
        {
            bool isAnyNodeTun = false;
            foreach (var node in _nodes)
            {
                switch (node.Evaluate())
                {

                    case NodeState.RUNNING:
                        isAnyNodeTun = true;
                        break;
                    case NodeState.SUCCESS:
                        _nodeState = NodeState.SUCCESS;
                        break;
                    case NodeState.FAILURE:
                        _nodeState = NodeState.FAILURE;
                        return _nodeState;

                    default:
                        break;

                }
            }
            _nodeState = isAnyNodeTun ? NodeState.RUNNING : NodeState.SUCCESS;
            return _nodeState;
        }
    }
}

