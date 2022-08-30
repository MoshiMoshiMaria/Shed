using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInput : MonoBehaviour
{
    Camera mainCamera;//Main Camera, for ray casting
    LayerMask lm_layerMask;//Layermask for interactable objects

    bool b_portConnectionMode;//Are we in port connection mode?
    Port p_lastPort;//Last port selected
    CompBits cb_currentCompBit;//Current compBit selected
    
    Ray lastRay;// For Debugging purposes, allows drawing the last ray for longer than a single frame
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        lm_layerMask = 1 << 8;
        /* |***Layers in mask***|
         * 8 - Interactable
         * 
         */

        b_portConnectionMode = false;
        p_lastPort = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            lastRay = ray;
            RaycastHit hit;
            Physics.Raycast(ray, out hit, lm_layerMask);
            if(hit.collider != null)
            {
                //hit.collider.gameObject.GetComponent<Port>().SelectPort();
                /* |***TODO***|
                 * x.) Save last port
                 * x.) Enter port connection mode (boolean, if got a port in selection mode, connect them and forget them)
                 * 3.) Give user visual feedback for entering selection mode
                 * 4.) Give user visual feedback for connecting ports (maybe a wire model that can vary in length at some point, but for now, could just be a UI Text on button press)
                 */
                GameObject hitObject = hit.collider.gameObject;
                if (hitObject.tag == "Port")
                {
                   Port hitObjectPort = hitObject.GetComponent<Port>();
                   if (b_portConnectionMode && p_lastPort != null)
                   {
                       hitObjectPort.ConnectToPort(p_lastPort);
                       p_lastPort.ConnectToPort(hitObjectPort);
                       b_portConnectionMode = false;
                   }
                   else
                   {
                       b_portConnectionMode = true;
                   }
                   p_lastPort = hitObjectPort;
                }

                if (hitObject.tag == "CompBit")
                {
                    cb_currentCompBit = hitObject.GetComponent<CompBits>();
                    cb_currentCompBit.OnClickAction();
                }
            }
            else
            {
                Debug.Log("Hit Nothing");

            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            lastRay = ray;
            RaycastHit hit;
            Physics.Raycast(ray, out hit, lm_layerMask);

            if (b_portConnectionMode)
            {
                b_portConnectionMode = false;
            }
            if(hit.collider != null && !b_portConnectionMode)
            {

                GameObject hitObject = hit.collider.gameObject;
                 if (hitObject.tag == "Port")
                 {
                    Port hitObjectPort = hitObject.GetComponent<Port>();
                    hitObjectPort.p_connectedPort.DisconnectPort();
                    hitObjectPort.DisconnectPort();
                    p_lastPort = hitObjectPort;
                 }

            }
            else
            {
                Debug.Log("Hit Nothing");
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            cb_currentCompBit = null;
        }
        if(Input.mouseScrollDelta.y != 0)
        {
            if(cb_currentCompBit != null)
            {
                cb_currentCompBit.OnScrollAction(Input.mouseScrollDelta.y);
            }
            //If (sc_currentSigComp != null) ##For moving cvarried items closer and farther
        }
        
        Debug.DrawRay(lastRay.origin, lastRay.direction);
    }
}
