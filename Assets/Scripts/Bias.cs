using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bias : SignalComp
{
    int i_inputValue;//value taken from port
    int i_biasValue;//Value to bias input by
    int i_outputValue;//Value to send out

    // Start is called before the first frame update
    void Start()
    {
        i_numberOfInputs = 1;
        i_numberOfOutputs = 1;

        l_inputPorts = new List<Port>(i_numberOfInputs);
        l_outputPorts = new List<Port>(i_numberOfOutputs);

        l_inputPorts[0] = new Port(this, false);
        l_outputPorts[0] = new Port(this, true);
    }

    public override void GetInputs()
    {
        i_inputValue = l_inputPorts[0].GetConnectedValue();
    }

    public override void ActionValues()
    {
        i_outputValue = i_inputValue + i_biasValue;
    }

    public override void SetOutputs()
    {
        l_outputPorts[0].SetConnectedValue(i_outputValue);
    }

    public void SetBias(int value)
    {
        i_biasValue = value;
    }


}
