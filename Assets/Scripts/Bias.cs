using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bias : SignalComp
{
    int i_inputValue;//value taken from port
    [SerializeField]
    int i_biasValue;//Value to bias input by
    int i_outputValue;//Value to send out

    [SerializeField]
    CompDial cd_dial;//Dial connected to this bias

    [SerializeField]
    Port p_input1;//Input port 1
    [SerializeField]
    Port p_output1;//Output port 1

    // Start is called before the first frame update
    void Start()
    {
        i_inputValue = 0;
        i_outputValue = 0;

        i_numberOfInputs = 1;
        i_numberOfOutputs = 1;

        l_inputPorts = new List<Port>(i_numberOfInputs);
        l_outputPorts = new List<Port>(i_numberOfOutputs);

        l_inputPorts.Add(p_input1);
        l_outputPorts.Add(p_output1);
    }

    public override void GetInputs()
    {
        i_inputValue = l_inputPorts[0].GetConnectedValue();
        i_biasValue = cd_dial.GetValue();
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
