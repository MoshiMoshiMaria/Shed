using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

abstract public class CompBits : MonoBehaviour
{
    [SerializeField]
    SignalComp sc_ownerComp;//Connected singal comp

    abstract public void OnClickAction();
    abstract public void OnScrollAction(float deltaScroll);
}
