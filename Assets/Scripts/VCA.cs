using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VCA : SignalComp
{
    int i_inputValue;//Value in input port
    int i_voltageValue;//Value held voltage gate / port

    int i_voltageControlledValue;//Value after voltage control applied

    [SerializeField]
    Port p_input;//Port for samples
    [SerializeField]
    Port p_gate;//Gate port

    [SerializeField]
    Port p_output;//Output port

    void Start()
    {
        i_numberOfInputs = 2;
        i_numberOfOutputs = 1;

        l_inputPorts = new List<Port>(i_numberOfInputs);
        l_inputPorts.Add(p_input);
        l_inputPorts.Add(p_gate);

        l_outputPorts = new List<Port>(i_numberOfOutputs);
        l_outputPorts.Add(p_output);

        i_inputValue = 0;
        i_voltageValue = 0;
    }

    public override void GetInputs()
    {
        i_inputValue = p_input.GetConnectedValue();
        i_voltageValue = p_gate.GetConnectedValue();
    }
    public override void ActionValues()
    {
        i_voltageControlledValue = i_inputValue * i_voltageValue / 100;
    }
    public override void SetOutputs()
    {
        p_output.SetConnectedValue(i_voltageControlledValue);
    }
}
