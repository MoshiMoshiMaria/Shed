using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompDial : CompBits
{

    [SerializeField]
    int i_minValue;//Min value of the dial
    [SerializeField]
    int i_MaxValue;//Max value of the dial
    
    int i_currentValue;//Current Value of the dial

    [SerializeField]
    float f_sensitivity;//Sensitivity of the dial
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetValue()
    {
        return i_currentValue;
    }

    public override void OnClickAction()
    {
        //Debug.Log("OnClick");
        //Do Nothing
    }
    public override void OnScrollAction(float deltaScroll)
    {
        //Debug.Log("OnScroll");
        i_currentValue += Mathf.RoundToInt(deltaScroll * f_sensitivity);
    }
}
