using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Port : MonoBehaviour
{
    public Port(SignalComp owner, bool outputPort)
    {
        sc_owner = owner;
        b_isOutputPort = outputPort;

        b_inUse = false;
        p_connectedPort = null;
        i_valueInPort = 0;
    }
    [SerializeField]
    public SignalComp sc_owner;//Signal comp the port belongs to
    [SerializeField]
    public bool b_inUse;//Is the port in use?
    //[HideInInspector]
    public Port p_connectedPort;//If in use, which port is it connected to

    [SerializeField]
    bool b_isOutputPort;//Is the port holding a components output?
    //[HideInInspector]
    public int i_valueInPort;//Value currently in the port

    [SerializeField]
    Material mat_unselected;
    [SerializeField]
    Material mat_selected;

    public int GetConnectedValue()
    {
        if (b_inUse && !b_isOutputPort)
        {
            return p_connectedPort.i_valueInPort;
        }
        return 0;
    }

    public void SetConnectedValue(int value)
    {
        if (b_isOutputPort)
        {
            i_valueInPort = value;
        }
    }

    public void ConnectToPort(Port port)
    {
        p_connectedPort = port;
        b_inUse = true;
    }

    public void DisconnectPort()
    {
        p_connectedPort = null;
        b_inUse = false;
        if(!b_isOutputPort) i_valueInPort = 0;
    }

   // public void SelectPort()
   // {
   //     
   // }
   //
   // public void DeselectPort()
   // {
   //     
   // }
}
