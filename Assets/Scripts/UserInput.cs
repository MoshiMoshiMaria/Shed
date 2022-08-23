using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInput : MonoBehaviour
{
    Camera mainCamera;
    LayerMask lm_layerMask;

    Ray lastRay;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        lm_layerMask = 1 << 8;
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
                Debug.Log("Port hit");
                //hit.collider.gameObject.GetComponent<Port>().SelectPort();
                /* |***TODO***|
                 * 1.) Save last port
                 * 2.) Enter port connection mode (boolean, if got a port in selection mode, connect them and forget them)
                 * 3.) Give user visual feedback for entering selection mode
                 * 4.) Give user visual feedback for connecting ports (maybe a wire model that can vary in length at some point, but for now, could just be a UI Text on button press)
                 */
            }
            else
            {
                Debug.Log("Hit Nothing");
            }
        }
        
        Debug.DrawRay(lastRay.origin, lastRay.direction);
    }
}
