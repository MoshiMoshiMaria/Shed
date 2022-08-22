using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class SignalComp : MonoBehaviour
{
    protected int i_numberOfInputs;//Number of inputs
    protected int i_numberOfOutputs;//Number of outputs

    protected List<Port> l_inputPorts;//List of input ports
    protected List<Port> l_outputPorts;//List of output ports

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetInputs();
        ActionValues();
        SetOutputs();
    }

    public abstract void GetInputs();
    public abstract void ActionValues();
    public abstract void SetOutputs();
}
