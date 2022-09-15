using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalSource : SignalComp
{
    int i_signalValue;//Value at the source after ActionValues

    float f_timer;//Float value for the timer
    float f_pulseTimer;//Float for length of pulse time;

    [SerializeField]
    Port p_outputPort;//Port to output as

    enum SignalType {Static, Oscillating, Random, Pulse };//Possible types of signal

    /* ||~~Type Explanations~~||
     * ~Static~         Signal stays at a constant value
     * ~Oscillating~    Signal will rise and fall at a constant rate
     * ~Random~         Signal value will change randomly
     * ~Pulse~          Signal will sit at one value, then pulse to another periodically
     * 
     */

    [SerializeField]
    SignalType st_signalType;

    /* ||~~Type variables~~||
     * ~Static~
     *  ~i_sStaticValue~     Value that static types will sit at
     *  
     * ~Oscillating~
     *  ~i_oMinValue~       Lowest possible value of the waveform
     *  ~i_oMaxValue~       Largest possible value of the waveform
     *  ~i_oStepValue~      Difference between values after each step
     *  ~f_oRestTime~       Time between steps between values
     *  ~b_oDirection~      Switch for direction of signal - False goes up, true down
     *  
     * ~Random~
     *  ~i_rMinValue~       Lowest possible random value 
     *  ~i_rMaxValue~       Largest possible random value
     *  ~f_rRestTime~       Time between changes to value
     *  
     * ~Pulse~
     *  ~i_pRestValue~      Value the signal rests at between pulses
     *  ~i_pPulseValue~     Value the singal pulses to
     *  ~i_pRestTime~       Time between pulses
     *  ~i_pPulseTime~      Time pulses last
     *  
     */

    // ||~~Static~~||
    [SerializeField]
    int i_sStaticValue;

    // ||~Oscillating~~||
    [SerializeField]
    int i_oMinValue;
    [SerializeField]
    int i_oMaxValue;
    [SerializeField]
    int i_oStepValue;
    [SerializeField]
    float f_oRestTime;
    bool b_oDirection;

    // ||~~Random~~|
    [SerializeField]
    int i_rMinValue;
    [SerializeField]
    int i_rMaxValue;
    [SerializeField]
    float f_rRestTime;

    // ||~~Pulse~~||
    [SerializeField]
    int i_pRestValue;
    [SerializeField]
    int i_pPulseValue;
    [SerializeField]
    float f_pRestTime;
    [SerializeField]
    float f_pPulseTime;

    // Start is called before the first frame update
    void Start()
    {
        i_signalValue = 0;
        f_timer = 0;
        f_pulseTimer = 0;

    }

    public override void GetInputs()
    {
        //Nothing to do - we are the inputs
    }

    public override void ActionValues()
    {
        switch (st_signalType)
        {
            case SignalType.Static:
                i_signalValue = i_sStaticValue;
                //Debug.Log("Static Source: " + i_signalValue);
                break;
            case SignalType.Oscillating:
                f_timer += Time.deltaTime;
                if (f_timer >= f_oRestTime)
                {
                if (b_oDirection)
                {
                    i_signalValue += i_oStepValue;
                }
                else
                {
                    i_signalValue -= i_oStepValue;
                }
                    f_timer = 0;
                if (i_signalValue <= i_oMinValue)
                {
                    i_signalValue = i_oMinValue;
                    b_oDirection = !b_oDirection;
                }
                if (i_signalValue >= i_oMaxValue)
                {
                    i_signalValue = i_oMaxValue;
                    b_oDirection = !b_oDirection;
                }
                }
                //Debug.Log("Oscillating Source: " + i_signalValue);
                break;
            case SignalType.Random:
                f_timer += Time.deltaTime;
                if (f_timer >= f_rRestTime)
                {
                    i_signalValue = Random.Range(i_rMinValue, i_rMaxValue);
                    f_timer = 0;
                }
                //Debug.Log("Random Source: " + i_signalValue);
                break;
            case SignalType.Pulse:
                f_timer += Time.deltaTime;
                if (f_timer >= f_pRestTime || f_pulseTimer != 0)
                {
                    i_signalValue = i_pPulseValue;
                    f_timer = 0;
                    f_pulseTimer += Time.deltaTime;
                    if (f_pulseTimer >= f_pPulseTime) f_pulseTimer = 0;
                }
                else
                {
                    i_signalValue = i_pRestValue;
                }
                //Debug.Log("Pulse Source: " + i_signalValue);
                break;
            default:
                break;
        }
    }

    public override void SetOutputs()
    {
        p_outputPort.SetConnectedValue(i_signalValue);
    }
}
