using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attenuator : SignalComp
{
    int i_inValue;//Signal value from the input port
    int i_attenuation;//Value of the attenuation setting - controlled by d_dial
    int i_attenuatedValue;//Value after attenuation

    [SerializeField]
    CompDial cd_dial;//Dial conencted to this attenuator

    [SerializeField]
    CompDisplay dis_display;//Display connected to this attenuator

    [SerializeField]
    Port p_input;//Input port

    [SerializeField]
    Port p_output;//Output port

    // Start is called before the first frame update
    void Start()
    {
        i_numberOfInputs = 1;
        i_numberOfOutputs = 1;

        l_inputPorts = new List<Port>(i_numberOfInputs);
        l_inputPorts.Add(p_input);

        l_outputPorts = new List<Port>(i_numberOfOutputs);
        l_outputPorts.Add(p_output);

        i_attenuation = 0;
    }

    public override void GetInputs()
    {
        i_inValue = p_input.GetConnectedValue();
        i_attenuation = cd_dial.GetValue();
        dis_display.text.text = i_attenuation.ToString();
    }
    public override void ActionValues()
    {
        i_attenuatedValue = i_inValue * i_attenuation / 100; //This will truncate any float values - i.e. 3.33 and 3.66 both become 3
        //May work on the rounding, but got weird results from this:
        //i_attenuatedValue = Mathf.RoundToInt(i_inValue * i_attenuation / 100);
    }
    public override void SetOutputs()
    {
        p_output.SetConnectedValue(i_attenuatedValue);
    }
}
