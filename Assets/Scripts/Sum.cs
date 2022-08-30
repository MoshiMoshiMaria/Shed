using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sum : SignalComp
{
    [SerializeField]
    Port p_input1;//Input port 1
    [SerializeField]
    Port p_input2;//Input port 2
    [SerializeField]
    Port p_input3;//Input port 3
    [SerializeField]
    Port p_input4;//Input port 4

    [SerializeField]
    Port p_output1;//Output port 1

    int i_sumOfInputs;//Sum of all input ports

    List<int> l_inputValues;//List of input values

    void Start()
    {
        i_numberOfInputs = 4;
        i_numberOfOutputs = 1;

        l_inputPorts = new List<Port>(i_numberOfInputs);
        l_inputPorts.Add(p_input1);
        l_inputPorts.Add(p_input2);
        l_inputPorts.Add(p_input3);
        l_inputPorts.Add(p_input4);

        l_outputPorts = new List<Port>(i_numberOfOutputs);
        l_outputPorts.Add(p_output1);

        l_inputValues = new List<int>(4);
        l_inputValues.Add(0);
        l_inputValues.Add(0);
        l_inputValues.Add(0);
        l_inputValues.Add(0);
    }

    public override void GetInputs()
    {
        for(int x = 0; x < l_inputPorts.Count; x++)
        {
            l_inputValues[x] = l_inputPorts[x].GetConnectedValue();
        }
    }
    public override void ActionValues()
    {
        i_sumOfInputs = 0;
        for(int x = 0; x<4; x++)
        {
            i_sumOfInputs += l_inputValues[x];
        }
    }
    public override void SetOutputs()
    {
        l_outputPorts[0].SetConnectedValue(i_sumOfInputs);
    }

}
