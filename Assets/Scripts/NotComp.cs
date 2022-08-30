using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotComp : SignalComp
{
    bool b_output;//Should the gate ouput


    [SerializeField]
    Port p_input1;//Input port 1

    [SerializeField]
    Port p_output1;//Output port 1

    int i_gateValue1;//Value of input 1

    // Start is called before the first frame update
    void Start()
    {
        i_numberOfInputs = 1;
        i_numberOfOutputs = 1;

        l_inputPorts = new List<Port>(i_numberOfInputs);
        l_inputPorts.Add(p_input1);

        l_outputPorts = new List<Port>(i_numberOfOutputs);
        l_outputPorts.Add(p_output1);
    }

    public override void GetInputs()
    {
        i_gateValue1 = l_inputPorts[0].GetConnectedValue();
    }
    public override void ActionValues()
    {
        if (i_gateValue1 > 0) b_output = false;
        else b_output = true;
    }
    public override void SetOutputs()
    {
        if (b_output) p_output1.SetConnectedValue(100);
        else p_output1.SetConnectedValue(0);
    }
}
