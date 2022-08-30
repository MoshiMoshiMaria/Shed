using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrComp : SignalComp
{
    bool b_output;//Should the gate ouput


    [SerializeField]
    Port p_input1;//Input port 1
    [SerializeField]
    Port p_input2;//Input port 2

    [SerializeField]
    Port p_output1;//Output port 1

    int i_gateValue1;//Value of input 1
    int i_gateValue2;//Value of input 2

    // Start is called before the first frame update
    void Start()
    {
        i_numberOfInputs = 2;
        i_numberOfOutputs = 1;

        l_inputPorts = new List<Port>(i_numberOfInputs);
        l_inputPorts.Add(p_input1);
        l_inputPorts.Add(p_input2);

        l_outputPorts = new List<Port>(i_numberOfOutputs);
        l_outputPorts.Add(p_output1);
    }

    public override void GetInputs()
    {
        i_gateValue1 = l_inputPorts[0].GetConnectedValue();
        i_gateValue2 = l_inputPorts[1].GetConnectedValue();
    }
    public override void ActionValues()
    {
        if (i_gateValue1 > 0 || i_gateValue2 > 0) b_output = true;
        else b_output = false;
    }
    public override void SetOutputs()
    {
        if (b_output) p_output1.SetConnectedValue(100);
        else p_output1.SetConnectedValue(0);
    }

}
