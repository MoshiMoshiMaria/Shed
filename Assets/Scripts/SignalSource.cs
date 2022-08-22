using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalSource : SignalComp
{

    int i_signalValue;//Value at the source
    Port p_outputPort;//Port to output as
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void GetInputs()
    {
        throw new System.NotImplementedException();
    }

    public override void ActionValues()
    {
        throw new System.NotImplementedException();
    }

    public override void SetOutputs()
    {
        throw new System.NotImplementedException();
    }
}
