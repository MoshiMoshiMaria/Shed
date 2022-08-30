using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompButton : CompBits
{
    [HideInInspector]
    public bool b_isOn; //Is the button on?

    public override void OnClickAction()
    {
        b_isOn = !b_isOn;

        //Add behaviour which makes it obvious it is on
    }
    public override void OnScrollAction(float deltaScroll)
    {
        //Do Nothing
    }

    public bool GetOn()
    {
        return b_isOn;
    }
}
