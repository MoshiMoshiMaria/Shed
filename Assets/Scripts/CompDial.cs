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
        OnScrollAction();
    }
    public override void OnScrollAction()
    {
        while (Input.GetMouseButton(0))
        {
            float deltaScroll = Input.mouseScrollDelta.y;

            if(deltaScroll > 0)
            {
                i_currentValue += Mathf.RoundToInt(deltaScroll * f_sensitivity);
                //Add behaviour for spinning the dial
            }
            else if(deltaScroll < 0)
            {
                i_currentValue -= Mathf.RoundToInt(deltaScroll * f_sensitivity);
                //Add behaviour for spinning the dial
            }
        }
    }
}
