using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Port
{
    public Port(SignalComp owner, bool outputPort)
    {
        sc_owner = owner;
        b_isOutputPort = outputPort;

        b_inUse = false;
        p_connectedPort = null;
        i_valueInPort = 0;
    }

    SignalComp sc_owner;//Signal comp the port belongs to
    bool b_inUse;//Is the port in use?
    Port p_connectedPort;//If in use, which port is it connected to

    bool b_isOutputPort;//Is the port holding a components output?
    int i_valueInPort;//Value currently in the port

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
}
