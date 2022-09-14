using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalOutput : MonoBehaviour
{

    [SerializeField]
    SignalInput si_signalInputPair;//Component providing the signals


    int i_numberOfSourceValues;//Number of source values at any given time - taken from source pair
    [SerializeField]
    public int i_numberofOutputValues;//Number of output values at any given time - independant of source pair


    [SerializeField]
    int i_numberOfInputs;//Number of input ports - serialized as it will differ between instances
    int i_numberOfOutputs;//Number of output ports - should always be 1

    [SerializeField]
    List<Port> l_inputPorts;//List of input Ports - can change between instances
    List<Port> l_outputPorts;//List of output ports

    [SerializeField]
    Port p_outputPort;//The output port - should connect to a GameObject(Either empty, or antenna or smth) that will check if this port is true or false
    
    void Start()
    {
        i_numberOfSourceValues = si_signalInputPair.i_numberofSourceValues;

        i_numberOfOutputs = 1;
        l_outputPorts = new List<Port>(i_numberOfOutputs);
        l_outputPorts.Add(p_outputPort);

    }
    
    void Update()
    {

    }
}
