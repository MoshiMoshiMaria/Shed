using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleHold : SignalComp
{
    int i_samplePortValue;//Value in sample port - updated every frame
    int i_sampleValue;//Value held in Sampler - updated when gate value is above 0
    bool b_gate;//Did the gate receive a signal?

    [SerializeField]
    Port p_sample;//Port for samples
    [SerializeField]
    Port p_gate;//Gate port

    [SerializeField]
    Port p_output;//Output port

    void Start()
    {
        i_numberOfInputs = 2;
        i_numberOfOutputs = 1;

        l_inputPorts = new List<Port>(i_numberOfInputs);
        l_inputPorts.Add(p_sample);
        l_inputPorts.Add(p_gate);

        l_outputPorts = new List<Port>(i_numberOfOutputs);
        l_outputPorts.Add(p_output);

        i_sampleValue = 0;
    }

    public override void GetInputs()
    {
        i_samplePortValue = p_sample.GetConnectedValue();
        b_gate = p_gate.GetConnectedValue() > 0;
    }
    public override void ActionValues()
    {
        if (b_gate) i_sampleValue = i_samplePortValue;
    }
    public override void SetOutputs()
    {
        p_output.SetConnectedValue(i_sampleValue);
    }
}
