﻿public class OutputNode : Node
{
    public OutputNode(bool hidden = false) : base(1, 0, "Output", hidden)
    {
    }

    public bool GetValue() => outVals[0];
}