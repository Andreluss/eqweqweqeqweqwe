using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MBIIC : ItemController
{
    protected override void Start()
    {
        base.Start();

        if(PlayerController.Instance.Mode == PlayerController.GameMode.Edit)
            contextMenuItems.RemoveAt(0);

        var ctrl = (rClickableObj as MBICollision).node;
        contextMenuItems.Add(new ContextMenuItem("Switch signed/unsigned", sampleButton,
            () => (ctrl as MultibitControllerInput).Signed = !(ctrl as MultibitControllerInput).Signed));

        //contextMenuItems.Add(new ContextMenuItem("Change value", sampleButton,
        //    () => PlayerController.Instance.OnTypeValue(ctrl as MultibitControllerInput)));
    }
}
