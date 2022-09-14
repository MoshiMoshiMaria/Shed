using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalInput : MonoBehaviour
{
    [SerializeField]
    SignalOutput so_signalOutputPair;

    [SerializeField]
    public int i_numberofSourceValues;//Number of input signal sources

    int i_numberofOutputValues;//Number of outputs - taken from output pair

    [SerializeField]
    List<Port> l_outputPorts;//List of output ports - can change between instances

    // Start is called before the first frame update
    void Start()
    {
        i_numberofOutputValues = so_signalOutputPair.i_numberofOutputValues;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
