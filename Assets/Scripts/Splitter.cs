using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splitter : SignalComp
{

    int i_signalValue;//Signal value that is to be split to all outputs.
    
    // Start is called before the first frame update
    void Start()
    {
        i_numberOfInputs = 1;
        i_numberOfOutputs = 4;

        l_inputPorts = new List<Port>(i_numberOfInputs);
        l_outputPorts = new List<Port>(i_numberOfOutputs);

    }

    public override void GetInputs()
    {
        i_signalValue = l_inputPorts[0].GetConnectedValue();
    }
    public override void ActionValues()
    {
        //Nothing to do
    }
    public override void SetOutputs()
    {
        for(int x = 0; x<i_numberOfOutputs; x++)
        {
            l_outputPorts[0].SetConnectedValue(i_signalValue);
        }

    }
}
