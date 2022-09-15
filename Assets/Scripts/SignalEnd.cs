using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignalEnd : SignalComp
{
    public int i_signalValue;//Value being input to this signal end

    [SerializeField]
    Port p_input;//Port connected to this signal end

    [SerializeField]
    Text t_display;//Text display of output


    // Start is called before the first frame update
    void Start()
    {
        i_numberOfInputs = 1;
        l_inputPorts = new List<Port>(i_numberOfInputs);
        l_inputPorts.Add(p_input);
    }

    public override void GetInputs()
    {
        i_signalValue = p_input.GetConnectedValue();
    }
    public override void ActionValues()
    {
        //Do Nothing
    }
    public override void SetOutputs()
    {
        t_display.text = i_signalValue.ToString();
    }
    
}
