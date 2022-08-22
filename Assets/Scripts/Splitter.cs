using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splitter : SignalComp
{
    [SerializeField]
    int i_signalValue;//Signal value that is to be split to all outputs.
    [SerializeField]
    Port p_input1;//Input port 1
    [SerializeField]
    Port p_output1;//Output port 1
    [SerializeField]
    Port p_output2;//Output port 2
    [SerializeField]
    Port p_output3;//Output port 3
    [SerializeField]
    Port p_output4;//Output port 4
    
    // Start is called before the first frame update
    void Start()
    {
        i_numberOfInputs = 1;
        i_numberOfOutputs = 4;

        i_signalValue = 0;

        l_inputPorts = new List<Port>(i_numberOfInputs);
        l_inputPorts.Add(p_input1);

        l_outputPorts = new List<Port>(i_numberOfOutputs);
        l_outputPorts.Add(p_output1);
        l_outputPorts.Add(p_output2);
        l_outputPorts.Add(p_output3);
        l_outputPorts.Add(p_output4);

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
        for(int x = 0; x < i_numberOfOutputs; x++)
        {
            l_outputPorts[x].SetConnectedValue(i_signalValue);
        }

    }
}
