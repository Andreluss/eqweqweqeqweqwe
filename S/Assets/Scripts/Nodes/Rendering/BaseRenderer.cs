using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class BaseRenderer : MonoBehaviour
{
    protected BaseRenderer()
    {
    }

    public virtual void Draw() { }
    public virtual bool Selected { get; set; }

    internal virtual void UpdatePosition(Vector2 position)
    {
        throw new NotImplementedException();
    }
}
