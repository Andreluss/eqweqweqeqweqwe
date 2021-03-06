using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeCollision : CollisionData
{
    public Node node;
    public NodeRenderer NodeRenderer { get => node?.GetRenderer(); }
    public override BaseRenderer Renderer { get => NodeRenderer; }
}
