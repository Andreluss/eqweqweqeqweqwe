using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputRenderer : NodeRenderer
{
    private TextMeshPro text;
    private TextMeshPro description;
    RectTransform rt;
    private void Awake()
    {
        outline = transform.parent.GetChild(3).gameObject;
        rt = transform.parent.GetComponent<RectTransform>();
    }
    public override void EnableOutline()
    {
        outline.SetActive(true);
    }
    public override void DisableOutline()
    {
        outline.SetActive(false);
    }
    public static InputRenderer Make(InputNode forWho)
    {
        var inputRootGO = Instantiate(Resources.Load<GameObject>
                                     ("Sprites/InputRoot"));
        var inputGO = inputRootGO.transform.GetChild(0).gameObject;
        var inputRend = inputGO.GetComponent<InputRenderer>();
        inputRend.Node = forWho;
        Vector2 dim = inputGO.GetComponent<SpriteRenderer>().size;

        var socket = OutSocketRenderer.Make(forWho, 0);
        socket.transform.SetParent(inputRootGO.transform, false);
        float zIndex = socket.transform.localPosition.z;
        socket.transform.localPosition = new Vector3(+dim.x / 2,
                                                     0,
                                                     zIndex);
        inputRend.outSocketRends = new OutSocketRenderer[] { socket };

        inputRend.text = inputRootGO.GetComponentInChildren<TextMeshPro>();

        inputRend.description = inputRootGO.transform.GetChild(2).GetComponent<TextMeshPro>();

        var coll = inputGO.GetComponent<InputCollision>();
        coll.node = forWho;

        return inputRend;
    }

    public void UpdateDescription()
    {
        description.text = Node.Description;
    }

    internal void HandleValue(bool value)
    {
        text.text = value ? "1" : "0";
    }
    public override void HandlePinPosition()
    {
        Vector3 stageBorders = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        float x = stageBorders.x;
        float nodeWidth = rt.rect.width;
        var newPos = node.Position;
        
        newPos.x = x + nodeWidth / 2 * 1.05f;

        node.Position = newPos;
    }
}
