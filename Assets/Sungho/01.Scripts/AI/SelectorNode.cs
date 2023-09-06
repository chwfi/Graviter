
using System.Collections.Generic;

namespace BehaviourTree
{
    public class SelectorNode : Node
    {
        protected List<Node> _nodes = new();
        public SelectorNode(List<Node> nodes)
        {
            _nodes = nodes;
        }
        public override NodeState Evaluate()
        {
            foreach (var node in _nodes)
            {
                switch (node.Evaluate())
                {
                    case NodeState.RUNNING:
                        _nodeState = NodeState.RUNNING;
                        return _nodeState;
                    case NodeState.SUCCESS:
                        _nodeState = NodeState.SUCCESS;
                        return _nodeState;
                    case NodeState.FAILURE:
                        _nodeState = NodeState.FAILURE;
                        break;

                    default:
                        break;

                }
            }
            _nodeState = NodeState.FAILURE;
            return _nodeState;

        }
    }
}
